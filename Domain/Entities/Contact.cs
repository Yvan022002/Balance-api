﻿namespace Balance_API.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty; 
        public string Email {  get; set; } = string.Empty;
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<TransferTransaction> Transactions { get; set; } = new List<TransferTransaction>();
    }
}
