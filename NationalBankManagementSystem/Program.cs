using NationalBankManagementSystem.Operations;

namespace NationalBankManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int Choice;
            do
            {
                BankMenu.ShowMenu();
                Choice = BankMenu.GetChoice();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Thank you for using National Bank Management System!");
                        break;
                    case 1:
                       using (AppDbContext context = new AppDbContext())
                       {
                            CustomerOperations.AddCustomer(context);
                       }
                        break;
                    case 2:
                        using(AppDbContext context = new AppDbContext())
                        {
                            AccountOperations.OpenAccount(context);
                        }
                        break;
                    case 3:
                        using (AppDbContext context = new AppDbContext())
                        {
                            AccountOperations.UpdateAccountStatus(context);
                        }
                        break;
                    case 4:
                        using(AppDbContext context = new AppDbContext())
                        {
                            AccountOperations.RemoveAccountFromCustomer(context);
                        }
                        break;
                    case 5:
                        using(AppDbContext context = new AppDbContext())
                        {
                            CustomerOperations.ListCustomers(context);
                        }
                        break;
                    default: Console.WriteLine("Invalid Choice! Please try again.");
                        break;

                }
                if(Choice !=0)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (Choice != 0);

        }
    }
}
