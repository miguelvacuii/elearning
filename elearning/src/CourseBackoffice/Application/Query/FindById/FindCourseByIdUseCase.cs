﻿using elearning.src.CourseBackoffice.Application.Query.Response;
using elearning.src.CourseBackoffice.Domain;
using elearning.src.CourseBackoffice.Domain.Exception;
using elearning.src.Shared.Domain.Bus.Query;
using CourseAggregate = elearning.src.CourseBackoffice.Domain.Course;

namespace elearning.src.CourseBackoffice.Application.Query.FindById
{
    public class FindCourseByIdUseCase
    {
        private readonly ICourseRepository courseRepository;
        private readonly CourseResponseConverter courseResponseConverter;

        public FindCourseByIdUseCase(
            ICourseRepository courseRepository,
            CourseResponseConverter courseResponseConverter
        ) {
            this.courseRepository = courseRepository;
            this.courseResponseConverter = courseResponseConverter;
        }

        public virtual IResponse Invoke(CourseId courseId)
        {
            CourseAggregate course = courseRepository.Get(courseId);
            if (course == null) {
                throw CourseNotFoundException.FromId(courseId);
            }
            return courseResponseConverter.Convert(course);
        }
    }
}