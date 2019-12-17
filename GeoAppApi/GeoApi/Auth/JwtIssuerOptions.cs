

using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace GeoApi.Auth
{
    public class JwtIssuerOptions
    {

        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;

        // Set the timespan the token will be valid for (default is 120 min)

        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);

        public Func<Task<string>> JtiGenerator =>
          () => Task.FromResult(Guid.NewGuid().ToString());

        /// The signing key to use when generating tokens.

        public SigningCredentials SigningCredentials { get; set; }
    }
}
