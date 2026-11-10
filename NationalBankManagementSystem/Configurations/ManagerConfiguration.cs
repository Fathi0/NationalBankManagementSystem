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
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {
        public void Configure(EntityTypeBuilder<Manager> M)
        {
            M.HasData
            (
                new Manager
                {
                    Id = 1,
                    FullName = "Ahmed Mohamed",
                    Email = "Ahmed@ban.com",
                    PhoneNumber = 123456789,
                    HireDate = new DateTime(2020, 1, 1)
                }
            );
        }
    }
}
