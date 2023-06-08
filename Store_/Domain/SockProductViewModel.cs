using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_.Domain
{
    public class SockProductViewModel
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }
        public string Barcode { get; set; }
        public SockProductViewModel()
        {

        }
        public SockProductViewModel(int stockId,string name,int productId, int productQuantity,int productPrice,string barcode)
        {
            StockId = stockId;
            Name = name;
            ProductId = productId;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            Barcode = barcode;
        }
        public override string ToString()
        {
            return ProductId.ToString()+ " - "+ Name +" - "+ Barcode +" - "+ ProductPrice+" - "+ ProductQuantity;
        }
    }

}
