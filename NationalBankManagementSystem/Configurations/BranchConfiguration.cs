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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> B)
        {
            B.HasKey(B => B.Code);
            B.HasOne(B => B.Manager)
                .WithOne(M => M.Branch)
                .HasForeignKey<Branch>(B => B.ManagerId);
            B.HasData
            (
                new Branch
                {
                    Code = "CAI-01",
                    Name = "Cairo Main Branch",
                    Address = "Cairo, Egypt",
                    PhoneNumber = 123456789,
                    ManagerId = 1
                }
            );
        }
    }
}
