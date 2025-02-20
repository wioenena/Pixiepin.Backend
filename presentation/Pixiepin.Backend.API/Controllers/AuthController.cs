using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pixiepin.Backend.Application.Features.Auth.CreateAccount;
using Pixiepin.Backend.Application.Features.Auth.Login;

namespace Pixiepin.Backend.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IMediator mediator) : ControllerBase {
    private readonly IMediator mediator = mediator;

    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateAccountRequest request) => this.Ok(await this.mediator.Send(request));

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request) => this.Ok(await this.mediator.Send(request));
}
