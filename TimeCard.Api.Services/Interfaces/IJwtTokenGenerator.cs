using System;

namespace TimeCard.Api.Services.Interfaces {

    public interface IJwtTokenGenerator {

        DateTime Lifetime { set; }
        string Audience { get; set; }

        string GenerateToken(string userId);
        string GenerateToken(int userId);

    }
}
