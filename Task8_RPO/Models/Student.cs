using System;
namespace Task8_RPO.Models
{
    public class Student : IEntity

    {
        public int rollNo { get; set; }
        public string Name { get; set; }
        public string classSection { get; set; }

        public double markPercentage { get; set; }
        
    }
}
