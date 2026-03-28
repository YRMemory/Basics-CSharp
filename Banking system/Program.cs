namespace Banking_system
{
    class BankAccount
    {
        public string Owner { get; set; }
        public int Balance { get; protected set; }

        public BankAccount(string owner, int balance)
        {
            Owner = owner;
            Balance = balance;
        }

        public virtual void Deposit(int amount)
        {
            Balance += amount;
        }

        public virtual bool Withdraw(int amount)
        {
            if (Balance >= amount && amount > 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public virtual void Transfer(BankAccount target, int amount)
        {
            if (Withdraw(amount)) target.Deposit(amount);
        }
    }

    class BonusAccount : BankAccount
    {
        public BonusAccount(string name, int balance) : base(name, balance) { }
        public override void Deposit(int amount)
        {
            Balance += amount + 10;
        }

    }

    class BusinessAccount : BankAccount
    {
        public BusinessAccount(string name, int balance) : base(name, balance) { }
        public override bool Withdraw(int amount)
        {
            if (Balance >= amount + 5 && amount + 5 > 0)
            {
                Balance -= amount + 5;
                return true;
            }
            return false;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BusinessAccount businessAccount = new BusinessAccount("счет Компании", 1000);
            BonusAccount bonusAccount = new BonusAccount("счет Сотрудника", 0);
            Console.WriteLine($"{businessAccount.Owner}: {businessAccount.Balance}\n{bonusAccount.Owner}: {bonusAccount.Balance}");
            while (businessAccount.Balance >= 100)
            {
                businessAccount.Transfer(bonusAccount, 100);
                Console.WriteLine($"{businessAccount.Owner}: {businessAccount.Balance}\n{bonusAccount.Owner}: {bonusAccount.Balance}");
            }
        }
    }
}
