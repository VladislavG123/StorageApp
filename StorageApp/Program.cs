using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageApp
{

    class Program
    {
        // Max int value
        public static int IntParser(int from, int to = 2147483647)
        {
            int result;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out result) && result >= from && result <= to)
                {
                    return result;
                }
            }
        }

        static void Main(string[] args)
        {
            using (var context = new AppContext())
            {
                int chouse;
                while (true)
                {
                    Console.WriteLine("1 - Add");
                    Console.WriteLine("2 - Change");
                    Console.WriteLine("3 - Delete ");
                    Console.WriteLine("4 - Exit");
                    chouse = IntParser(1, 4);
                    if (chouse == 1)
                    {
                        Product product = new Product();
                        Console.WriteLine("Enter the name of product");
                        product.Name = Console.ReadLine();

                        Console.WriteLine("Enter weight");
                        product.Weight = IntParser(0);

                        product.ArrivalDate = DateTime.Now;
                        try
                        {
                            context.Products.Add(product);
                            context.SaveChanges();
                            Console.WriteLine("Adding successful!");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error");
                        }

                    }
                    else if (chouse == 2)
                    {
                        while (true)
                        {
                            int productId = 1;
                            foreach (var product in context.Products)
                            {
                                Console.WriteLine("Id = " + productId);
                                Console.WriteLine("Name - " + product.Name);
                                Console.WriteLine("Weight - " + product.Weight);
                                Console.WriteLine("Arrival Date - " + product.ArrivalDate.ToString());
                                Console.WriteLine();
                                productId++;
                            }
                            Console.WriteLine("Enter product Id");
                            Console.WriteLine("For Exit enter 0");
                            int selectedProduct = IntParser(0, productId);

                            if (selectedProduct == 0) break;

                            Product newProduct = new Product();

                            Console.WriteLine("Enter the name of product");
                            newProduct.Name = Console.ReadLine();

                            Console.WriteLine("Enter weight");
                            newProduct.Weight = IntParser(0);

                            productId = 1;
                            // заменить на фор

                            for (int i = 0; i < context.Products.Count(); i++)
                            {
                                if (selectedProduct == productId)
                                {
                                    context.Products.ToList()[i].Name = newProduct.Name;
                                    context.Products.ToList()[i].Weight = newProduct.Weight;

                                    context.SaveChanges();

                                    Console.WriteLine("Product was changed");
                                    break;
                                }
                                productId++;
                            }
                            
                            break;
                        }
                    }
                    else if (chouse == 3)
                    {
                        while (true)
                        {
                            int productId = 1;
                            foreach (var product in context.Products)
                            {
                                Console.WriteLine("Id = " + productId);
                                Console.WriteLine("Name - " + product.Name);
                                Console.WriteLine("Weight - " + product.Weight);
                                Console.WriteLine("Arrival Date - " + product.ArrivalDate.ToString());
                                Console.WriteLine();
                                productId++;
                            }
                            Console.WriteLine("Enter product Id");
                            Console.WriteLine("For Exit enter 0");
                            int selectedProduct = IntParser(0, productId);

                            if (selectedProduct == 0) break;
                            
                            Product deletedProduct = new Product();

                            productId = 1;
                            foreach (var product in context.Products)
                            {
                                if (selectedProduct == productId)
                                {
                                    deletedProduct = product;
                                    break;
                                }
                                productId++;
                            }

                            context.Products.Remove(deletedProduct);
                            context.SaveChanges();

                            Console.WriteLine("Product was deleted");
                            break;
                        }
                    }
                    else break;
                }
            }
        }
    }
}
