using System;

namespace Bok.Models
{
    public class BankEntry
    {
       

        public string amount { get; }
        public string balance { get; }
        public DateTime transactionDate { get; }
        public string account { get; }
     

        public BankEntry(DateTime dateTime, string account, string amount, string balance)
        {
            this.transactionDate = dateTime;
            this.account = account;
            this.amount = amount;
            this.balance = balance;
        }

   
        public override string ToString()
        {
            return amount + balance + account;
        }
    }
}