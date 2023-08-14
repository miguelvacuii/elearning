﻿using elearning.src.CourseBackoffice.Domain;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseBackoffice.Infrastructure.Service.Course
{
    public class CourseAdapter
    {
        private readonly CourseFacade courseFacade;
        private readonly CourseTranslator courseTranslator;

        public CourseAdapter(
            CourseFacade courseFacade,
            CourseTranslator courseTranslator
        )
        {
            this.courseFacade = courseFacade;
            this.courseTranslator = courseTranslator;
        }

        public virtual Teacher FinTeacherById(string id)
        {
            IResponse response = courseFacade.FindPayloadById(id);
            return courseTranslator.FromRepresentationToTeacher(response);
        }
    }
}
