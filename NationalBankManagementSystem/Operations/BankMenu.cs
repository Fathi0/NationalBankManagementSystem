using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Operations
{
    public class BankMenu
    {
        public static void ShowMenu()
        {
            Console.WriteLine("========== National Bank Management System ==========");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Open Account");
            Console.WriteLine("3. Update Account Status");
            Console.WriteLine("4. Remove Account from Customer");
            Console.WriteLine("5. List Customers");
            Console.WriteLine("0. Exit");
            Console.WriteLine("=====================================================");
            Console.WriteLine("Enter your choice:");
    }
        public static int GetChoice()
        {
            int Choice;
            if(int.TryParse(Console.ReadLine(),out Choice))
            {
                return Choice;
            }
            return -1;
        }

    }
}
