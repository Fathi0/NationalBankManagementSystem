using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;

namespace NationalBankManagementSystem.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> T)
        {
            T.HasKey(T => T.TransactionNumber);
            T.HasOne(T => T.Account)
                .WithMany(A => A.Transactions)
                .HasForeignKey(T => T.AccountNumber);
        }
    }
}