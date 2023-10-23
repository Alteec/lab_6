using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection;
using Registration.Library;
using Bankomat;



namespace Registration;
class HW
{
    static void Main()
    {
        //First_Task(); //Первое задание
        //Second_Task();
        Bank someBank = new Bank();
        Registration(someBank);
        Auth(someBank);

    }

    static void First_Task()
    {
        Person person1 = new Person("Hank", "Some Description");
        Console.WriteLine(Library.Person_Info.GetInfo(person1)); //Первое задание
    }

    static void Second_Task()
    {
        Console.WriteLine($"{Consts.RandomString} {Consts.RandomNum}");
    }

    static void Registration(Bank bank)
    {
        Client client = new Client(bank);

        Console.WriteLine("Name: ");
        client.Name = Console.ReadLine();

        Console.WriteLine("Surname: ");
        client.Surname = Console.ReadLine();

        Console.WriteLine("Password(empty to generate): ");
        string passw = Console.ReadLine();
        client.Password = string.IsNullOrWhiteSpace(passw) ? GeneratePassw() : passw;

        client.NewAccount(bank);
        Console.WriteLine("Add Balance:");
        client.Accounts[0].balance = int.Parse(Console.ReadLine());

        Console.WriteLine($"{client.Info()}, password: {client.Password}");
        bank.AddClient(client);
    }

    static void Auth(Bank bank)
    {
        Console.WriteLine("Account id: ");
        int id = int.Parse(Console.ReadLine());
        try
        {
            Client client = bank.ClientById(id);
            string passw;
            for (int i = 0; i < 3; i++)
            {

                Console.WriteLine("Password: ");
                passw = Console.ReadLine();
                if (passw.Equals(client.Password))
                {
                    Menu(client, bank);
                    return;
                }
            }
        }
        catch
        {
            Console.WriteLine("Failed to find");
        }
    }

    static void Menu(Client client, Bank bank)
    {
        Console.WriteLine($"-----\nWelcome back!{client.Info()}\n1. Accounts info\n2. Add to an account\n3. Withdraw from an account \n4. Exit \n -----"); ;
        int choice = int.Parse(Console.ReadLine());
        int acc_id;
        decimal sum;
        switch (choice)
        {
            case 1:
                client.AccountsInfo();
                break;
            case 2:
                Console.WriteLine($"Account ID:");
                acc_id = int.Parse(Console.ReadLine());
                Console.WriteLine($"Sum:");
                sum = decimal.Parse(Console.ReadLine());
                bank.Transaction(acc_id, sum);
                break;
            case 3:
                Console.WriteLine($"Account ID:");
                acc_id = int.Parse(Console.ReadLine());
                Console.WriteLine($"Sum:");
                sum = decimal.Parse(Console.ReadLine());
                bank.Transaction(acc_id, -sum);
                break;
            case 4:
                return;
        }
        Menu(client, bank);
    }
    static string GeneratePassw()
    {
        string passw = "";
        string specials = "!@$#%^&*";
        var rand = new Random();
        int len = rand.Next(6, 10);
        for (int i = 0; i < len; i++)
        {
            int type = rand.Next(3);
            switch (type)
            {
                case 0:
                    passw += rand.Next(10).ToString();
                    break;
                case 1:
                    passw += specials[rand.Next(specials.Length)];
                    break;
                case 2:
                    int charCase = rand.Next(2);
                    passw += charCase == 1 ? (char)(rand.Next(97, 123)) : (char)(rand.Next(65, 91));
                    break;

            }
        }
        return passw;
    }
}