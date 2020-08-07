
using System.ComponentModel;

namespace BrandMonitor.API.Domain.Models
{
    public enum TaskStatus : byte
    {
        [Description("Created")]
        Created = 1,

        [Description("Running")]
        Running = 2,

        [Description("Finished")]
        Finished = 3,
    }
}
