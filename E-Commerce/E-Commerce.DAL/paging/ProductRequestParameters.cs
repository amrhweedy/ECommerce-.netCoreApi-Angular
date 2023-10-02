using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.paging;

public class ProductRequestParameters : RequestParameters
{
    public string? Name { get; set; }

    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }


    public string ? BrandName { get; set; }

    public string? CategoryName { get; set; }

    public string? SearchBy { get; set; }

    public string? SearchString { get;set; }

   
}
