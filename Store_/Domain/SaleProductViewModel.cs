using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
    public class SaleProductViewModel
    {
        public string Name { get; private set; }
        public int ProductId { get; private set; }
        public int ProductQuantity { get; private set; }
        public int ProductPrice { get; private set; }
        public DateTime SaleDate { get;private set; }

        public SaleProductViewModel(string name , int productId,int productQuantity,int productPrice) 
        {
            Name = name;
            ProductId = productId;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
            SaleDate = DateTime.Now;
        }
        public SaleProductViewModel(string str)
        {
            string[] strArry = str.Split('-');
            Name = strArry[0];
            ProductId = int.Parse(strArry[1]);
            ProductQuantity = int.Parse(strArry[2]);
            ProductPrice = int.Parse(strArry[3]);
            SaleDate = Convert.ToDateTime(strArry[4]);
        }
        public override string ToString()
        {
            return Name + "-" + ProductId.ToString() + "-" + ProductQuantity.ToString() + "-" + ProductPrice.ToString() + "-" + SaleDate.ToString();
        }
        
    }
}
