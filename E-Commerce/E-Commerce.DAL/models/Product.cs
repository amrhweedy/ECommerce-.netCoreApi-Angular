using E_Commerce.DAL.models.order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models
{
    public  class Product
    {
        public int Id { get; set; }

        [StringLength(20 , MinimumLength =2, ErrorMessage ="{0} must be between {2} and {1}")]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public double Price { get; set; }

        public string Picture { get; set; }= string.Empty;

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }


        public IEnumerable<productedOrdered>   productedOrdereds { get; set; }  = new List<productedOrdered>(); 





    }
}
