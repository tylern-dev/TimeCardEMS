using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TimeCard.Api.External.Controllers.Auth.DTOs {
  public class RegisterRequest {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmedPassword { get; set; }
    public string PasswordConfirmation { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
      if (Password != PasswordConfirmation)
      {
        yield return new ValidationResult(
            "Password and password confirmation must match.",
            new[] { "PasswordConfirmation" }
        );
      }
    }
  }
}