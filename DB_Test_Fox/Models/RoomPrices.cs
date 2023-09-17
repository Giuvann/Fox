using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Test_Fox.Models
{
    public class RoomPrices
    {
        public int RoomPricesId { get; set; }
        public int AccomodationId { get; set; }
        public int RoomTypeId { get; set; }
        public decimal Price { get; set; }


        [ForeignKey("AccomodationId")]
        public virtual Accomodation Accomodation { get; set; }
        [ForeignKey("RoomTypeId")]
        public virtual RoomType RoomType { get; set; }
    }
}
