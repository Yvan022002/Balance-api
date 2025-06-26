using Microsoft.EntityFrameworkCore;
using Balance_API.Domain.Entities;


namespace Balance_API.Infrastructure.Data
{
    public class BalanceDbContext:DbContext
    {
        public BalanceDbContext(DbContextOptions<BalanceDbContext> options)
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransferTransaction> TransferTransactions { get; set; }
        public DbSet<IncomeTransaction> IncomeTransactions { get; set; }
        public DbSet<ExpenseTransaction> ExpenseTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Héritage : TPH (Table-per-Hierarchy)
            modelBuilder.Entity<Transaction>()
                .HasDiscriminator<string>("TransactionType")
                .HasValue<ExpenseTransaction>("expense")
                .HasValue<IncomeTransaction>("income")
                .HasValue<TransferTransaction>("transfer");

            // Enum vers string (TransactionStatus)
            modelBuilder.Entity<Transaction>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Card)
                .WithMany()
                .HasForeignKey(t => t.CardId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Restrict); // ❗ Très important


        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=...;Database=BalanceApp;");
        }*/

    }
}
