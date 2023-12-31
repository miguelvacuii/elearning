﻿using System.ComponentModel.DataAnnotations;

namespace elearning.src.CourseAdministration.Course.Domain.Exception
{
    public class CourseStatusException : ValidationException
    {
		public CourseStatusException(string message) : base(message) { }

		public static CourseStatusException FromPublish(CourseStatus status)
		{
			return new CourseStatusException(
				string.Format("Cannot publish this course because status is {0}", status.Value)
			);
		}

		public static CourseStatusException FromUpdate(CourseStatus status)
		{
			return new CourseStatusException(
				string.Format("Cannot update this course because status is {0}", status.Value)
			);
		}
	}
}
