﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public string ProductId { get; set; }
        public string ProductQuantity { get; set; }
        public string ProductPrice { get; set; }
    }
}
