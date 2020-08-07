using System;
using System.Data.Common;

namespace BrandMonitor.API.Domain.Models
{
    public class BrandTask
    {
        public System.Guid Id { get; set; }

        public TaskStatus Status { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}