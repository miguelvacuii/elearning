using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Exception;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentProgress : IntegerValueObject
    {
        public const int MIN_VALUE = 1;
        public const int MAX_VALUE = 100;

        public EnrollmentProgress(int value) : base(value)
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw InvalidAttributeException.FromMinLength("progress", value);
            }
        }
    }
}
