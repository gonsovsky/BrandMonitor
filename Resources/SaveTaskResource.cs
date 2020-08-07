using System.ComponentModel.DataAnnotations;

namespace BrandMonitor.API.Resources
{
    public class SaveTaskResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public short QuantityInPackage { get; set; }

        [Required]
        [Range(1, 5)]
        public int UnitOfMeasurement { get; set; } // AutoMapper is going to cast it to the respective enum value
       
    }
}