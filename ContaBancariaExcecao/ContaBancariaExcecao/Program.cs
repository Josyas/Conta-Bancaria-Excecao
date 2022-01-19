using System;
using ContaBancariaExcecao.Entities;
using ContaBancariaExcecao.Entities.Exceptions;
using System.Globalization;


namespace ContaBancariaExcecao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter account data");

                Console.WriteLine();
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial balance: ");
                double balance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Withdraw limit: ");
                double limit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Enter amount for withdraw: ");
                double toWithDraw = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Account account = new Account(number, holder, balance, limit, toWithDraw);
                account.WithDraw(toWithDraw);
                Console.WriteLine(account);

            }
            catch (DomainException e)
            {
                Console.WriteLine("Withdarw error: " + e.Message);
            }
        }
    }
}
