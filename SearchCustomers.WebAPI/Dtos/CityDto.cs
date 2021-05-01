namespace SearchCustomers.WebAPI.Dtos
{
    public class CityDto
    {
        public string Name;
        public RegionDto Region { get; set; }
    }
}