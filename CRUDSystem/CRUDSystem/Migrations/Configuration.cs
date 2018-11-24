namespace CRUDSystem.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUDSystem.Models.MyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUDSystem.Models.MyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            IList<Detail> defaultDetail = new List<Detail>();

            defaultDetail.Add(new Detail() { Fname = "Harry1", Address = "Secret Address1 ", Age = 20, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { Fname = "Harry2", Address = "Secret Address2 ", Age = 21, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { Fname = "Harry3", Address = "Secret Address3 ", Age = 22, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { Fname = "Harry1", Lname = "Secre 1t", Address = "Secret Address1 ", Age = 20, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { Fname = "Harry2", Lname = "Secre 2t", Address = "Secret Address2 ", Age = 21, DOB = DateTime.Now });
            defaultDetail.Add(new Detail() { Fname = "Harry3", Lname = "Secre 3t", Address = "Secret Address3 ", Age = 22, DOB = DateTime.Now });

            foreach (Detail std in defaultDetail)
                context.Details.Add(std);

            base.Seed(context);
        }
    }
}
