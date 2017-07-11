namespace WeatherForecast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendSingleDayInfoEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SingleDayInfoEntities", "Date", c => c.String());
            AddColumn("dbo.SingleDayInfoEntities", "IconPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SingleDayInfoEntities", "IconPath");
            DropColumn("dbo.SingleDayInfoEntities", "Date");
        }
    }
}
