using System;
using elearning.src.Shared.Domain;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class EnrollmentCreatedAt : DateTimeValueObject
	{
		public EnrollmentCreatedAt(DateTime value) : base(value) { }
	}
}
