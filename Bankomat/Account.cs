using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bankomat
{
    public class Account
    {
        public int id { get; set; }
        public decimal balance { get; set; } = 0;
        public Account(Bank bank)
        {
            this.id = bank.NumOfAccounts;
        }

        public string Info()
        {
            return $"ID: {this.id}, balance: {this.balance}";
        }




    }
}
