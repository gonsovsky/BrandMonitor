using System.Text.Json.Serialization;

namespace BrandMonitor.API.Domain.Responses
{
    public class TaskResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("timestamp")]
        public string TimeStamp { get; set; }
    }
}