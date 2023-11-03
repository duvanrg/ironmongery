namespace ironmongery.Entities
{
    public class DetailInvoice
    {
        

        public int Id { get; set; }
        public int NroInvoices { get; set; }
        public int IdProd { get; set; }
        public int Quantity { get; set; }
        public double Value { get; set; }
        public DetailInvoice(int id, int nroInvoices, int idProd, int quantity, double value)
        {
            Id = id;
            IdProd = idProd;
            Quantity = quantity;
            Value = value;
        }

        public DetailInvoice()
        {
            
        }

    }
}