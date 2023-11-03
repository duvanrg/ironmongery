using ConsoleTables;
using ironmongery.Entities;
using ironmongery.Queries;

internal class Program
{
    private static void Main(string[] args)
    {
        Functions _functions = new Functions();

        List<DetailInvoice> detailInvoices = new List<DetailInvoice>();
        IList<Product> ListProducts = new List<Product>();

        IList<Client> ListClients = new List<Client>();

        IList<Invoice> ListInvoices = new List<Invoice>();


        bool run = true;
        while (run)
        {
            Console.Clear();
            ListProducts = _functions.LoadData<Product>("Products.json");
            ListClients = _functions.LoadData<Client>("Clients.json");
            ListInvoices = _functions.LoadData<Invoice>("Invoices.json");
            Console.ForegroundColor = ConsoleColor.Blue;
            var tableMenu = new ConsoleTable("#", "Menu-Ferreteria");
            tableMenu.AddRow("1","Registrar datos")
                    .AddRow("2","Consultar")
                    .AddRow("3","Salir");
            tableMenu.Write(Format.Alternative);
            byte opc = Convert.ToByte(Console.ReadLine());
            switch (opc)
            {
                case 1:
                    Console.Clear();
                    RegisterData();
                    break;
                case 2:
                    Console.Clear();
                    Queries();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine($"Saliendo del programa... ");
                    run = false;
                    break;
                default:
                    Console.WriteLine($"Opcion no valida");
                    Console.ReadLine();
                    break;
            }
        }
        void RegisterData()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                var tableAdd = new ConsoleTable("#", "Agregar Datos");

                tableAdd.AddRow("1", " Agregar Productos")
                        .AddRow("2", " Agregar Cliente")
                        .AddRow("3", " Crear Factura")
                        .AddRow("4", " Regresar");
                tableAdd.Write(Format.Alternative);
                byte opc = Convert.ToByte(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Magenta;
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        // _functions.ListProducts(ListProducts);
                        Product _product = new Product();
                        _product.AddProduct(ListProducts);
                        _functions.SaveData(ListProducts, "Products.json");
                        break;
                    case 2:
                        Console.Clear();
                        Client _client = new Client();
                        _client.AddClient(ListClients);
                        break;
                    case 3:
                        Console.Clear();
                        Invoice _invoice = new Invoice();
                        _invoice.AddInvoice(ListInvoices, ListProducts);
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Regresando...");
                        run = false;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
        void Queries()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                var tableQuery = new ConsoleTable("#","Menu Consultas");
                tableQuery.AddRow("1","Listar Productos")
                            .AddRow("2","Productos Por Agotarse")
                            .AddRow("3","Productos a Comprar")
                            .AddRow("4","Listar Facturas Mensual")
                            .AddRow("5","Productos Factura")
                            .AddRow("6","Valor En Inventario")
                            .AddRow("7","Regresar");
                
                byte opc = Convert.ToByte(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                switch (opc)
                {
                    case 1:
                        Console.Clear();
                        _functions.ListProducts(ListProducts);
                        break;
                    case 2:
                        Console.Clear();
                        _functions.ProductRecover(ListProducts);
                        break;
                    case 3:
                        Console.Clear();
                        _functions.ProductsForBuy(ListProducts);
                        break;
                    case 4:
                        Console.Clear();
                        _functions.GetInvoiceJanuary(ListInvoices);
                        break;
                    case 5:
                        Console.Clear();
                        _functions.ListProductsInvoice(ListInvoices, ListProducts);
                        break;
                    case 6:
                        Console.Clear();
                        _functions.ValueInventory(ListProducts);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine($"Regresando...");
                        run = false;
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }

    }
}