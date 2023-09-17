using DB_Test_Fox.Models;

namespace Api_Test_Fox.DTOs.RoomTypeDTOs
{
    public class RoomTypeDetailDTO
    {
        public int RoomTypeId { get; set; }
        public string? Type { get; set; }
        public int AccomodationId { get; set; }
        public List<PriceList>? PriceLists { get; set; }
    }
}