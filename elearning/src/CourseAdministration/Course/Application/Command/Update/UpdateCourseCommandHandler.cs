using elearning.src.CourseAdministration.Course.Domain;
using elearning.src.Shared.Domain.Bus.Command;

namespace elearning.src.CourseAdministration.Course.Application.Command.Update
{
    public class UpdateCourseCommandHandler : ICommandHandler
    {
        private readonly UpdateCourseUseCase updateCourseUseCase;

        public UpdateCourseCommandHandler(
            UpdateCourseUseCase updateCourseUseCase
        ) {
            this.updateCourseUseCase = updateCourseUseCase;
        }

        public void Handle(ICommand command)
        {
            UpdateCourseCommand updateCourseCommand = command as UpdateCourseCommand;

            CourseId id = new CourseId(updateCourseCommand.id);
            CourseName name = new CourseName(updateCourseCommand.name);
            CourseDescription description = new CourseDescription(updateCourseCommand.description);

            updateCourseUseCase.Invoke(id, name, description);
        }
    }
}
