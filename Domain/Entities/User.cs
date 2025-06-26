namespace Balance_API.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public ICollection<Contact> Contacts { get; set; }=new List<Contact>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Category> Categories { get; set; }  =new List<Category>();

    }
}
