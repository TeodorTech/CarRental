namespace CarRental.Api.DTO
{
    public class BookingPutPostDto
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
