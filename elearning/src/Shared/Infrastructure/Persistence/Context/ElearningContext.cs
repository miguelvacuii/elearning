using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Infrastructure.Persistence.Mapping;
using Microsoft.EntityFrameworkCore;

namespace elearning.src.Shared.Infrastructure.Persistence.Context
{
    public class ELearningContext : DbContext
    {
        public ELearningContext(DbContextOptions opt) : base(opt) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
