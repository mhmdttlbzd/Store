// See https://aka.ms/new-console-template for more information
using Store.Domain;
using Store.Interface;
using System.Text.Json;
//List<Stock> stocks =new List<Stock>();
//List<Product> products =new List<Product>();
//string JsonSerialize = JsonSerializer.Serialize(stocks);
//File.WriteAllText("..\\..\\..\\Databas\\StockJson.json", JsonSerialize);
//Console.WriteLine("Hello, World!");
//string JsonSerializ = JsonSerializer.Serialize(products);
//File.WriteAllText("..\\..\\..\\Databas\\ProductJson.json", JsonSerializ);
try
{
    while (true)
    {
        Console.Clear();
        IProductRepository pRepository = new ProductRepository();
        IStockRepository stockRepository = new StockRepository();
        Console.WriteLine("enter anumber");
        Console.WriteLine("1 : add product");
        Console.WriteLine("2 : get pruduct list");
        Console.WriteLine("3 : get pruduct by id");
        Console.WriteLine("11 : sale product");
        Console.WriteLine("12 : by product");
        Console.WriteLine("13 : sales product list");
        Console.WriteLine("14 : stock product list");
        int num = int.Parse(Console.ReadLine());
        switch (num)
        {
            case 1:
                Product p = new Product();
                Console.Write("enter name : "); p.Name = Console.ReadLine();
                Console.Write("enter productId : "); p.ProductId = int.Parse(Console.ReadLine());
                Console.Write("enter bar code : "); p.Barcode = Console.ReadLine();
                pRepository.AddProduct(p);
                break;
            case 2:
                var l = pRepository.GetProductList();
                foreach (Product item in l)
                {
                    Console.WriteLine(item.ToString());
                }
                break;
            case 3:
                Console.Write("enter id : "); Console.WriteLine(pRepository.GetProductById(int.Parse(Console.ReadLine())));
                break;
            case 11:
                Console.WriteLine("enter productId and cnt");
                var id = Console.ReadLine();
                var cnt = Console.ReadLine();
                Console.WriteLine( stockRepository.SaleProduct(int.Parse(id), int.Parse(cnt)));
                break;
            case 12:
                Stock s = new Stock();
                Console.WriteLine("enter StockId Name ProductId ProductQuantity ProductPrice");
                s.StockId = int.Parse(Console.ReadLine());
                s.Name = Console.ReadLine();
                s.ProductId = int.Parse(Console.ReadLine());
                s.ProductQuantity = int.Parse(Console.ReadLine());
                s.ProductPrice = int.Parse(Console.ReadLine());
                stockRepository.BuyProduct(s);
                break;
            case 13:
                var sales = stockRepository.GetSalesProductList();
                foreach (var item in sales)
                {
                    Console.WriteLine(item.ToString());
                }
                break;
            case 14:
                var li =stockRepository.GetStockProductList();
                foreach (var item in li)
                {
                    Console.WriteLine(item.ToString());
                }
                break;

        }
        Console.ReadKey();
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
