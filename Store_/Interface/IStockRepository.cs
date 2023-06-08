using Store.Domain;
using Store_.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Interface
{
    public interface IStockRepository
    {
        string SaleProduct(int productId, int cnt); 
        string BuyProduct(Stock productInStock); 
        List<SaleProductViewModel> GetSalesProductList();
        List<SockProductViewModel> GetStockProductList();
    }
}
