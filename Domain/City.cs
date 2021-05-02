using System.Collections.Generic;

namespace Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }    
    }
}