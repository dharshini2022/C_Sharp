using System;
using System.ComponentModel.DataAnnotations;

namespace Task10_Mini_Microservice.server.Models
{
    public class Student

    {
        [Key]
        public int rollNo { get; set; }
        public string Name { get; set; }
        public string classSection { get; set; }

        public double markPercentage { get; set; }
        
    }
}
