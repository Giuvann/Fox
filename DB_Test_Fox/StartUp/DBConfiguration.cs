using DB_Test_Fox.Models;
using System.Data.Entity.Migrations;

namespace DB_Test_Fox.StartUp
{
    internal sealed class DBConfiguration : DbMigrationsConfiguration<BookingContext>
    {
        public DBConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}
