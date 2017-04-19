namespace CaWe.DB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CaWe.DB.Repository>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CaWe.DB.Repository context)
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
                new Entities.User() { Email = "admin@gmail.com", UserId = "123456789", Pass = "AD4itDLaHs0OgLhVrDZGNA7RDCG8QrX0R+GXvIVL3UtB6ueF9w2nD/05QKiK1S9Ctg==" }
                );

            context.Roles.AddOrUpdate(
                 new Entities.Role() { RoleId = "1", Name = "admin", Description = "zestoki momak" }
                );

            context.UserRoles.AddOrUpdate(
                new Entities.UserRole() { UserId = "123456789", RoleId = "1", UserRoleId = "1111" });

        }
    }
}
