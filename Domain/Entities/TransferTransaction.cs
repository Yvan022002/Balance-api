namespace Balance_API.Domain.Entities
{
    public class TransferTransaction : Transaction 
    {
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }

    }
}
