namespace Balance_API.Models
{
    public class TransferTransaction : Transaction
    {
        public int? ToCardId { get; set; }
        public Card? ToCard { get; set; }

        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }

    }
}
