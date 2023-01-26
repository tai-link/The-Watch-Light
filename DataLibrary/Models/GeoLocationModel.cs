namespace DataLibrary.Models
{
    public class GeoLocationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}