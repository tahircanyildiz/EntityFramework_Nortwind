using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        //DTO Data Transformation Object
        static void Main(string[] args)
        {
              ProductTest();
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
           
            ProductManager productManager = new ProductManager(new EfProductDal());

                foreach (var product in productManager.GetProductDetails().Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                }
            }
        }
    }

