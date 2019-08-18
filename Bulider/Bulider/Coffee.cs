using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulider
{
    public class Coffee
    {
        private double basePrice = 10d;

        public double Price { get; set; }


        public Coffee()
        {
            Price = basePrice;
        }

        public Coffee AddMilk()
        {
            Price += 5;
            return this;
        }

        public Coffee AddCream()
        {
            Price += 10;
            return this;
        }

        public Coffee AddSugar()
        {
            Price += 5;
            return this;
        }
    }
}
