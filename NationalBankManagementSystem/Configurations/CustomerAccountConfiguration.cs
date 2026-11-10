using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationalBankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Configurations
{
    public class CustomerAccountConfiguration : IEntityTypeConfiguration<CustomerAccount>
    {
        public void Configure(EntityTypeBuilder<CustomerAccount> CA)
        {
            CA.HasKey(CA=>new { CA.CustomerId, CA.AccountNumber });
            CA.HasOne(CA => CA.Customer)
                 .WithMany(C => C.CustomerAccounts)
                 .HasForeignKey(CA => CA.CustomerId);
            CA.HasOne(CA => CA.Account)
                .WithMany(A => A.CustomerAccounts)
                .HasForeignKey(CA => CA.AccountNumber);

        }
    }
}
