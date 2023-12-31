﻿using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseAdministration.Course.Infrastructure.Service.Course
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

        public virtual Teacher FindTeacherById(string id)
        {
            IResponse response = courseFacade.FindTeacherById(id);
            return courseTranslator.FromRepresentationToTeacher(response);
        }
    }
}
