namespace Balance_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Contact> Contacts { get; set; }=new List<Contact>();
        public ICollection<Card> Cards { get; set; } = new List<Card>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        public ICollection<Category> Categories { get; set; }  =new List<Category>();

    }
}
