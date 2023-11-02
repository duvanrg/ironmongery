namespace ironmongery.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Client(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }


    }
}