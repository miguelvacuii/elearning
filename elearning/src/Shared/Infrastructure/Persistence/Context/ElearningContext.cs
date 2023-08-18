
using Microsoft.EntityFrameworkCore;
using elearning.src.IAM.Token.Domain;
using elearning.src.IAM.Token.Infrastructure.Persistence.Mapping;
using elearning.src.IAM.User.Domain;
using elearning.src.IAM.User.Infrastructure.Persistence.Mapping;
using Course = elearning.src.CourseAdministration.Course.Domain.Course;
using elearning.src.CourseAdministration.Course.Infrastructure.Persistence.Mapping;
using elearning.src.StudentParticipation.Enrollment.Domain;
using elearning.src.StudentParticipation.Enrollment.Infrastructure.Persistence.Mapping;

namespace elearning.src.Shared.Infrastructure.Persistence.Context
{
    public class ELearningContext : DbContext
    {
        public ELearningContext(DbContextOptions opt) : base(opt) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TokenMap());
            modelBuilder.ApplyConfiguration(new CourseMap());
            modelBuilder.ApplyConfiguration(new EnrollmentMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
