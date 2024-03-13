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

    [HttpGet("{userInfoDto}")]
    public ActionResult<UserInfoResponseDto> GetUserInfo(UserInfoDto userInfoDto)
    {
        UserInfoResponseDto result = _userService.GetUserInfo(userInfoDto.ClientId);
        if (string.IsNullOrEmpty(result.FullName))
        {
            return NotFound();
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

        // if (string.IsNullOrEmpty(result.Message))
        // {
        //     return NotFound();
        // }
        //
        // return Ok("you are signed in!");
        return result;
    }
}