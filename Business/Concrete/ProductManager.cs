using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length<2)
            {
                return new ErrorResult("Ürün ismi en az 2 karakter olmalidir");
            }
            else
            {
                _productDal.Add(product);
                return new SuccessResult("Ürün eklendi.");
            }
        }

        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>("Bakim zamani oldugu icin listelenemiyor"); ;
            }
            else
            {
                return new SuccessDataResult<List<Product>>(_productDal.GetAll(), "Urunler listelendi.");
            }
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult < Product > (_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),"Fiyat araligina gore listelendi");
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDal.GetProductDetails(),"Urun detayi listelendi.");
        }
    }
}
