using System;
using System.Collections.Generic;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Specification;
using elearning.src.StudentParticipation.Enrollment.Domain.Event;
using elearning.src.StudentParticipation.Enrollment.Domain.Exception;

namespace elearning.src.StudentParticipation.Enrollment.Domain
{
    public class Enrollment : AggregateRoot {

        public EnrollmentId id { get; private set; }
        public EnrollmentProgress progress { get; private set; }
        public EnrollmentCourseId courseId { get; private set; }
        public EnrollmentStudentId studentId { get; private set; }
        public EnrollmentCreatedAt createdAt { get; private set; }
        public EnrollmentUpdatedAt updatedAt { get; private set; }

        private Enrollment(
            EnrollmentId id,
            EnrollmentProgress progress,
            EnrollmentCourseId courseId,
            EnrollmentStudentId studentId,
            EnrollmentCreatedAt createdAt,
            EnrollmentUpdatedAt updatedAt
        ){
            this.id = id;
            this.progress = progress;
            this.courseId = courseId;
            this.studentId = studentId;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
        }

        public static Enrollment Create(
            EnrollmentId id,
            EnrollmentProgress progress,
            EnrollmentCourseId courseId,
            EnrollmentStudentId studentId,
            ISpecification<Enrollment> enrollmentSpecification
        ){
            EnrollmentCreatedAt createdAt = new EnrollmentCreatedAt(DateTime.Now);
            EnrollmentUpdatedAt updatedAt = new EnrollmentUpdatedAt(DateTime.Now);
            Enrollment enrollment = new Enrollment(id, progress, courseId, studentId, createdAt, updatedAt);

            if (!enrollmentSpecification.IsSatisfiedBy(enrollment)) {
                throw EnrollmentSpecificationException.FromCreation(courseId, studentId);
            }
            enrollment.Record(
                new EnrollmentCreatedEvent(
                    enrollment.id.Value,
                    new Dictionary<string, string>()
                    {
                        ["progress"] = enrollment.progress.Value.ToString(),
                        ["student_id"] = enrollment.studentId.Value,
                        ["course_id"] = enrollment.courseId.Value,
                        ["created_at"] = enrollment.createdAt.Value.ToString(),
                        ["updated_at"] = enrollment.updatedAt.Value.ToString(),
                    }
                )
            );

            return enrollment;
        }
    }
}
