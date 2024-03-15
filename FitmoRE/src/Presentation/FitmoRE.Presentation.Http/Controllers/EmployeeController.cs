// using System.Collections.Generic;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitmoRE.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("{employeeId}")]
    public ActionResult<EmployeeInfoResponseDto> GetEmployeeInfo(string employeeId)
    {
        EmployeeInfoResponseDto result = _employeeService.GetEmployeeInfo(employeeId);
        if (string.IsNullOrEmpty(result.FullName))
        {
            return NotFound("who r u:(");
        }

        return Ok(result);
    }

    [HttpPost("add")]
    public ActionResult<AddEmployeeResponseDto> Add(AddEmployeeDto addEmployeeDto)
    {
        AddEmployeeResponseDto result = _employeeService.AddEmployee(addEmployeeDto);
        return Ok(result);
    }
}