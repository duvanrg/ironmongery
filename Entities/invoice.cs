namespace ironmongery.Entities
{
    public class Invoice : DetailInvoice
    {


        public int NroInvoice { get; set; }
        public DateTime Date { get; set; }
        public int IdClient { get; set; }
        public double TotalInvoice { get; set; }
        public IList<DetailInvoice> ListDetails { get; set; }
        public Invoice(int nroInvoice, DateTime date, int idClient, float totalInvoice, IList<DetailInvoice> listInvoice)
        {
            this.NroInvoice = nroInvoice;
            this.Date = date;
            this.IdClient = idClient;
            this.TotalInvoice = totalInvoice;
            this.ListDetails = listInvoice;
        }

        public Invoice(int id, int nroInvoices, int idProd, int quantity, float value) : base(id, nroInvoices, idProd, quantity, value)
        {

        }

        public Invoice() : base()
        {
        }


        public void AddInvoice(IList<Invoice> listInvoices, IList<Product> listproducts)
        {
            bool run = true;
            Invoice _invoice = new Invoice();
            IList<DetailInvoice> ListDetails = new List<DetailInvoice>();
            Console.WriteLine($"Numero Factura: ");
            _invoice.NroInvoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Fecha: ");
            _invoice.Date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine($"Id Cliente: ");
            _invoice.IdClient = Convert.ToInt32(Console.ReadLine());
            while (run)
            {
                Console.WriteLine($"Id Producto: ");
                int Idprod = Convert.ToInt32(Console.ReadLine());
                Product product = listproducts.FirstOrDefault(p => p.Id == Idprod);
                if (product != null)
                {
                    Console.WriteLine($"Cantidad: ");
                    int Quantity = Convert.ToInt32(Console.ReadLine());
                    double valor = Quantity * product.PriceUnit;
                    _invoice.TotalInvoice += valor;

                    ListDetails.Add(new DetailInvoice
                    {
                        Id = Convert.ToInt32(Convert.ToString(Idprod) + Convert.ToString(NroInvoice)),
                        NroInvoices = NroInvoice,
                        IdProd = product.Id,
                        Quantity = Quantity,
                        Value = valor
                    });
                }
                else
                {
                    Console.WriteLine("Producto no encontrado. Verifique el ID del producto.");
                }

                Console.WriteLine("¿Desea agregar otro producto? (S/N)");
                string response = Console.ReadLine();
                if (response.ToLower() != "s")
                {
                    run = false;
                }
            }
            _invoice.ListDetails = ListDetails;
            listInvoices.Add(_invoice);
        }
    }
}