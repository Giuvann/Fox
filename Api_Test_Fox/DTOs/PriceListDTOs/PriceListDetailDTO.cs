namespace Api_Test_Fox.DTOs.PriceListDtos
{
    public class PriceListDetailDTO
    {
        public int PriceListId { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public int RoomTypeId { get; set; }
    }
}