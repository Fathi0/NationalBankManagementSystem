using Microsoft.EntityFrameworkCore;
using NationalBankManagementSystem.Enums;
using NationalBankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Operations
{
    public class CustomerOperations
    {
        public static void AddCustomer(AppDbContext context)
        {
            Console.WriteLine("Enter Full Name: ");
            string FullName = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(FullName))
            {
                Console.WriteLine("Full Name is required!");
                return;
            }
            Console.WriteLine("Enter National ID: ");
            string NationalId = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(NationalId))
            {
                Console.WriteLine("National ID is required!");
                return;
            }
            if(context.Customers.Any(C=>C.NationalId == NationalId))
            {
                Console.WriteLine("This National ID already exists!");
                return;
            }
            Console.Write("Enter Date of Birth: ");
            if(!DateTime.TryParse(Console.ReadLine(),out DateTime DateOfBirth))
            {
                Console.WriteLine("Invalid Date of Birth!");
                return;
            }

            Console.Write("Enter Email: ");
            string Email = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            if(!int.TryParse(Console.ReadLine(),out int PhoneNumber))
            {
                Console.WriteLine("Invalid Phone Number!");
                return;
            }
          

            Console.Write("Enter Address: ");
            string Address = Console.ReadLine();

            Console.WriteLine("Select Customer Type:");
            Console.WriteLine("1. Individual");
            Console.WriteLine("2. Business");

            if(!int.TryParse(Console.ReadLine(),out int typeChoice))
            {
                Console.WriteLine("Invalid Customer Type!");
                return;
            }
            if (typeChoice != 1 && typeChoice != 2)
            {
                Console.WriteLine("Invalid Customer Type!");
                return;
            }
            CustomerType customerType = (CustomerType)typeChoice;
            Customer customer = new Customer
            {
                FullName = FullName,
                NationalId = NationalId,
                DateOfBirth = DateOfBirth,
                Email = Email,
                PhoneNumber = PhoneNumber,
                Address = Address,
                CustomerType = customerType
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            Console.WriteLine("Customer Added Successfully!");
        }
        public static void ListCustomers(AppDbContext context)
        {
            var customers = context.Customers
                .Include(C => C.CustomerAccounts)
                .ThenInclude(CA => CA.Account)
                .ToList();
            foreach(var customer in customers)
            {
                Console.WriteLine($"Full Name: {customer.FullName}");
                Console.WriteLine($"Email: {customer.Email}");
                Console.WriteLine($"National Id: {customer.NationalId}");
                foreach(var customerAccount in customer.CustomerAccounts)
                {
                    Console.WriteLine($"Account Number: {customerAccount.Account.AccountNumber}");
                    Console.WriteLine($"Account Type: {customerAccount.Account.AccountType}");
                    Console.WriteLine($"Current Balance: {customerAccount.Account.CurrentBalance}");
                    Console.WriteLine($"Account Status: {customerAccount.AccountStatus}");
                }
            }
        }

    }
}
