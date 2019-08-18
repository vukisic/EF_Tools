using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulider
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee().AddCream().AddSugar();

            Console.WriteLine($"Total Price: {coffee.Price}");

            Console.ReadLine();
        }
    }
}
