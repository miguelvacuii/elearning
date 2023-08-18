using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.CourseAdministration.Course.Application.Query.Response
{
    public class CourseResponse : IResponse {

        public string id { get; private set; }
        public string name { get; private set; }
        public string description { get; private set; }
        public string status { get; private set; }
        public string teacherId { get; private set; }

        public CourseResponse(
            string id,
            string name,
            string description,
            string status,
            string teacherId
        ) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.status = status;
            this.teacherId = teacherId;
        }
    }
}