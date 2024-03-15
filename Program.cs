//                                                                     //
//                                                                     //
//   The main function for user authentication and banking operations. //
//                                                                     //
//                                                                     //
using System;
using System.Collections.Generic;
using System.IO;

public class ATM
{
    private const string USER_DATA_FILE = "C:\\Users\\Emirh\\source\\repos\\ATM\\userdata.txt";
    private static List<User> users = new List<User>();

    public static void Main(string[] args)
    {
        LoadDataFromFile();

        Console.Write("Enter your username: ");
        string username = Console.ReadLine();

        Console.Write("Enter your PIN: ");
        string pin = Console.ReadLine();

        if (AuthenticateUser(username, pin))
        {
            double balance = GetBalance(username);
            Console.WriteLine($"Welcome, {username}! Your balance is: ${balance}");

            Console.WriteLine("1. Withdraw");
            Console.WriteLine("2. Deposit");
            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            if (option == 1)
            {
                Console.Write("Enter the amount to withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                if (Withdraw(username, amount))
                {
                    Console.WriteLine("Withdrawal successful!");
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }
            }
            else if (option == 2)
            {
                Console.Write("Enter the amount to deposit: ");
                double amount = double.Parse(Console.ReadLine());
                Deposit(username, amount);
                Console.WriteLine("Deposit successful!");
            }

            balance = GetBalance(username);
            Console.WriteLine($"Your updated balance is: ${balance}");
        }
        else
        {
            Console.WriteLine("Invalid username or PIN! Please try again.");
        }
    }

    private static void LoadDataFromFile()
    {
        if (File.Exists(USER_DATA_FILE))
        {
            string[] lines = File.ReadAllLines(USER_DATA_FILE);
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                string username = parts[0];
                string pin = parts[1];
                double balance = double.Parse(parts[2]);
                users.Add(new User(username, pin, balance));
            }
        }
    }

    private static void SaveDataToFile()
    {
        using (StreamWriter writer = new StreamWriter(USER_DATA_FILE))
        {
            foreach (User user in users)
            {
                writer.WriteLine($"{user.Username} {user.Pin} {user.Balance}");
            }
        }
    }

    private static bool AuthenticateUser(string username, string pin)
    {
        foreach (User user in users)
        {
            if (user.Username == username && user.Pin == pin)
            {
                return true;
            }
        }
        return false;
    }

    private static double GetBalance(string username)
    {
        foreach (User user in users)
        {
            if (user.Username == username)
            {
                return user.Balance;
            }
        }
        return 0;
    }

    private static bool Withdraw(string username, double amount)
    {
        foreach (User user in users)
        {
            if (user.Username == username)
            {
                if (amount > user.Balance)
                {
                    return false;
                }
                user.Balance -= amount;
                SaveDataToFile();
                return true; 
            }
        }
        return false; 
    }

    private static void Deposit(string username, double amount)
    {
        foreach (User user in users)
        {
            if (user.Username == username)
            {
                user.Balance += amount;
                SaveDataToFile();
                break;
            }
        }
    }
}

public class User
{
    public string Username { get; set; }
    public string Pin { get; set; }
    public double Balance { get; set; }

    public User(string username, string pin, double balance)
    {
        Username = username;
        Pin = pin;
        Balance = balance;
    }
}