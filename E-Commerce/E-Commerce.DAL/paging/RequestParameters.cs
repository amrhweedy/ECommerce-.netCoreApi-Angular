using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.paging
{
      public  class RequestParameters
    {
        const int maxPageSize = 10;
        public int pageNumber { get; set; } = 1;

        private int pageSize;

        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
