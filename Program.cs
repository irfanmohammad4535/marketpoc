using System;
public class Market
{
    public static void Main(string[] args)
    {

        Dictionary<string, double> final_cart = new Dictionary<string, double>();

        Dictionary<string, double> shop_items = new Dictionary<string, double>

            {

                { "CH1", 3.11 },

                { "AP1", 6.00 },

                { "CF1", 11.23 },

                { "MK1", 4.75 },

                { "OM1", 3.69 }

            };

        Console.WriteLine("Product Codes for items : \n Chai : CH1 \n Apples : AP1 \n Coffee : CF1 \n Milk : MK1 \n Oatmeal : OM1");

        Console.WriteLine("Items wanted to buy: ");

        int apples = 0;

        int coffee = 0;

        double apple_discount = 0;

        double chai_discount = 0;

        string[] cart_items = Console.ReadLine().ToUpper().Split(",");

        if (cart_items.All(item => shop_items.ContainsKey(item.Trim())))

        {

            foreach (string item in cart_items)

            {

                if (item == "AP1")

                    apples++;

                if (item == "CF1")

                    coffee++;


                if (!final_cart.ContainsKey(item))

                    final_cart.Add(item, shop_items[item]);

                else

                    final_cart[item] = final_cart[item] + shop_items[item];


            }

            if (coffee > 1)

            {

                int fullPriceItems = coffee / 2; // Number of items that are not part of the offer

                int freeItems = coffee - fullPriceItems; // Number of items eligible for the offer

                final_cart["CF1"] = fullPriceItems * shop_items["CF1"];

                // If there are free items, update the total cost accordingly

                if (freeItems > 0)

                {

                    final_cart["CF1"] += (freeItems / 2) * shop_items["CF1"]; // Calculate cost for free items

                }

            }

            if (cart_items.Contains("AP1"))

            {

                if (apples >= 3)

                    apple_discount = apple_discount + (1.5 * apples);

                final_cart["AP1"] = final_cart["AP1"] - apple_discount;

            }

            if (cart_items.Contains("CH1") && cart_items.Contains("MK1"))

                chai_discount = chai_discount + 4.75;

            if (cart_items.Contains("OM1"))

                final_cart["AP1"] = final_cart["AP1"] - (final_cart["AP1"] * 0.5);

            double final_price = final_cart.Values.Sum() - chai_discount;

            Console.WriteLine("Basket : " + String.Join(",", cart_items));

            Console.WriteLine("Total price estimated :$" + final_price);

        }

        else

        {

            Console.WriteLine("Add items only from the list");

        }

    }
}