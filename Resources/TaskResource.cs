using System;

namespace BrandMonitor.API.Resources
{
    public class TaskResource
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int QuantityInPackage { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}