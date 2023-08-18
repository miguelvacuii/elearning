using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.CourseAdministration.Course.Application.Command.Update
{
    public class UpdateCourseCommand : ICommand
    {
        public string id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }

        public UpdateCourseCommand(
            string id,
            string name,
            string description
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
        }
    }
}
