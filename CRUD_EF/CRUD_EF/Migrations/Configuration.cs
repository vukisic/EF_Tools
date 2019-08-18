namespace CRUD_EF.Migrations
{
    using CRUD_EF.Model;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUD_EF.Model.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUD_EF.Model.AppDbContext context)
        {
            if(context.Persons.Count()==0)
            {
                IList<Person> persons = new List<Person>();
                persons.Add(new Person() { FirstName = "Vuk", LastName = "Isic", Address = "VladeDanilovica 1/1", DateOfBirth = new DateTime(1997, 10, 26) });
                persons.Add(new Person() { FirstName = "Billy", LastName = "Bilook", Address = "CrockerStreet", DateOfBirth = new DateTime(1977, 11, 2) });
                persons.Add(new Person() { FirstName = "Mike", LastName = "Smith", Address = "ShStreet", DateOfBirth = new DateTime(1988, 1, 6) });

                foreach (var item in persons)
                {
                    context.Persons.Add(item);
                }
                base.Seed(context);

            }
            
        }
    }
}
