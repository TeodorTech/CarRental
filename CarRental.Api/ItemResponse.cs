namespace CarRental.Api
{
    public class ItemResponse<T>
    {
       public List<T> Items { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
