namespace Balance_API.Domain.Entities
{
    public class ExpenseTransaction:Transaction
    {

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? Notes { get; set; }
    }
}
