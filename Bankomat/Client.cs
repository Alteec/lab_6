using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }

        public List<Account> Accounts { get; set; } = new List<Account>();

        public DateTime CreationDate { get; set; }
        public Client(Bank bank)
        {
            this.Id = bank.NumOfAccounts;
            this.CreationDate = DateTime.Now;
        }

        public void NewAccount(Bank bank)
        {
            Account account = new Account(bank);
            bank.AddAccount(account);
            this.Accounts.Add(account);
        }

        public string Info()
        {
            return $"{this.Id} ID ,{this.Name} {this.Surname}, {this.Accounts.Count} available accounts";
        }
        public void AccountsInfo()
        {
            foreach (Account account in this.Accounts)
            {
                Console.WriteLine(account.Info());
            }
        }




    }
}
