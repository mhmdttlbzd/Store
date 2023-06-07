using Store.Domain;
using Store.Interface;
using Store_.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Interface
{
    public class StockRepository : IStockRepository
    {
        private List<Stock> stocks;
        public StockRepository()
        {
            FileStream JsonProductFile = File.Open(@"..\Databas\StockJson.json", FileMode.OpenOrCreate);
            stocks = JsonSerializer.Deserialize<List<Stock>>(JsonProductFile);
            JsonProductFile.Close();
        }
        public string BuyProduct(Stock productInStock)
        {
            IProductRepository productRepository = new ProductRepository();
            bool ExistStock=false;
            foreach (var stock in stocks)
            {
                if (stock.StockId == productInStock.StockId)
                {
                    var price = (stock.ProductPrice * stock.ProductQuantity) + (productInStock.ProductPrice * productInStock.ProductQuantity);  
                    stock.ProductQuantity += productInStock.ProductQuantity;
                    stock.ProductPrice = price / stock.ProductQuantity;
                    ExistStock = true;
                }
            }
            if (!ExistStock)
            {
                stocks.Add(productInStock);
            }
            SaveChanges();
            return productRepository.GetProductById(productInStock.ProductId);
        }

        public List<SaleProductViewModel> GetSalesProductList()
        {
            List<SaleProductViewModel> sales = new List<SaleProductViewModel>();
            FileStream fs = new FileStream(@"..\Databas\sales.txt", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                sales.Add(new SaleProductViewModel(sr.ReadLine()));          
            }
            sr.Close();
            fs.Close();
            return sales;
        }

        public string SaleProduct(int productId, int cnt)
        {
            IProductRepository productRepository = new ProductRepository();
            if (cnt >= GetProductQuantity(productId))
            {
                stocks.Where(s => s.ProductId == productId).SingleOrDefault().ProductQuantity -= cnt;
                var saledStock = stocks.Where(s => s.ProductId == productId).SingleOrDefault();
                SaleProductViewModel saled = new SaleProductViewModel(saledStock.Name,saledStock.ProductId,cnt, saledStock.ProductPrice);
                using (TextWriter writer = File.AppendText(@"..\Databas\sales.txt"))
                {
                    writer.WriteLine(saled.ToString());
                }
                return "ok";
            }
            else
            {
                var message = ("quantity of " + productRepository.GetProductById(productId) + " is " + GetProductQuantity(productId));
                return message;
            }
        }
        private void SaveChanges()
        {
            string JsonSerialize = JsonSerializer.Serialize(stocks);
            File.WriteAllText(@"..\Databas\StockJson.json", JsonSerialize);
        }
        private int GetProductQuantity(int productId)
        {
            return stocks.Where(s => s.ProductId == productId).SingleOrDefault().ProductQuantity;
        }
    }
}