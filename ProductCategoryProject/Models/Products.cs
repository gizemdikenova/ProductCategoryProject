using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCategoryProject.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public Categories Category { get; set; } 
    }
}
