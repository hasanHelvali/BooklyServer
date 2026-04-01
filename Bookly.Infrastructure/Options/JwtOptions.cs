using System;
using System.Collections.Generic;
using System.Text;

namespace Bookly.Infrastructure.Options
{
    public sealed class JwtOptions
    {
        public const string SectionName = "JwtSettings";
        public string SecretKey { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;
        public string Audience { get; init; } = string.Empty;
        public int ExpiresInMinutes { get; init; }
    }
}
