namespace DB_Test_Fox.Models
{
    public class Accomodation
    {
        public int AccomodationId { get; set; }
        public string Name { get; set; }
        public List<RoomType> RoomTypes { get; set; }
    }
}