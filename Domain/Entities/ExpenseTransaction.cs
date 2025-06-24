namespace Balance_API.Models
{
    public class ExpenseTransaction:Transaction
    {

        public int? FromCardId { get; set; }
        public Card? FromCard { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? Notes { get; set; }
    }
}
