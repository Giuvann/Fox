namespace DB_Test_Fox.StartUp
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRoomPricesKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.RoomPrices");
            AddColumn("dbo.RoomPrices", "RoomPricesId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.RoomPrices", "RoomPricesId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.RoomPrices");
            DropColumn("dbo.RoomPrices", "RoomPricesId");
            AddPrimaryKey("dbo.RoomPrices", new[] { "AccomodationId", "RoomTypeId" });
        }
    }
}
