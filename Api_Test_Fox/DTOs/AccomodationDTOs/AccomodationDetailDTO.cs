using DB_Test_Fox.Models;

namespace Api_Test_Fox.DTOs.AccomodationDTOs
{
    public class AccomodationDetailDTO
    {
        public int AccomodationId { get; set; }
        public string? Name { get; set; }
        public List<RoomType>? RoomTypes { get; set; }
    }
}