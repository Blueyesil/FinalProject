﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
        // iş kodları yazılır.
        
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            // Hiç bir sınıf içinde bir sınıf new lenmez. Constructor injection yapılır.
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            // Yetkisi sorgulanır.
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
