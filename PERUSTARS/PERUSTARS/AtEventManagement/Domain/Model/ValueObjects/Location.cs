namespace PERUSTARS.AtEventManagement.Domain.Model.ValueObjects
{
    public class Location
    {
        public string Country { get; set; }
        public string City { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set;}
        public Location(string country, string city, decimal? latitude, decimal? longitude)
        {
            Country = country;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
