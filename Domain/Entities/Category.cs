namespace Balance_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<ExpenseTransaction> Transactions { get; set; } = new List<ExpenseTransaction>();
    }
}
