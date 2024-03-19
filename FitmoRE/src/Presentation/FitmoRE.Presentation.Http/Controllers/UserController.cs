// using System.Collections.Generic;

using FitmoRE.Application.DTO;
using FitmoRE.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FitmoRE.Presentation.Http.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{userId}")]
    public ActionResult<UserInfoResponseDto> GetUserInfo(string userId)
    {
        UserInfoResponseDto result = _userService.GetUserInfo(userId);
        if (string.IsNullOrEmpty(result.FullName))
        {
            return NotFound("who r u:(");
        }

        return Ok(result);
    }

    [HttpPost("register")]
    public ActionResult<UserRegistrationResponseDto> Register(UserRegistrationDto registerClientDto)
    {
        UserRegistrationResponseDto result = _userService.RegisterUser(registerClientDto);
        return Ok(result);
    }

    [HttpPost("auth")]
    public ActionResult<UserAuthResponseDto> Auth(UserAuthDto authenticateClientDto)
    {
        UserAuthResponseDto result = _userService.AuthenticateUser(authenticateClientDto);

        if (string.IsNullOrEmpty(result.Message))
        {
            return NotFound("who r u:(");
        }

        return result;
    }
}