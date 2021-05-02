using System;
using Domain;

namespace WebAPI.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public CityDto City { get; set; }
        public RegionDto Region { get; set; }
        public int UserId { get; set; }
        public GenderDto Gender { get; set; }
        public ClassificationDto Classification { get; set; }
    }
}