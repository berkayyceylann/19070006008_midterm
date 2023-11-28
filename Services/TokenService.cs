using Microsoft.AspNetCore.Http;

namespace _19070006008_midterm.Services
{
    public static class TokenService
    {
        public static string GetToken(HttpRequest request)
        {
            
            if (request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                string token = authHeader.FirstOrDefault();
                if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer", StringComparison.OrdinalIgnoreCase))
                {
                    
                    return token["Bearer ".Length..].Trim();
                }
            }
            return string.Empty;
        }
    }
}
