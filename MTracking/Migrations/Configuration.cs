namespace MTracking.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MTracking.Models.MContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MTracking.Models.MContext";
        }

        protected override void Seed(MTracking.Models.MContext context)
        {
            context.Countries.AddOrUpdate(i => i.Name,
                new dic_Countries() { Name = "Ukraine" }
            );

            context.Statuses.AddOrUpdate(i => i.Status,
                new dic_Statuses() { Status = "Developer" },
                new dic_Statuses() { Status = "Tester" }
            );

            context.Companies.AddOrUpdate(i => i.Name,
                new Company() { Name = "None" }
            );

            context.BugStatuses.AddOrUpdate(i => i.Status,
                            new dic_BugStatuses() { Status = "New" },
                            new dic_BugStatuses() { Status = "Active" },
                            new dic_BugStatuses() { Status = "Resolved" },
                            new dic_BugStatuses() { Status = "Closed" }
                        );


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
