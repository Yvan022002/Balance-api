namespace Balance_API.Models
{
    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed,
        Cancelled
    }
    public abstract class Transaction
    {
        public int Id { get; set; }
        public string Label { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
