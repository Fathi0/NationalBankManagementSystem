using NationalBankManagementSystem.Enums;
using NationalBankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationalBankManagementSystem.Operations
{
    public class AccountOperations
    {
        public static void OpenAccount(AppDbContext context)
        {
            Console.WriteLine("Enter Account Number: ");
            string AccountNumber = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(AccountNumber))
            {
                Console.WriteLine("Account Number is required!");
                return;
            }
            if(context.Accounts.Any(A=>A.AccountNumber==AccountNumber))
            {
                Console.WriteLine("This Account Number already exists!");
                return;
            }
            Console.WriteLine("Select Account Type");
            Console.WriteLine("1.Savings");
            Console.WriteLine("2.Current");
            Console.WriteLine("3.Business");
            if(!int.TryParse(Console.ReadLine(),out int typeChoise))
            {
                Console.WriteLine("Invalid Account Type!");
                return;
            }
            if(typeChoise !=1&&typeChoise!=2&&typeChoise!=3)
            {
                Console.WriteLine("Invalid Account Type!");
                return;
            }
            AccountType accountType = (AccountType)typeChoise;
            Console.WriteLine("Enter Branch Code: ");
            string branchCode = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(branchCode))
            {
                Console.WriteLine("Branch Code is required!");
                return;
            }
            Branch branch = context.Branches.FirstOrDefault(B => B.Code == branchCode);
            if(branch == null)
            {
                Console.WriteLine("Branch Not Found!");
                return;
            }
            Console.WriteLine("Enter Customer Id: ");
            if(!int.TryParse(Console.ReadLine(),out int customerId))
            {
                Console.WriteLine("Invalid Customer ID!");
                return;
            }
            Customer customer = context.Customers.FirstOrDefault(C => C.Id == customerId);
            if(customer==null)
            {
                Console.WriteLine("Customer Not Found!");
                return;
            }
            Console.WriteLine("Select Ownership Type:");
            Console.WriteLine("1. Primary");
            Console.WriteLine("2. CoHolder");
            if(!int.TryParse(Console.ReadLine(),out int ownershipChoice))
            {
                Console.WriteLine("Invalid Ownership Type!");
                return;
            }
            if(ownershipChoice != 1&&ownershipChoice !=2)
            {
                Console.WriteLine("Invalid Ownership Type!");
                return;
            }
            OwnershipType ownershipType = (OwnershipType)ownershipChoice;
            Account account = new Account
            {
                AccountNumber = AccountNumber,
                AccountType = accountType,
                CurrentBalance = 0,
                OpeningDate = DateTime.Now,
                BranchCode = branchCode
            };
            CustomerAccount customerAccount = new CustomerAccount
            {
                CustomerId = customerId,
                AccountNumber = AccountNumber,
                OwnershipType = ownershipType,
                OwnershipStartDate = DateTime.Now,
                AccountStatus = AccountStatus.Active
            };
            context.Accounts.Add((account));
            context.CustomerAccounts.Add(customerAccount);
            context.SaveChanges();
            Console.WriteLine("Account Opened Successfully!");
        }
        public static void UpdateAccountStatus(AppDbContext context)
        {
            Console.WriteLine("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(accountNumber))
            {
                Console.WriteLine("Account Number is required!");
                return;

            }
            Console.WriteLine("Enter Customr Id: ");
            if(!int.TryParse(Console.ReadLine(),out int customrId))
            {
                Console.WriteLine("Invalid Customer ID!");
                return;
            }
            CustomerAccount customerAccount = context.CustomerAccounts.FirstOrDefault(CA => CA.AccountNumber == accountNumber && CA.CustomerId == customrId);
            if(customerAccount==null)
            {
                Console.WriteLine("Customer Account Not Found!");
                return;
            }
            if(customerAccount.AccountStatus == AccountStatus.Active)
            {
                customerAccount.AccountStatus = AccountStatus.Inactive;
            }else
            {
                customerAccount.AccountStatus = AccountStatus.Active;
            }
            context.SaveChanges();
            Console.WriteLine($"Account Status Updated Successfully! New Status: {customerAccount.AccountStatus}");
        }
        public static void RemoveAccountFromCustomer(AppDbContext context)
        {
            Console.WriteLine("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(accountNumber))
            {
                Console.WriteLine("Account Number is required!");
                return;
            }
            Console.WriteLine("Enter Customr Id: ");
            if (!int.TryParse(Console.ReadLine(), out int customrId))
            {
                Console.WriteLine("Invalid Customer ID!");
                return;
            }
            CustomerAccount customerAccount = context.CustomerAccounts.FirstOrDefault(CA => CA.AccountNumber == accountNumber && CA.CustomerId == customrId);
            if (customerAccount == null)
            {
                Console.WriteLine("Customer Account Not Found!");
                return;
            }
            context.CustomerAccounts.Remove(customerAccount);
            context.SaveChanges();
            Console.WriteLine("Account Removed From Customer Successfully!");
        }
    }
}
