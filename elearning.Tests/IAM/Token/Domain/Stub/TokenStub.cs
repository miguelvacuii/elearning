using TokenAggregate = elearning.src.IAM.Token.Domain.Token;

namespace elearning.Tests.IAM.Token.Domain.Stub
{
    public class TokenStub
    {
        public static TokenAggregate ByDefault()
        {
            return TokenAggregate.Create(
                TokenHashStub.ByDefault(),
                TokenUserIdStub.ByDefault()
            );
        }

        public static TokenAggregate FromValues(
            string hash = "",
            string userId = ""
        )
        {
            return TokenAggregate.Create(
                string.IsNullOrEmpty(hash)
                            ? TokenHashStub.ByDefault()
                            : TokenHashStub.FromValue(hash),
                string.IsNullOrEmpty(userId)
                            ? TokenUserIdStub.ByDefault()
                            : TokenUserIdStub.FromValue(userId)
            );
        }
    }
}
