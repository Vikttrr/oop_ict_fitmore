using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
using Microsoft.AspNetCore.Mvc;

// using System.Collections.Generic;
namespace FitmoRE.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class SubscriptionController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;

    public SubscriptionController(ISubscriptionService subscriptionService)
    {
        _subscriptionService = subscriptionService;
    }

    [HttpGet("{subscriptionId}")]
    public ActionResult<EmployeeInfoResponseDto> GetSubscriptionInfo(string subscriptionId)
    {
        var result = _subscriptionService.GetSubscriptionById(subscriptionId);
        if (string.IsNullOrEmpty(result.StartDate))
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("add")]
    public ActionResult<AddSubscriptionResponseDto> Add(AddSubscriptionDto addSubscriptionDto)
    {
        var result = _subscriptionService.AddSubscription(addSubscriptionDto);
        return Ok(result);
    }
}