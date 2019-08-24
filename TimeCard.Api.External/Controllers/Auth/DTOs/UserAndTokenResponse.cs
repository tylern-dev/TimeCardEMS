using System;

namespace TimeCard.Api.External.Controllers.Auth.DTOs {
  public class UserAndTokenResponse {
    public UserAndTokenUserResponse User { get; set; }
    public string Token { get; set; }

    public class UserAndTokenUserResponse {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        // public DateTime? AcceptedESign { get; set; }
        // public List<UserTokenUserOrganizationResponse> UserOrganizations { get; set; }
    }
  }
}