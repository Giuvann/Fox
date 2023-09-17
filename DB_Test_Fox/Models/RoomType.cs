namespace DB_Test_Fox.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public string Type { get; set; }
        public int AccomodationId { get; set; }
        public List<PriceList> PriceLists { get; set; }
    }
}