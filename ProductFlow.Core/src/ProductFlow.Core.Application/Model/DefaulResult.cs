using Newtonsoft.Json;

namespace ProductFlow.Core.Application.Model
{
    public class DefaulResult
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public object Result { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        public bool Success { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Erros { get; private set; }

        [JsonConstructor]
        public DefaulResult(object result, string message, bool success, List<string> erros)
        {
            Result = result;
            Message = message;
            Success = success;
            Erros = erros;
        }

        public DefaulResult(object result, string message, bool success = true)
        {
            Result = result;
            Message = message;
            Success = success;
        }

        public DefaulResult(string message, bool success, List<string> erros)
        {
            Erros = erros;
            Success = success;
            Message = message;
        }

        public DefaulResult(string message, bool success = true)
        {
            Success = success;
            Message = message;
        }

        public DefaulResult(object result, bool success = true)
        {
            Result = result;
            Success = success;
        }

        public DefaulResult(bool success, List<string> erros)
        {
            Erros = erros;
            Success = success;
        }
    }
}
