namespace Api_Test_Fox.DTOs.PriceListDTOs
{
    public class PriceListCreateDTO
    {
        public int AccomodationId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int RoomTypeId { get; set; }
    }
}