namespace DB_Test_Fox.StartUp
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        AccomodationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.AccomodationId);
            
            CreateTable(
                "dbo.RoomPrices",
                c => new
                    {
                        AccomodationId = c.Int(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.AccomodationId, t.RoomTypeId })
                .ForeignKey("dbo.Accomodations", t => t.AccomodationId, cascadeDelete: true)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.AccomodationId)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.RoomTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomPrices", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomPrices", "AccomodationId", "dbo.Accomodations");
            DropIndex("dbo.RoomPrices", new[] { "RoomTypeId" });
            DropIndex("dbo.RoomPrices", new[] { "AccomodationId" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.RoomPrices");
            DropTable("dbo.Accomodations");
        }
    }
}
