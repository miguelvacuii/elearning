using System;
using System.Security.Cryptography;
using System.Text;
using elearning.src.Shared.Domain;

namespace elearning.src.Shared.Infrastructure.Service.Hashing
{
    public class DefaultHashing : IHashing
    {
        public HashedPassword Hash(string password)
        {
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;

            using (var algorithm = new SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }

            string hash = Convert.ToBase64String(hashBytes);

            return new HashedPassword(hash);
        }
    }
}
