using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models
{
    public  class Category
    {
        public int Id { get; set; }


        [StringLength(20, MinimumLength = 2, ErrorMessage = "{0} must be between {2} and {1}")]
        public string Name { get; set; }=string.Empty;

        public ICollection<Product>? Products { get; set; } 
    }
}
