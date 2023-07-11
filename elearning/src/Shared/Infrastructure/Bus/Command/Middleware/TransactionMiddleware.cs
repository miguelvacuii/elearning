using elearning.src.Shared.Domain.Bus.Command;
using elearning.src.Shared.Infrastructure.Bus.Command.Middleware;
using elearning.src.Shared.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace elearning.Shared.Infrastructure.Bus.Command.Middleware
{
    public class TransactionMiddleware : MiddlewareHandler
    {
        private readonly ELearningContext ELearningContext;

        public TransactionMiddleware(ELearningContext eLearningContext)
        {
            ELearningContext = eLearningContext;
        }

        public override void Handle(ICommand command)
        {
            using (var transaction = ELearningContext.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
            {
                try
                {
                    base.Handle(command);
                    ELearningContext.SaveChanges();
                    transaction.Commit();
                }
                catch (System.Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
    }
}
