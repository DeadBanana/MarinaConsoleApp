using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NormalName;

namespace BankSystem
{
    public delegate void MessageDelegate(string message);
    class AccountBank
    {
        string Name;
        int Balance;
        MessageDelegate Message = new MessageDelegate(Products.PrintMessage);

        public AccountBank(int Balance)
        {
            this.Balance = Balance;
        }
        public void RegDelegate(MessageDelegate messageDelegate)
        {

        }
        public void PutMoney(int Balance)
        {
            this.Balance += Balance;
            Message.Invoke("Пополнение баланса на " + Balance + " денег, теперь ваш баланс: " + this.Balance);
        }
        public void TakeMoney(int Balance)
        {
            if (this.Balance < Balance)
            {
                Message.Invoke("Ваш баланс: " + this.Balance + "средств не хватает");
            }
            else
            {
                this.Balance -= Balance;
                Message.Invoke("Пополнение баланса на " + Balance + "денег, теперь ваш баланс: " + this.Balance);
            }
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                AccountBank accountBank = new AccountBank(100);
                MessageDelegate messageDelegate = new MessageDelegate(Products.StatisticsOperations);
                accountBank.RegDelegate(messageDelegate);
                accountBank.PutMoney(100);
                accountBank.TakeMoney(30);
                accountBank.TakeMoney(30);
                Console.ReadKey();
            }
        }
    }
}
