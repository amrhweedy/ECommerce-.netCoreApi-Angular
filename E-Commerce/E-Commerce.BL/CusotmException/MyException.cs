using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.CusotmException;

public  class MyException : Exception
{
    public int statusCode { get; set; }

    public MyException(string message , int statuscode) : base(message)
    {
        statusCode = statuscode;   
    }
}
