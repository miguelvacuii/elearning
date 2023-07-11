using elearning.src.Shared.Domain.Bus.Query;
using JsonApiSerializer;
using Newtonsoft.Json;

namespace elearning.src.Shared.Infrastructure.Service.JsonApi
{
    public class JsonApiEncoder : IJsonApiEncoder
    {
        public object EncodeData(IResponse response)
        {
            string responseJson = JsonConvert.SerializeObject(response, new JsonApiSerializerSettings());
            return JsonConvert.DeserializeObject(response.ToString(), new JsonApiSerializerSettings());
        }

        public object EncodeError(IResponse response)
        {
            string responseJson = JsonConvert.SerializeObject(response, new JsonApiSerializerSettings());
            return JsonConvert.DeserializeObject(response.ToString(), new JsonApiSerializerSettings());
        }
    }
}
