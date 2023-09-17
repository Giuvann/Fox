using System.Data.Entity.Migrations;

namespace DB_Test_Fox.StartUp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new DBConfiguration();
            var migrator = new DbMigrator(configuration);

            Console.WriteLine("Applying pending migrations...");
            migrator.Update();

            Console.WriteLine("Migrations applied successfully.");
        }
    }
}