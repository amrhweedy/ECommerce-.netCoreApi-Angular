﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.DAL.models;

public  class CustomerBasket
{
    public string Id { get; set; }=string.Empty;

    public List<BasketItem> Items { get; set; } = new List<BasketItem>();


}
