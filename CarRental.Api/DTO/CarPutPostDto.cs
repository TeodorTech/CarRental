namespace CarRental.Api.DTO
{
    public class CarPutPostDto
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public float PricePerDay { get; set; }
        public string ImageLink { get; set; }
    }
}
