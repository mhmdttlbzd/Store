using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    internal class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
    }
}
