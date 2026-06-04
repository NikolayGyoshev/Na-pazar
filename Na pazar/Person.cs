using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Na_pazar
{
    internal class Person
    {
        private string name;
        private decimal money;
        private List<string> bag;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public decimal Money
        {
            get { return money; }
            set { money = value; }
        }

        // Свойство Simpler Bag: връща копие като string[] 
        public string[] Bag
        {
            get { return bag.ToArray(); }
        }

        public Person(string name, decimal money)
        {
            this.name = name;
            this.money = money;
            this.bag = new List<string>();
        }


        public string BuyProduct(Product product)
        {
            if (product.Cost <= money)
            {
                money -= product.Cost;
                bag.Add(product.Name);
                return name + " bought " + product.Name;
            }
            else
            {
                return name + " can't afford " + product.Name;
            }
        }

        public string PurchasesSummary()
        {
            if (bag.Count == 0)
                return "Nothing bought";

            string result = "";
            for (int i = 0; i < bag.Count; i++)
            {
                if (i > 0)
                    result += ", ";
                result += bag[i];
            }
            return result;
        }
    }
}

