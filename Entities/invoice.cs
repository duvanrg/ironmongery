namespace ironmongery.Entities
{
    public class Invoice : DetailInvoice
    {
        

        public Invoice(int id, int nroInvoices, int idProd, int quantity, float value, int nroInvoice, DateTime date, int idClient, float totalInvoice) : base(id, nroInvoices, idProd, quantity, value)
        {
            this.NroInvoice = nroInvoice;
            nroInvoices = nroInvoice;
            this.Date = date;
            this.IdClient = idClient;
            this.TotalInvoice = totalInvoice;
        }
        public int NroInvoice { get; set; }
        public DateTime Date { get; set; }
        public int IdClient { get; set; }
        public float TotalInvoice { get; set; }
    }
}