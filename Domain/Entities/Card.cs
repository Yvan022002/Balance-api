namespace Balance_API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string Type { get; set; } = "debit"; // debit, credit
        public decimal Balance { get; set; }
        public DateTime Expiration { get; set; }
        public int Code { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
