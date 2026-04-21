using System.ComponentModel.DataAnnotations;

namespace Task10_Mini_Microservice.server.Models
{
    public class Student
    {
        [Key]
        public int rollNo { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string classSection { get; set; }

        [Range(0, 100)]
        public double markPercentage { get; set; }
    }
}