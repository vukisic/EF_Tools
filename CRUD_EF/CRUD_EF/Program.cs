using CRUD_EF.Access;
using CRUD_EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            AppPersonRepository repo = new AppPersonRepository();

            var list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            Person p1 = new Person()
            {
                FirstName = "Michael",
                LastName = "Jordan",
                Address = "None",
                DateOfBirth = new DateTime(1985, 7, 7)
            };

            if(repo.Add(p1))
                Console.WriteLine("Added!");
            else
                Console.WriteLine("NotAdded");

            list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            if (repo.Add(p1))
                Console.WriteLine("Added!");
            else
                Console.WriteLine("NotAdded");

            list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            var uk = repo.ReadOne("Vuk", "Isic");

            if(repo.Delete(uk.Id))
                Console.WriteLine("Deleted!");
            else
                Console.WriteLine("Not Deleted!");

            list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            var mj = repo.ReadOne("Michael", "Jordan");
            mj.LastName = "JORDAN";
            repo.Update(mj.Id, mj);

            list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            repo.Update(150,new Person() { Address = "None", DateOfBirth = new DateTime(1977, 8, 8), FirstName = "Emre", LastName = "Lukaku" });

            list = repo.ReadAll();
            foreach (var item in list)
            {
                Console.WriteLine($"{item.FirstName}  {item.LastName}  {item.Address}  {item.DateOfBirth.Date}");
            }

            Console.ReadLine();
        }
    }
}
