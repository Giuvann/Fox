namespace DB_Test_Fox.StartUp
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbColumns : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PriceLists", "AccomodationId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PriceLists", "AccomodationId");
        }
    }
}
