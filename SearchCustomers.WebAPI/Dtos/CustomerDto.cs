using System;
using SearchCustomers.Domain;

namespace SearchCustomers.WebAPI.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public CityDto City { get; set; }
    }
}