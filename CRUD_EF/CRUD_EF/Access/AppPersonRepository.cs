using CRUD_EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EF.Access
{
    public class AppPersonRepository : IRepository<Person>
    {
        private AppDbContext context;

        public bool Add(Person item)
        {
            using(context = new AppDbContext())
            {
                var person = context.Persons.SingleOrDefault(x => x.FirstName == item.FirstName && x.LastName == item.LastName);
                if (person == null)
                {
                    context.Persons.Add(item);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Delete(long id)
        {
            using (context=new AppDbContext())
            {
                var person = context.Persons.SingleOrDefault(x => x.Id == id);
                if (person != null)
                {
                    context.Persons.Remove(person);
                    context.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool Exist(string credential1, string credential2)
        {
            using (context = new AppDbContext())
            {
                var person = context.Persons.SingleOrDefault(x => x.FirstName == credential1 && x.LastName == credential2);
                return person != null;
            }
        }

        public List<Person> ReadAll()
        {
            using (context=new AppDbContext())
            {
                return context.Persons.ToList<Person>();
            }
        }

        public Person ReadOne(long id)
        {
            using(context=new AppDbContext())
            {
                return context.Persons.SingleOrDefault(x => x.Id == id);
            }
        }

        public Person ReadOne(string credential1,string credential2)
        {
            using (context = new AppDbContext())
            {
                return context.Persons.SingleOrDefault(x=>x.FirstName==credential1 && x.LastName==credential2);
            }
        }

        public void Update(long id, Person newItem)
        {
            using (context = new AppDbContext())
            {
                var person = context.Persons.SingleOrDefault(x => x.Id==id);
                if (person == null)
                {
                    context.Persons.Add(newItem);
                    context.SaveChanges();
                }
                else
                {
                    person.Address = newItem.Address;
                    person.DateOfBirth = newItem.DateOfBirth;
                    person.FirstName = newItem.FirstName;
                    person.LastName = newItem.LastName;
                    context.SaveChanges();
                }
            }
        }
    }
}
