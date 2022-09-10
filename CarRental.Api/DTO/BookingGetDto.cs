namespace CarRental.Api.DTO
{
    public class BookingGetDto
    {
        public int BookingId { get; set; }
        public int CarId { get; set; }
        public int UserId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
