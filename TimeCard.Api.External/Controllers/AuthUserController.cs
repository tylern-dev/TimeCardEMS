using Microsoft.AspNetCore.Mvc;
using TimeCard.Api.External.Helpers;

namespace TimeCard.Api.External.Controllers {
  [ApiController]
  public abstract class AuthUserController : ControllerBase {
    public TokenReader Token = new TokenReader();
    // public AuthUser AuthUser;
  }
}