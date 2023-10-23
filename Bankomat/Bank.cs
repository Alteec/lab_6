namespace Bankomat
{
    public class Bank
    {
        private List<Account> Accounts = new List<Account>();
        private List<Client> Clients = new List<Client>();
        public int NumOfAccounts { get { return Accounts.Count; } }
        public int NumOfClients { get { return Accounts.Count; } }

        public void AddAccount(Account a)
        {
            Accounts.Add(a);
        }
        public void AddClient(Client a)
        {
            Clients.Add(a);
        }
        public Client ClientById(int id)
        {
            Console.WriteLine(Clients[id]);
            return Clients[id];
        }

        public Account AccountById(int id)
        {
            Console.WriteLine(Accounts[id]);
            return Accounts[id];
        }

        public void Transaction(int id, decimal sum)
        {
            Accounts[id].balance += sum;
        }
    }
}