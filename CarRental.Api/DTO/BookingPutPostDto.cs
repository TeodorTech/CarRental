namespace CarRental.Api.DTO
{
    public class BookingPutPostDto
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarMake { get; set; }
        public string TotalCost { get; set; }
    }
}
