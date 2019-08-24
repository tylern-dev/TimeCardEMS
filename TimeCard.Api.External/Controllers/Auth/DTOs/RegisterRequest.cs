namespace TimeCard.Api.External.Controllers.Auth.DTOs {
  public class RegisterRequest {
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }
  }
}