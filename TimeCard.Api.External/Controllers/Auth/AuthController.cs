using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TimeCard.Api.Core.Interfaces;
using TimeCard.Api.Core.Models;
using TimeCard.Api.External.Controllers.Auth.DTOs;
using TimeCard.Api.Services.Interfaces;

namespace TimeCard.Api.External.Controllers {
  [Authorize]
  [Produces("application/json")]
  [Route("[controller]")]
  public class AuthController : AuthUserController {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IAsyncRepository<User> _userRepository;
    private readonly IJwtTokenGenerator _tokenGenerator;
    private readonly IMapper _mapper;

    public AuthController(
      UserManager<User> userManager,
      SignInManager<User> signInManager,
      IAsyncRepository<User> userRepository,
      IJwtTokenGenerator tokenGenerator,
      IMapper mapper
    ) {
      _userManager = userManager;
      _signInManager = signInManager;
      _userRepository = userRepository;
      _tokenGenerator = tokenGenerator;
      _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterRequest data) {
        var user = _mapper.Map<User>(data);
        var result = await _userManager.CreateAsync(user);

        return Ok();
    }
  }
}