namespace PeugeotWorkFlow.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PeugeotWorkFlow.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //AutomaticMigrationsEnabled = true; :migration automatique 
        }

        protected override void Seed(PeugeotWorkFlow.Models.ApplicationDbContext context)
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

            context.Roles.AddOrUpdate(
                r => r.Name,
                new IdentityRole { Name = "Responsable Achat" },
                new IdentityRole { Name = "Decideur" },
                new IdentityRole { Name = "Demandeur" }
                );
        }
    }
}
