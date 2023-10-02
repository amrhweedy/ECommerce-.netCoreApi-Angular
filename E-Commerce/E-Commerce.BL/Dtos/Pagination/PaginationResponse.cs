using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Dtos.Pagination;

public class PaginationResponse<T>
{
    public IEnumerable<T> Data { get; set; }= new List<T>();

    public int pageSize { get; set; }

    public int pageNumber { get; set; }

    public int totalItems { get; set; }

    
}
