using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_framework
{
    class Program
    {
        static void Main(string[] args)
        {
            using(NorthwindEntities ef = new NorthwindEntities())
            {
                foreach (Category c in ef.Categories)
                {
                    foreach (Product p in c.Products.Where(p=>p.ProductName.Length == c.CategoryName.Length))
                    {
                        Console.WriteLine($"ProductName: {p.ProductName} | CategoryName: {c.CategoryName}");

                        Console.WriteLine($"UnitPrice befor discount: {p.UnitPrice}");

                        p.UnitPrice = p.UnitPrice * (decimal)0.9;

                        Console.WriteLine($"UnitPrice after discount 10%: {p.UnitPrice}");

                        Console.WriteLine("__________________________________________________________");

                        
                    }
                }

                ef.SaveChanges();
            }
        }
    }
}
