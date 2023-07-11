using elearning.src.Shared.Domain.Bus.Query;

namespace elearning.src.Shared.Infrastructure.Service.JsonApi {
    public interface IJsonApiEncoder {
        object EncodeData(IResponse response);
        object EncodeError(IResponse response);
    }
}
