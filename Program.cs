using ironmongery.Entities;

internal class Program
{
    private static void Main(string[] args)
    {
        IList<Product> ListProducts = new List<Product>();
        IList<Client> ListClients = new List<Client>();
        IList<Invoice> ListInvoices = new List<Invoice>();
        IList<DetailInvoice> ListDetailInvoice = new List<DetailInvoice>();

        bool run = true;
        while (run)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Menu Ferreteria");
            Console.WriteLine("1. Registrar datos");
            Console.WriteLine("2. Consultar");
            Console.WriteLine("3. Salir");
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
                    Console.ReadKey();
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
                Console.WriteLine("Registrar Informacion");
                Console.WriteLine("1. Agregar Productos");
                Console.WriteLine("2. Agregar Cliente");
                Console.WriteLine("3. Crear Factura");
                Console.WriteLine("4. Regresar");
                byte opc = Convert.ToByte(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();

                        break;
                    case 2:
                        Console.Clear();

                        break;
                    case 3:
                        Console.Clear();

                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine($"Regresando...");
                        run = false;
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }
        void Queries()
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Registrar Informacion");
                Console.WriteLine("1. Listar Productos");
                Console.WriteLine("2. Productos Por Agotarse");
                Console.WriteLine("3. Productos a Comprar");
                Console.WriteLine("4. Listar Facturas Mensual");
                Console.WriteLine("5. Productos Factura");
                Console.WriteLine("6. Valor En Inventario");
                Console.WriteLine("7. Regresar");
                byte opc = Convert.ToByte(Console.ReadLine());
                switch (opc)
                {
                    case 1:
                        Console.Clear();

                        break;
                    case 2:
                        Console.Clear();

                        break;
                    case 3:
                        Console.Clear();

                        break;
                    case 4:
                        Console.Clear();

                        break;
                    case 5:
                        Console.Clear();

                        break;
                    case 6:
                        Console.Clear();

                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine($"Regresando...");
                        run = false;
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }
            }
        }

    }
}