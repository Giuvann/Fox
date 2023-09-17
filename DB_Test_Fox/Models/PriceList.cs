namespace DB_Test_Fox.Models
{
    public class PriceList
    {
        public int PriceListId { get; set; }
        public int AccomodationId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int RoomTypeId { get; set; }
    }
}