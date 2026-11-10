using NationalBankManagementSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalId { get; set; }
        public CustomerType CustomerType { get; set; }
        public List<CustomerAccount> CustomerAccounts { get; set; }
    }
}
