using Store.Domain;
using Store.Interface.Exeption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store.Interface
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            FileStream JsonProductFile = File.Open("..\\..\\..\\Databas\\ProductJson.json", FileMode.OpenOrCreate);
            products = JsonSerializer.Deserialize<List<Product>>(JsonProductFile);
            JsonProductFile.Close();
        }
        public string AddProduct(Product product)
        {
            try{ CheckProductName(product.Name);}
            catch(Exception ex) { return(ex.Message); }

            products.Add(product);
            SaveChanges();
            return "ok";

        }
        public string GetProductById(int id)
        {
            Product product = products.Single(p => p.ProductId == id);
            return product.Name;
        }
        public List<Product> GetProductList()
        {
            return products;
        }
        private void CheckProductName(string productName)
        {
            Regex regex = new Regex(@"^[A-X][a-x]{2}[0-9]{3}_$");
            if (!regex.IsMatch(productName))
                throw new ProductNameExeption();
        }
        private void SaveChanges()
        {
            string JsonSerialize = JsonSerializer.Serialize(products);
            File.WriteAllText("..\\..\\..\\Databas\\ProductJson.json", JsonSerialize);
            //JsonSerialize.Close();
        }
    }
}
