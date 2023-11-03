using ConsoleTables;
using Newtonsoft.Json;


namespace ironmongery.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double PriceUnit { get; set; }
        public int Quantity { get; set; }
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
            _product.Quantity = int.Parse(Console.ReadLine());
            Console.WriteLine($"Cantidad minima:");
            _product.StockMin = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Cantidad Maxima:");
            _product.StockMax = Convert.ToInt32(Console.ReadLine());
            var result = new ConsoleTable("Datos Agregados");
            Console.Clear();
            result.AddRow($"Nombre: {_product.Name}")
                .AddRow($"precio Unidad: {_product.PriceUnit}")
                .AddRow($"Cantidad: {_product.Quantity}");
            result.Write(Format.Alternative);
            listProducts.Add(_product);
        }

    }
}