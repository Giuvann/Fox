using Microsoft.Extensions.Configuration;
using System.Data.Entity;

namespace DB_Test_Fox.Models
{
    public class BookingContext : DbContext
    {
        public BookingContext(string? v) : base(GetConnectionString())
        {

        }

        public BookingContext() : base(GetConnectionString())
        {

        }

        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<PriceList> PriceList { get; set; }


        private static string GetConnectionString()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration.GetConnectionString("DB_Fox_Connection");
        }
    }
}
