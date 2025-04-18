﻿using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProductJudgeAPI.Features.User.Login;
using ProductJudgeAPI.Features.User.Register;

namespace ProductJudgeAPI.Controllers;

[Route($"{ApiConstants.Endpoints.ApiBase}/{ApiConstants.Endpoints.User}")]
[ControllerName(ApiConstants.Controllers.User)]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpPost("login", Name = "Login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPost("register", Name = "Register")]
    public async Task<IActionResult> Add([FromBody] RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}
