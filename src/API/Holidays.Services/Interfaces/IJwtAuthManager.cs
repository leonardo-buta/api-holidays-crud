using Holidays.Services.Auth;
using System;
using System.Security.Claims;

namespace Holidays.Services.Interfaces
{
    public interface IJwtAuthManager
    {
        JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);
    }
}
