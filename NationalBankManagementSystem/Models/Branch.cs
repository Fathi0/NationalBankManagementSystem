using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Models
{
    public class Branch
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
