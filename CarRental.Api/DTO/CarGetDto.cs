namespace CarRental.Api.DTO
{
    public class CarGetDto
    {
        public string Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float PricePerDay { get; set; }
    }
}
