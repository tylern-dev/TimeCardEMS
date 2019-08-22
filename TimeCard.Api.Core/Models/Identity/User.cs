using System;
using Microsoft.AspNetCore.Identity;
using TimeCard.Api.Core.Interfaces;

namespace TimeCard.Api.Core.Models {
  public class User : IdentityUser<int>, IIdKeyModel {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string zip { get; set; }
    public UserType UserType { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime Terminated { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }


  }
}