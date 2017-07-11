namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTables : DbMigration
    {
        public override void Up()
        {
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
                        WeatherEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WeatherEntities", t => t.WeatherEntity_Id)
                .Index(t => t.WeatherEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SingleDayInfoEntities", "WeatherEntity_Id", "dbo.WeatherEntities");
            DropIndex("dbo.SingleDayInfoEntities", new[] { "WeatherEntity_Id" });
            DropTable("dbo.SingleDayInfoEntities");
            DropTable("dbo.WeatherEntities");
        }
    }
}
