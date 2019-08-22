using System;
using Microsoft.AspNetCore.Identity;
namespace TimeCard.Api.Core.Models {
  public class UserRole :  IdentityRole<int> {
        public UserRole() : base() {/* Empty */}
        public UserRole(string roleName) : base(roleName) {/* Empty */}
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
  }
}