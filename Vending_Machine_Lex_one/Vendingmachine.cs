using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Vending_Machine_Lex_one
{
    public class Vendingmachine:Ivending
    {
        List<Sharedinfo> CustomerItem;
        List<Sharedinfo> foodsAndDrinks;
        public Dictionary<string, int> insertedMoney;
        public Vendingmachine()
        {

            CustomerItem = new List<Sharedinfo>();

            insertedMoney = new Dictionary<string, int>();
            insertedMoney.Add("1", 0);
            insertedMoney.Add("5", 0);
            insertedMoney.Add("10", 0);
            insertedMoney.Add("20", 0);
            insertedMoney.Add("50", 0);
            insertedMoney.Add("100", 0);
            insertedMoney.Add("200", 0);
            insertedMoney.Add("500", 0);
            insertedMoney.Add("1000", 0);

            foodsAndDrinks = new List<Sharedinfo>();
            foodsAndDrinks.Add(new Cola());
            foodsAndDrinks.Add(new Fanta());
            foodsAndDrinks.Add(new Sprite());
            foodsAndDrinks.Add(new EsterellaChips());
            foodsAndDrinks.Add(new Cheezdoodles());
            foodsAndDrinks.Add(new OnionFlavorring());
            foodsAndDrinks.Add(new ChokladMerci());
            foodsAndDrinks.Add(new Twix());
            foodsAndDrinks.Add(new Marabou());
        }
        public void StartMenu()
        {
            while (true)
            {
                Console.Clear();

                ExamineAll();
                Console.WriteLine($"Money available to buy: {AvailableMoneyToPurchase()}");

                Console.WriteLine("please select what you wish to do: (1- purchase, 2-to show all , 3-insert money,4- end trasaction , 5-to exit)");

                string state = Console.ReadLine();

                switch (state)
                {
                    case "1":
                        Purchase();
                        break;
                    case "2":


                        ShowAll();
                        break;
                    case "3":
                        InsertMoney();
                        break;
                    case "4":
                        EndTransaction();
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid request");
                        break;
                }

                Console.ReadKey();
            }


        }


        //constructor 

        //insert to by from vm
        public void InsertMoney()
        {
            Console.WriteLine("Insert Money(1, 5, 10, 20, 50, 100, 200, 500, 1000)");
            string amount = Console.ReadLine();

            if (insertedMoney.ContainsKey(amount))
                insertedMoney[amount]++;
            else
                Console.WriteLine("Insert a valid amount.");
        }
        //SHOW THE VEDING MACHIN PRODUCTS
        public void ShowAll()
        {
            for (int i = 0; i < CustomerItem.Count; i++)
            {
                Console.WriteLine($"Name: {CustomerItem[i].Name} is it Sold out or empty: {CustomerItem[i].IsUsed}");
            }
        }
        //purchase -select producto
        public void Purchase()
        {
            Console.Write("Enter product or id: ");
            string item = Console.ReadLine();
            Sharedinfo product = null;

            if (foodsAndDrinks.Exists(x => x.Name == item))
            {
                product = foodsAndDrinks.Find(x => x.Name == item).GetNewItem();
            }
            else
            {
                int id = -1;
                int.TryParse(item, out id);

                if (id > 0)
                    product = foodsAndDrinks[id - 1].GetNewItem();
            }

            if (product == null)
            {
                Console.WriteLine("Item with that name dont exist");
            }
            else if (AvailableMoneyToPurchase() >= product.Price)
            {
                BuyAndGetChange(product.Price);
                ItemToInventory(product);
                Console.WriteLine($"You bought a {product.Name} for {product.Price}crowns");
            }
            else if (AvailableMoneyToPurchase() < product.Price)
            {
                Console.WriteLine("Not enough money in machine");
            }

        }
        private void Use()
        {
            Console.WriteLine("Choose product to Use");
            ShowYourProducts();
            string item = Console.ReadLine();
            int itemId;
            int.TryParse(item, out itemId);

            CustomerItem[itemId - 1].Use();
        }
        private void BuyAndGetChange(int Price)
        {
            int tempValue = 0;
            string[] keys = new string[] { "1", "5", "10", "20", "50", "100", "200", "500", "1000" };
            int[] reversedKeys = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };
            var inserted = insertedMoney.OrderBy(x => int.Parse(x.Key));

            while (Price <= AvailableMoneyToPurchase() && tempValue < Price)
            {
                foreach (KeyValuePair<string, int> pair in inserted)
                {
                    while (insertedMoney[pair.Key] > 0)
                    {
                        insertedMoney[pair.Key]--;
                        tempValue += int.Parse(pair.Key);
                    }
                }
            }

            tempValue -= Price;
            var reversed = insertedMoney.OrderByDescending(x => int.Parse(x.Key));

            while (tempValue > 0)
            {
                foreach (KeyValuePair<string, int> pair in reversed)
                {
                    while (tempValue >= int.Parse(pair.Key))
                    {
                        insertedMoney[pair.Key]++;
                        tempValue -= int.Parse(pair.Key); ;
                    }
                }
            }
        }
        private void GetMoneyBack()
        {
            int total = AvailableMoneyToPurchase();
            Dictionary<string, int> temp = new Dictionary<string, int>(insertedMoney);
            foreach (KeyValuePair<string, int> pair in temp)
            {

                while (insertedMoney[pair.Key] > 0)
                {
                    Console.WriteLine($"Machine returned {pair.Key}crown");
                    insertedMoney[pair.Key]--;
                }
            }
            Console.WriteLine($"The vending machine returned a total of {total}");
        }
        private void ItemToInventory(Sharedinfo product)
        {
            CustomerItem.Add(product);
        }
        public void CalculateChange(int price)
        {
            int tempValue = 0;
            string[] keys = new string[] { "1", "5", "10", "20", "50", "100", "200", "500", "1000" };
            int[] reversedKeys = new int[] { 1000, 500, 200, 100, 50, 20, 10, 5, 1 };
            var inserted = insertedMoney.OrderBy(x => int.Parse(x.Key));

            while (price <= AvailableMoneyToPurchase() && tempValue < price)
            {
                foreach (KeyValuePair<string, int> pair in inserted)
                {
                    while (insertedMoney[pair.Key] > 0)
                    {
                        insertedMoney[pair.Key]--;
                        tempValue += int.Parse(pair.Key);
                    }
                }
            }
            tempValue -= price;
            var reversed = insertedMoney.OrderByDescending(x => int.Parse(x.Key));

            while (tempValue > 0)
            {
                foreach (KeyValuePair<string, int> pair in reversed)
                {
                    while (tempValue >= int.Parse(pair.Key))
                    {
                        insertedMoney[pair.Key]++;
                        tempValue -= int.Parse(pair.Key); ;
                    }
                }
            }
            //InsertMoney --enter the right denomination 

        }
        //your change 
        public void EndTransaction()
        {
            //check if the customer has a change to receive
            int total = AvailableMoneyToPurchase();
            Dictionary<string, int> temp = new Dictionary<string, int>(insertedMoney);
            foreach (KeyValuePair<string, int> pair in temp)
            {

                while (insertedMoney[pair.Key] > 0)
                {
                    Console.WriteLine($"Your change is  {pair.Key} SEk");
                    insertedMoney[pair.Key]--;
                }
            }
            Console.WriteLine($"The vending machine returned a total of {total}");
        }


        public void ExamineAll()
        {
            for (int i = 0; i < foodsAndDrinks.Count; i++)
            {
                Console.Write($" {i + 1}, ");
                foodsAndDrinks[i].Examine();

            }
        }
        public int AvailableMoneyToPurchase()
        {
            int total = 0;
            //check how much money the customer has to continue to buy ..
            foreach (KeyValuePair<string, int> pair in insertedMoney)
            {
                total += int.Parse(pair.Key) * pair.Value;
            }
            return total;

        }
        private void ShowYourProducts()
        {
            for (int i = 0; i < CustomerItem.Count; i++)
            {
                Console.WriteLine($"ID: {i + 1} Name: {CustomerItem[i].Name} IsEmpty: {CustomerItem[i].IsUsed}");
            }
        }

    }
}

