namespace ironmongery.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Client()
        {
            
        }
        public Client(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }

        public void AddClient(IList<Client> listClients)
        {
            Client _client = new Client();
            Console.WriteLine($"Id: ");
            _client.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Nombre: ");
            _client.Name = Console.ReadLine();
            Console.WriteLine($"Email: ");
            _client.Email = Console.ReadLine();
            listClients.Add(_client);
        }
    }
}