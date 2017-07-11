namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HistoryWithOneRequestInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RequestHistoryEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RequestTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeatherEntities", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.WeatherEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityName = c.String(),
                        CountryCode = c.String(),
                        CountForecastDays = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SingleDayInfoEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Temperature = c.String(),
                        Humidity = c.String(),
                        Pressure = c.String(),
                        WindSpeed = c.String(),
                        Clouds = c.String(),
                        Date = c.String(),
                        IconPath = c.String(),
                        WeatherEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeatherEntities", t => t.WeatherEntity_Id)
                .Index(t => t.WeatherEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RequestHistoryEntities", "Id", "dbo.WeatherEntities");
            DropForeignKey("dbo.SingleDayInfoEntities", "WeatherEntity_Id", "dbo.WeatherEntities");
            DropIndex("dbo.SingleDayInfoEntities", new[] { "WeatherEntity_Id" });
            DropIndex("dbo.RequestHistoryEntities", new[] { "Id" });
            DropTable("dbo.SingleDayInfoEntities");
            DropTable("dbo.WeatherEntities");
            DropTable("dbo.RequestHistoryEntities");
            DropTable("dbo.Cities");
        }
    }
}
