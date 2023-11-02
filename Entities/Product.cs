using Newtonsoft.Json;


namespace ironmongery.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PriceUnit { get; set; }
        public float Quantity { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public Product(int id, string name, double priceUnit, int quantity, int stockMin, int stockMax)
        {
            Id = id;
            Name = name;
            PriceUnit = priceUnit;
            Quantity = quantity;
            StockMin = stockMin;
            StockMax = stockMax;
        }
        public Product()
        {
        }

        public void AddProduct(IList<Product> listProducts)
        {
            Product _product = new Product();
            Console.WriteLine($"Id:");
            _product.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Nombre:");
            _product.Name = Console.ReadLine();
            Console.WriteLine($"Precio por unidad:");
            _product.PriceUnit = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Cantidad:");
            _product.Quantity = float.Parse(Console.ReadLine());
            Console.WriteLine($"Cantidad minima:");
            _product.StockMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Cantidad Maxima:");
            _product.StockMax = Convert.ToInt32(Console.ReadLine());
            
        }

    }
}