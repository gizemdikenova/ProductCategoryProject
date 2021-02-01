using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductCategoryProject.Models;

namespace ProductCategoryProject.Data
{
    public class PCDbContext : DbContext
    {
        public PCDbContext()
        {

        }
        public PCDbContext(DbContextOptions<PCDbContext> options) : base(options)
        {

        }
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                        .HasMany(x => x.Products)
                        .WithOne(z => z.Category)
                        .HasForeignKey(y => y.CategoryId);
            // 2 kategori arasındaki tüm ilişki burada kuruldu.

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLOCALDB; Database=ProCatDb; Integrated Security=true");
            }

        }
    }

}
