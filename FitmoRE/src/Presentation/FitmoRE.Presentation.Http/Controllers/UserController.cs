﻿namespace FitmoRE.Presentation.Http.Controllers;

using System.Collections.Generic;
using FitmoRE.Application.DTO;
using FitmoRE.Application.Services;
using Microsoft.AspNetCore.Mvc;

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
        var result = _userService.GetUserInfo(userInfoDto.ClientId);
        if (string.IsNullOrEmpty(result.FullName))
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost("register")]
    public ActionResult<UserRegistrationResponseDto> Register(UserRegistrationDto registerClientDto)
    {
        var result = _userService.RegisterUser(registerClientDto);
        return Ok(result);
    }

    [HttpPost("auth")]
    public ActionResult<UserAuthResponseDto> Auth(UserAuthDto authenticateClientDto)
    {
        var result = _userService.AuthenticateUser(authenticateClientDto);

        // if (string.IsNullOrEmpty(result.Message))
        // {
        //     return NotFound();
        // }
        //
        // return Ok("you are signed in!");
        return result;
    }
}