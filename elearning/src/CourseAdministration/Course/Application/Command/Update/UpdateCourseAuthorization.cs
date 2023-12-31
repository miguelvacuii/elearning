﻿using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.CourseAdministration.Course.Domain.Exception;
using elearning.src.CourseAdministration.Course.Domain.Service;
using elearning.src.Shared.Infrastructure.Security.Authentication;
using elearning.src.Shared.Infrastructure.Security.Authorization;
using CourseAggregate = elearning.src.CourseAdministration.Course.Domain.Course;

namespace elearning.src.CourseAdministration.Course.Application.Command.Update
{
    public class UpdateCourseAuthorization : ICommandAuthorization
    {
        private readonly OAuth oAuth;
        private readonly CourseFinder courseFinder;

        public UpdateCourseAuthorization(OAuth oAuth, CourseFinder courseFinder)
        {
            this.oAuth = oAuth;
            this.courseFinder = courseFinder;
        }

        public virtual void Authorize(dynamic request)
        {
            UpdateCourseCommand updateCourseCommand = request as UpdateCourseCommand;
            CourseId id = new CourseId(updateCourseCommand.id);
            CourseAggregate course = courseFinder.FindById(id);

            if (oAuth.User().id != course.teacherId.Value)
            {
                throw CourseUpdateException.FromUserId();
            }
        }
    }
}
