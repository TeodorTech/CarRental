namespace CarRental.Api.DTO
{
    public class BookingPutPostDto
    {
        public int CarId { get; set; }
        public int UserId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
