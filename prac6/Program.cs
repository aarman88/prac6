using Bankomat;
using System;

namespace BankomatApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание клиента и счета
            Account clientAccount = new Account("123456", "password"); // Пример номера счета и пароля
            int loginAttempts = 3;
            string enteredPassword;

            // Ввод пароля
            while (loginAttempts > 0)
            {
                Console.Write("Введите ваш пароль: ");
                enteredPassword = Console.ReadLine();

                if (enteredPassword == clientAccount.Password)
                {
                    Console.WriteLine("Пароль правильный. Добро пожаловать!");
                    break;
                }
                else
                {
                    loginAttempts--;
                    Console.WriteLine($"Неверный пароль. {loginAttempts} осталось попыток.");
                }
            }

            if (loginAttempts == 0)
            {
                Console.WriteLine("Попытки ввода пароля превышены. Выход...");
                return;
            }

            // Взаимодействие с меню
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("a. Проверить баланс");
                Console.WriteLine("b. Внести деньги");
                Console.WriteLine("c. Снять деньги");
                Console.WriteLine("d. Выход");

                Console.Write("Введите свой выбор: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        clientAccount.DisplayBalance();
                        break;
                    case "b":
                        Console.Write("Введите сумму для внесения депозита: $");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            clientAccount.Deposit(depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод.");
                        }
                        break;
                    case "c":
                        Console.Write("Введите сумму для вывода: $");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            if (clientAccount.Withdraw(withdrawAmount))
                            {
                                // Successful withdrawal
                            }
                        }
                        else
                        {
                            Console.WriteLine("Неверный ввод.");
                        }
                        break;
                    case "d":
                        Console.WriteLine("До свидание!");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
                        break;
                }
            }
        }
    }
}
