using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.paging;

public class UserRequestParameters : RequestParameters
{
    public string? SearchBy { get; set; }

    public string? SearchString { get; set; }
}
