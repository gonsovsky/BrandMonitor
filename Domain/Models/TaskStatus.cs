
using System.ComponentModel;

namespace BrandMonitor.API.Domain.Models
{
    public enum TaskStatus : byte
    {
        [Description("created")]
        Created = 1,

        [Description("running")]
        Running = 2,

        [Description("finished")]
        Finished = 3,
    }
}
