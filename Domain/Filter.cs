using System;

namespace Domain
{
    public class Filter
    {
        public int? CityId { get; set; }
        public int? GenderId { get; set; }

        public int? ClassificationId { get; set; }

        public int? SellerId { get; set; }

        public string Name { get; set; }

        public int? RegionId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }   
        
        public int? UserId { get; set; }
    }
}