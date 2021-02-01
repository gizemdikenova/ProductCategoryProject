using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategoryProject.Models;
using ProductCategoryProject.Data;

namespace ProductCategoryProject.Services
{
   public class ProductBusiness
    {
        PCDbContext dbContext = new PCDbContext();
        public List<Products> GetProducts()
        {
            return dbContext.Products.ToList();
        }
        public Products GetProductsById(int id)
        {
            return dbContext.Products.Find(id);
        }
        public void Add( Products products )
        {
            dbContext.Products.Add(products);
            dbContext.SaveChanges();

        }
        public void Remove(Products products) 
        {
            dbContext.Products.Remove(products);
            dbContext.SaveChanges();
         
        }
        public void Edit(Products products)
        {
            dbContext.Entry(products).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
