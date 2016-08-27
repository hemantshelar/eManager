namespace eManager.Web.Migrations
{
    using eManager.Domain;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(
                    d => d.Name,
                    new Department { Name = "Engineering" },
                    new Department { Name = "Salse" },
                    new Department { Name = "Shipping"
                    });
        }
    }
}
