using E_Commerce.DAL.models.order;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models
{
    public class ApplicationUser : IdentityUser
    {


        public string RegisterdDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        public IEnumerable<Order> Orders { get; set; }   = new List<Order>();   
    }
}
