using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na_pazar
{
    internal class Product
    {
        private string name;
        private decimal cost;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        // публичен конструктор, за да можете да използвате:
        // new Product(име, цена)
        public Product(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public void Info()
        {
            Console.WriteLine($"Product: {name}");
            Console.WriteLine($"Cost: {cost}");
        }
    }
}
