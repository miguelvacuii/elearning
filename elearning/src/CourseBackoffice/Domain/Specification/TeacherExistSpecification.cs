﻿using elearning.src.CourseBackoffice.Infrastructure.Service.Course;
using elearning.src.Shared.Domain;
using elearning.src.Shared.Domain.Specification;

namespace elearning.src.CourseBackoffice.Domain.Specification
{
    public class TeacherExistSpecification : SpecificationBase<Course>
    {
        private readonly CourseAdapter courseAdapter;

        public TeacherExistSpecification(CourseAdapter courseAdapter)
        {
            this.courseAdapter = courseAdapter;
        }

        public override bool IsSatisfiedBy(Course candidate) {
            Teacher teacher = courseAdapter.FindTeacherById(candidate.teacherId.Value);
            return (teacher != null && teacher.role != AuthUser.ROLE_TEACHER) ? false : true;
        }
    }
}
