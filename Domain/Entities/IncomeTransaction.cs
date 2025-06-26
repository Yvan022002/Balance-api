namespace Balance_API.Domain.Entities
{
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; } = string.Empty;
        public bool IsRecurring { get; set; }
        public TimeOnly? Frequence { get; set; }
    }
}
