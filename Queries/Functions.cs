using ironmongery.Entities;
using Newtonsoft.Json;

namespace ironmongery.Queries
{
    public class Functions
    {
        public void ListProducts(IList<Product> listProducts)
        {
            var _products = (from p
                            in listProducts
                             select p);
            // _products.ForEach(x => Console.WriteLine($"Nombre: {x.Name}, precio Unidad: {x.PriceUnit}, Cantidad: {x.Quantity}"));
            foreach (var item in _products)
            {
                Console.WriteLine($"Nombre: {item.Name}, precio Unidad: {item.PriceUnit}, Cantidad: {item.Quantity}");
            }
        }

        public void ProductRecover(IList<Product> listProducts)
        {
            var _products = (from p
                            in listProducts
                             where p.Quantity < p.StockMin
                             select p);
            foreach (var item in _products)
            {
                Console.WriteLine($"Nombre: {item.Name}, precio Unidad: {item.PriceUnit}, Cantidad: {item.Quantity}");
            }
        }
        // 3. LISTAR LOS PRODUCTOS QUE SE DEBEN COMPRAR Y QUE CANTIDAD DE DEBE COMPRAR LA CANTIDAD A COMPRAR SE OBTIENE TENIENDO EN CUENTA LA DIFERENCIA ENTRE LA CANTIDAD Y EL STOCKMAX.
        public void ProductsForBuy(IList<Product> listProducts)
        {
            var productsToBuy = from p in listProducts
                                where p.Quantity < p.StockMin
                                select new
                                {
                                    p.Name,
                                    p.PriceUnit,
                                    QuantityToBuy = p.StockMax - p.Quantity
                                };
            foreach (var product in productsToBuy)
            {
                Console.WriteLine($"Nombre: {product.Name}, Precio: {product.PriceUnit}, Cantidad a comprar: {product.QuantityToBuy}");
            }
        }

        // 4. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023.
        public void GetInvoiceJanuary(IList<Invoice> listInvoices)
        {
            var invoiceJanuary = from I
                                in listInvoices
                                 where I.Date.Month == 1
                                 select I;
            foreach (var item in invoiceJanuary)
            {
                Console.WriteLine($"Nro Factura: {item.NroInvoice}, Fecha= {item.Date} id Client: {item.IdClient}, valor: {item.TotalInvoice}");
            }
        }
        // 5. LISTAR LOS PRODUCTOS VENDIDOS EN UNA DETERMINADA FACTURA.
        public void ListProductsInvoice(IList<Invoice> listInvoices, IList<Product> listProducts)
        {
            Console.WriteLine("Digita el número de factura a buscar: ");
            int invoiceSearch = int.Parse(Console.ReadLine());

            var productsSoldInInvoice = from invoice in listInvoices
                                        where invoice.NroInvoice == invoiceSearch
                                        from detail in invoice.ListDetails
                                        join product in listProducts on detail.IdProd equals product.Id
                                        select new
                                        {
                                            ProductName = product.Name,
                                            Quantity = detail.Quantity,
                                            Value = detail.Value
                                        };

            foreach (var product in productsSoldInInvoice)
            {
                Console.WriteLine($"Producto: {product.ProductName}, Cantidad: {product.Quantity}, Valor: {product.Value}");
            }
        }

        // 6. CALCULAR EL VALOR TOTAL DEL INVENTARIO.
        public void ValueInventory(IList<Product> listProducts)
        {
            // double totalValue = 0;
            var valueInInventory = from p
                                    in listProducts
                                    select new { ValueProducts =  p.PriceUnit * p.Quantity};
            // foreach (var item in valueInInventory)
            // {
            //     totalValue += item.ValueProducts;
            // }
            // Console.WriteLine($"el valor en el inventario es de: {totalValue}");
            Console.WriteLine($"el valor en el inventario es de: {valueInInventory.Sum(p => p.ValueProducts)}");
        }
        public IList<T> SaveData<T>(IList<T> list, string filename)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText("data/" + filename, json);
            return list;
        }

        public IList<T> LoadData<T>(string filename)
        {
            if (File.Exists("data/" + filename))
            {
                using (StreamReader reader = new StreamReader("data/"+filename))
                {
                    string json = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<IList<T>>(json) ?? new List<T>();
                }
            }
            else
            {
                return new List<T>();
            }
        }
    }
}