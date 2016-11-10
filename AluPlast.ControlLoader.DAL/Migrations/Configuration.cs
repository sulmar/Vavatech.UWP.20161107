namespace AluPlast.ControlLoader.DAL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AluPlast.ControlLoader.DAL.AluPlastContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "AluPlast.ControlLoader.DAL.AluPlastContext";
        }

        protected override void Seed(AluPlast.ControlLoader.DAL.AluPlastContext context)
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

            context.Users.AddOrUpdate(
              p => p.FirstName,
              new User { FirstName = "Marcin", LastName = "Sulecki" },
              new User { FirstName = "Maciej" },
              new User { FirstName = "Micha³" }
            );



            context.Loads.AddOrUpdate(
                p => p.LoadDate,
                    new Load { LoadDate = DateTime.Today, LoadStatus = LoadStatus.InProgress }
                );
        }
    }
}
