using System;

namespace Bankomat
{
    public class Banc
    {
        // Реализация класса Banc
    }
}

namespace Bankomat
{
    public class Client
    {
        // Реализация класса Client
    }
}

namespace Bankomat
{
    public class Account
    {
        public decimal Balance { get; private set; }
        public string AccountNumber { get; private set; }
        public string Password { get; private set; }

        public Account(string accountNumber, string password)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ${amount}. Новый баланс: ${Balance}");
            }
            else
            {
                Console.WriteLine("Неверная сумма депозита.");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Снято ${amount}. Новый баланс: ${Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Неверная сумма вывода или недостаточно средств.");
                return false;
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Номер счета: {AccountNumber}, Баланс: ${Balance}");
        }
    }
}
