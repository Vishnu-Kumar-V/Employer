namespace Employer.Migrations
{
    using Employer.Data;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Employer.Data.EmployerDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(Employer.Data.EmployerDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Departments.AddOrUpdate(
                d => d.DepartmentName, MockData.getDepartments().ToArray());
            context.SaveChanges();

            context.Employees.AddOrUpdate(
                e => new { e.EmployeeName, e.CreatedDate }, MockData.getEmployees(context).ToArray());
            context.SaveChanges();
        }
    }
}
