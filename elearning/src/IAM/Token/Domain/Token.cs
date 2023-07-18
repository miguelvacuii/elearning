using System;
using System.Collections.Generic;
using elearning.src.Shared.Domain;
using elearning.src.IAM.Token.Domain.Event;

namespace elearning.src.IAM.Token.Domain
{
    public class Token : AggregateRoot
    {
        public TokenHash hash { get; private set; }
        public TokenUserId userId { get; private set; }
        public TokenCreatedAt createdAt { get; private set; }
        public TokenUpdatedAt updatedAt { get; private set; }

        private Token(
            TokenHash hash,
            TokenUserId userId,
            TokenCreatedAt createdAt,
            TokenUpdatedAt updatedAt
        )
        {
            this.hash = hash;
            this.userId = userId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Token Create(TokenHash hash, TokenUserId userId)
        {
            TokenCreatedAt createdAt = new TokenCreatedAt(DateTime.Now);
            TokenUpdatedAt updatedAt = new TokenUpdatedAt(DateTime.Now);

            Token token = new Token(hash, userId, createdAt, updatedAt);

            token.Record(
                new TokenCreatedEvent(
                    token.userId.Value,
                    new Dictionary<string, string>()
                    {
                        ["hash"] = token.hash.Value,
                        ["user_id"] = token.userId.Value,
                        ["created_at"] = token.createdAt.Value.ToString(),
                        ["updated_at"] = token.updatedAt.Value.ToString(),
                    }
                )
            );

            return token;
        }
    }
}
