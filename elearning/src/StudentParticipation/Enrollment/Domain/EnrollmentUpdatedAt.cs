using System;
using elearning.src.Shared.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentUpdatedAt : DateTimeValueObject
	{
		public EnrollmentUpdatedAt(DateTime value) : base(value) { }
	}
}
