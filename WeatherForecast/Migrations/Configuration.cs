using System.Data.Entity.Migrations;
using WeatherForecast.Models.Implementations;

namespace WeatherForecast.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<WeatherContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "WeatherForecast.Models.WeatherContext";
        }

        protected override void Seed(WeatherContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}