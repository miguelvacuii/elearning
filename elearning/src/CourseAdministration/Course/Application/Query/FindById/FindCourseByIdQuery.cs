﻿using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseAdministration.Course.Application.Query.FindById
{
    public class FindCourseByIdQuery : IQuery
    {
        public string id { get; private set; }

        public FindCourseByIdQuery(string id)
        {
            this.id = id;
        }
    }
}
