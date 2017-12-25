using System;

namespace aprintist.Models
{
    public class Observation
    {
        public int ID { get; set; }
        public string Slicer { get; set; }
        public string Printer { get; set; }
        public TimeSpan Estimate { get; set; }
        public TimeSpan Actual { get; set; }
        
    }
}