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
            //  ProductTest();
           //   CategoryTest();

        }



        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var cateogory in categoryManager.GetAll())
            {
                Console.WriteLine(cateogory.CategoryName);
            }
        }
        private static void ProductTest()
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
        }
    }
}
