using System.Collections.Generic;
using elearning.src.Shared.Domain;
using elearning.src.CourseBackoffice.Domain.Event;
using elearning.src.Shared.Domain.Exception;
using elearning.src.Shared.Domain.Specification;
using elearning.src.CourseBackoffice.Domain.Exception;

namespace elearning.src.CourseBackoffice.Domain
{
    public class Course : AggregateRoot {

        public CourseId id { get; private set; }
        public CourseName name { get; private set; }
        public CourseDescription description { get; private set; }
        public CourseStatus status { get; private set; }
        public CourseTeacherId teacherId { get; private set; }

        private Course (
            CourseId id,
            CourseName name,
            CourseDescription description,
            CourseStatus status,
            CourseTeacherId teacherId
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.status = status;
            this.teacherId = teacherId;
        }

        public static Course Create(
            CourseId id,
            CourseName name,
            CourseDescription description,
            CourseTeacherId teacherId,
            ISpecification<Course> teacherExistSpecification
        ) {

            CourseStatus status = new CourseStatus(CourseStatusEnum.unpublish.ToString());
            Course course = new Course(id, name, description, status, teacherId);

            if (!teacherExistSpecification.IsSatisfiedBy(course))
            {
                throw InvalidAttributeException.FromText(
                    "This id not corresponding to an user with role teacher"
                );
            }

            course.Record(
                new CourseCreatedEvent(
                    course.id.Value,
                    new Dictionary<string, string>()
                    {
                        ["name"] = course.name.Value,
                        ["description"] = course.description.Value,
                        ["status"] = course.status.Value,
                        ["teacher_id"] = course.teacherId.Value
                    }
                )
            );

            return course;
        }

        public void Publish()
        {
            if (!status.Value.Equals(CourseStatusEnum.unpublish.ToString())) {
                throw CourseStatusException.FromPublish(status);
            }

            status = new CourseStatus(CourseStatusEnum.published.ToString());

            this.Record(
                new CoursePublishedEvent(
                    id.Value,
                    new Dictionary<string, string>()
                    {
                        ["name"] = name.Value,
                        ["status"] = status.Value,
                    }
                )
            );
        }

        public void Update(CourseName newName, CourseDescription newDescription) {

            if (!status.Value.Equals(CourseStatusEnum.unpublish.ToString())) {
                throw CourseStatusException.FromUpdate(status);
            }
            if (name.Equals(newName) && description.Equals(newDescription)) {
                return;
            }

            name = newName;
            description = newDescription;

            this.Record(
                new CoursePublishedEvent(
                    id.Value,
                    new Dictionary<string, string>()
                    {
                        ["name"] = name.Value,
                        ["description"] = description.Value,
                    }
                )
            );
        }
    }
}
