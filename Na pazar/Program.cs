using System;
using System.Collections.Generic;
using System.Globalization;

namespace Na_pazar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // За --> "?? string.Empty;"
            // Четене на ред от конзолата. Ако ReadLine() върне null,
            // използваме празен низ.
            // '??' е операторът за обединяване на null: ляво, ако не е null,
            // в противен случай дясно.



            // прочитаме двата заглавни реда и всички команди до END
            string peopleLine = Console.ReadLine() ?? string.Empty;
            string productsLine = Console.ReadLine() ?? string.Empty;

            List<string> commandLines = new List<string>();
            while (true)
            {
                string line = Console.ReadLine() ?? string.Empty;
                commandLines.Add(line);
                if (line == "END") break;
            }

            // анализираме хората
            List<Person> people = new List<Person>();
            string[] peopleParts = peopleLine.Split(';');
            for (int i = 0; i < peopleParts.Length; i++)
            {
                string part = peopleParts[i];
                if (string.IsNullOrWhiteSpace(part)) continue;

                string[] kv = part.Split('=');
                if (kv.Length != 2) continue;

                string name = kv[0].Trim();
                string moneyText = kv[1].Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return;
                }

                decimal money = decimal.Parse(moneyText);
                if (money < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    return;
                }

                Person p = new Person(name, money);
                people.Add(p);
            }

            // анализира продукти
            List<Product> products = new List<Product>();
            string[] productParts = productsLine.Split(';');
            for (int i = 0; i < productParts.Length; i++)
            {
                string part = productParts[i];
                if (string.IsNullOrWhiteSpace(part)) continue;

                string[] kv = part.Split('=');
                if (kv.Length != 2) continue;

                string name = kv[0].Trim();
                string costText = kv[1].Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty");
                    return;
                }

                decimal cost = decimal.Parse(costText);
                if (cost < 0)
                {
                    Console.WriteLine("Money cannot be negative");
                    return;
                }

                Product prod = new Product(name, cost);
                products.Add(prod);
            }

            // обработва команди, събира изходни редове 
            List<string> outputs = new List<string>();
            for (int c = 0; c < commandLines.Count; c++)
            {
                string line = commandLines[c];
                if (line == "END") break;
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(' ');
                if (parts.Length < 2) continue;

                string buyerName = parts[0];
                string productName = parts[1];

                // намери купувача
                Person buyer = null;
                for (int i = 0; i < people.Count; i++)
                {
                    if (people[i].Name == buyerName)
                    {
                        buyer = people[i];
                        break;
                    }
                }
                if (buyer == null) continue;

                // намиране на продукт
                Product prod = null;
                for (int i = 0; i < products.Count; i++)
                {
                    if (products[i].Name == productName)
                    {
                        prod = products[i];
                        break;
                    }
                }
                if (prod == null) continue;

                // Използване на съобщението, върнато от BuyProduct
                string msg = buyer.BuyProduct(prod);
                outputs.Add(msg);
            }

            Console.WriteLine(" ");
             Console.WriteLine("----------~~~~~~~~----------");

            for (int i = 0; i < outputs.Count; i++)
            {
                Console.WriteLine(outputs[i]);
            }

            for (int i = 0; i < people.Count; i++)
            {
                Person p = people[i];
                Console.WriteLine(p.Name + " - " + p.PurchasesSummary());
            }
        }
    }
}
