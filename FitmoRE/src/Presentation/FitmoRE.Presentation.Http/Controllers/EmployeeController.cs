using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
using Microsoft.AspNetCore.Mvc;

// using System.Collections.Generic;
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
        var result = _employeeService.GetEmployeeInfo(employeeId);
        if (string.IsNullOrEmpty(result.FullName))
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("add")]
    public ActionResult<AddEmployeeResponseDto> Add(AddEmployeeDto addEmployeeDto)
    {
        var result = _employeeService.AddEmployee(addEmployeeDto);
        return Ok(result);
    }
}