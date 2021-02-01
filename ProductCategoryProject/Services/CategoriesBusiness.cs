using System;
using ProductCategoryProject.Models;
using ProductCategoryProject.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategoryProject.Models;

namespace ProductCategoryProject.Services
{
    public class CategoriesBusiness
    {
        PCDbContext DbContext = new PCDbContext();
        public List<Categories> GetCategories() //Kategorileri listeler
        {
            return DbContext.Categories.ToList();
        }
        public Categories GetCategoriesById(int id) //id ile ürünü bul
        {
            return DbContext.Categories.Find(id);
        }
        public void Add(Categories categories)
        {
            DbContext.Categories.Add(categories);
            DbContext.SaveChanges();
        }

        public void Remove(Categories categories)
        {
            DbContext.Categories.Remove(categories);
            DbContext.SaveChanges();
        }
        public void Edit(Categories categories)
        {
            DbContext.Entry(categories).State =  Microsoft.EntityFrameworkCore.EntityState.Modified;
            DbContext.SaveChanges();
        }

    }
}
