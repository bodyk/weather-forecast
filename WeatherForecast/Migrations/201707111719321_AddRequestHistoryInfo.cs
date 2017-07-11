namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequestHistoryInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RequestHistoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.WeatherEntities", "RequestHistoryEntity_Id", c => c.Int());
            CreateIndex("dbo.WeatherEntities", "RequestHistoryEntity_Id");
            AddForeignKey("dbo.WeatherEntities", "RequestHistoryEntity_Id", "dbo.RequestHistoryEntities", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeatherEntities", "RequestHistoryEntity_Id", "dbo.RequestHistoryEntities");
            DropIndex("dbo.WeatherEntities", new[] { "RequestHistoryEntity_Id" });
            DropColumn("dbo.WeatherEntities", "RequestHistoryEntity_Id");
            DropTable("dbo.RequestHistoryEntities");
        }
    }
}
