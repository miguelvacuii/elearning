using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.CourseBackoffice.Application.Command.Create
{
    public class CreateCourseCommand : ICommand
    {
        public string id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public string teacherId { get; private set; }

        public CreateCourseCommand(
            string id,
            string name,
            string description,
            string teacherId
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.teacherId = teacherId;
        }
    }
}
