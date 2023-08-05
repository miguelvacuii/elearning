using System;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Infrastructure.Security.Authentication.JWT;

namespace elearning.src.Shared.Infrastructure.Security.Authentication
{
    public class OAuth
    {
        private readonly IJWTDecoder decoder;

        public OAuth(IJWTDecoder decoder)
        {
            this.decoder = decoder;
        }

        public virtual AuthUser User()
        {
            return decoder.Decode();

        }
    }
}
