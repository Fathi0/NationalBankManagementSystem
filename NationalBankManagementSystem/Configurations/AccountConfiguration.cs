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
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> A)
        {
            A.HasKey(A => A.AccountNumber);
            A.HasOne(A => A.Branch)
                .WithMany(B => B.Accounts)
                .HasForeignKey(A => A.BranchCode);
        }
    }
}
