using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeCard.Api.Core.Models;

namespace TimeCard.Api.Core.Data {
 public class TimeCardDbContext : IdentityDbContext<User, UserRole, int>{
   public TimeCardDbContext(DbContextOptions<TimeCardDbContext> options) : base(options){
   }
 }
}