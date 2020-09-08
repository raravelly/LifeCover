using System;

namespace LifeCover.Api.Models
{
    public class LifePremiumModel
    {
        public string Name { get; set; }
        public int? Age { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Occupation { get; set; }
        public long SumInsured { get; set; }
    }
}
