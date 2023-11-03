using ConsoleTables;
using ironmongery.Entities;
using Newtonsoft.Json;

namespace ironmongery.Queries
{
    public class Functions
    {
        // 1. LISTAR LOS PRODUCTOS DEL INVENTARIO
        public void ListProducts(IList<Product> listProducts)
        {
            var _products = (from p
                            in listProducts
                             select p);
            var tableProducts = new ConsoleTable("Nombre","Precio Unidad","Cantidad");
            foreach (var item in _products)
            {
                tableProducts.AddRow($"{item.Name}", $"{item.PriceUnit}",$"{item.Quantity}");
            }
            tableProducts.Write(Format.Alternative);
        }
        // 2. LISTAR LOS PRODUCTOS QUE ESTAN A PUNTO DE AGOTARSE. CANTIDAD<STOCKMIN
        public void ProductRecover(IList<Product> listProducts)
        {
            var _products = (from p
                            in listProducts
                             where p.Quantity < p.StockMin
                             select p);
            var tableRecover = new ConsoleTable("Nombre","Precio Unidad","Cantidad");
            foreach (var item in _products)
            {
                tableRecover.AddRow($"{item.Name}",$" {item.PriceUnit}",$" {item.Quantity}");
            }
            tableRecover.Write(Format.Alternative);
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
            var tableBuys = new ConsoleTable("Nombre","Precio","Cantidad a Comprar");
            foreach (var product in productsToBuy)
            {
                tableBuys.AddRow($"{product.Name}",$"{product.PriceUnit}",$"{product.QuantityToBuy}");
            }
            tableBuys.Write(Format.Alternative);
        }

        // 4. LISTAR EL TOTAL DE FACTURAS DEL MES DE ENERO DEL 2023.
        public void GetInvoiceJanuary(IList<Invoice> listInvoices)
        {
            var invoiceJanuary = from I
                                in listInvoices
                                 where I.Date.Month == 1
                                 select I;
            var tableJanuary = new ConsoleTable("Nro Factura","Fecha","id Client","valor");
            foreach (var item in invoiceJanuary)
            {
                tableJanuary.AddRow($"{item.NroInvoice}",$"{item.Date}",$"{item.IdClient}",$"{item.TotalInvoice}");
            }
            tableJanuary.Write(Format.Alternative);
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
            Console.Clear();
            var tableProductsInvoice = new ConsoleTable("Producto","Cantidad","Valor");
            foreach (var product in productsSoldInInvoice)
            {
                tableProductsInvoice.AddRow($"{product.ProductName}",$"{product.Quantity}",$"{product.Value}");
            }
            tableProductsInvoice.Write(Format.Alternative);
        }

        // 6. CALCULAR EL VALOR TOTAL DEL INVENTARIO.
        public void ValueInventory(IList<Product> listProducts)
        {
            var valueInInventory = from p
                                    in listProducts
                                    select new { ValueProducts =  p.PriceUnit * p.Quantity};
            var tableResult = new ConsoleTable("Valor Inventario",$"{valueInInventory.Sum(p => p.ValueProducts)}");
            tableResult.Write(Format.Alternative);
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