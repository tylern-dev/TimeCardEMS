using System.Linq;
using System.Security.Claims;

namespace TimeCard.Api.External.Helpers {
  public class TokenReader {
    public int UserId (ClaimsPrincipal claimsPrincipal) {
        return int.Parse(claimsPrincipal?.Claims?.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
        }
  }
}