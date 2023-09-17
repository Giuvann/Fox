namespace DB_Test_Fox.StartUp
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RebasedDbFirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        AccomodationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AccomodationId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        RoomTypeId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        AccomodationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomTypeId)
                .ForeignKey("dbo.Accomodations", t => t.AccomodationId, cascadeDelete: true)
                .Index(t => t.AccomodationId);
            
            CreateTable(
                "dbo.PriceLists",
                c => new
                    {
                        PriceListId = c.Int(nullable: false, identity: true),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        RoomTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriceListId)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceLists", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomTypes", "AccomodationId", "dbo.Accomodations");
            DropIndex("dbo.PriceLists", new[] { "RoomTypeId" });
            DropIndex("dbo.RoomTypes", new[] { "AccomodationId" });
            DropTable("dbo.PriceLists");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Accomodations");
        }
    }
}
