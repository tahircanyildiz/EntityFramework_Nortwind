using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            EfProductDal efProductDal = new EfProductDal();
            ProductManager productManager = new ProductManager(efProductDal);

            for (int i = 0; i < 5; i++)
            {
                foreach (var product in productManager.GetAllByCategoryId(i))
                {
                    Console.WriteLine(product.CategoryId + " " + product.ProductName);
                }
            }
            


            Console.WriteLine("Hello World!");
        }
    }
}
