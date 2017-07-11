namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHistoryWithVirtual : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WeatherEntities", "RequestHistoryEntity_Id", "dbo.RequestHistoryEntities");
            DropIndex("dbo.WeatherEntities", new[] { "RequestHistoryEntity_Id" });
            RenameColumn(table: "dbo.WeatherEntities", name: "RequestHistoryEntity_Id", newName: "HistoryId");
            AlterColumn("dbo.WeatherEntities", "HistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.WeatherEntities", "HistoryId");
            AddForeignKey("dbo.WeatherEntities", "HistoryId", "dbo.RequestHistoryEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WeatherEntities", "HistoryId", "dbo.RequestHistoryEntities");
            DropIndex("dbo.WeatherEntities", new[] { "HistoryId" });
            AlterColumn("dbo.WeatherEntities", "HistoryId", c => c.Int());
            RenameColumn(table: "dbo.WeatherEntities", name: "HistoryId", newName: "RequestHistoryEntity_Id");
            CreateIndex("dbo.WeatherEntities", "RequestHistoryEntity_Id");
            AddForeignKey("dbo.WeatherEntities", "RequestHistoryEntity_Id", "dbo.RequestHistoryEntities", "Id");
        }
    }
}
