using elearning.src.CourseBackoffice.Domain;
using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.CourseBackoffice.Application.Command.Create
{
    public class CreateCourseCommandHandler : ICommandHandler
    {
        private readonly CreateCourseUseCase createCourseUseCase;

        public CreateCourseCommandHandler(
            CreateCourseUseCase createCourseUseCase
        ) {
            this.createCourseUseCase = createCourseUseCase;
        }

        public void Handle(ICommand command)
        {
            CreateCourseCommand createCourseCommand = command as CreateCourseCommand;

            CourseId id = new CourseId(createCourseCommand.id);
            CourseName name = new CourseName(createCourseCommand.name);
            CourseDescription description = new CourseDescription(createCourseCommand.description);
            CourseTeacherId teacherId = new CourseTeacherId(createCourseCommand.teacherId);

            createCourseUseCase.Invoke(id, name, description, teacherId);
        }
    }
}
