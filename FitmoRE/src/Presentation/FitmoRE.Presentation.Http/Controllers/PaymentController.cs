using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FitmoRE.Presentation.Http.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }
    
    [HttpPost("add")]
    public ActionResult<SubscriptionPurchaseResponseDto> Purchase(SubscriptionPurchaseDto subscriptionPurchaseDto)
    {
        var result = _paymentService.PurchaseSubscription(subscriptionPurchaseDto);
        return Ok(result);
    }

}