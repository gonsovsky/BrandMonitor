using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BrandMonitor.API.Domain.Responses
{
    public class ErrorResponse
    {
        [JsonPropertyName("messages")]
        public List<string> Messages { get; private set; }

        public ErrorResponse(List<string> messages)
        {
            this.Messages = messages ?? new List<string>();
        }
    }
}