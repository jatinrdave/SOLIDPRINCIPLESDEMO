using System;

namespace SOLID.DEMOAPP.ISP_AFTER
{
    //Interface Segragation Principle Example
    public class BankCard
    {
    }

    public class CheckBook
    {
    }

    public interface IBankAccount
    {
        public double Balance { get; set; }
        void Deposit(double amount);
        bool Withdrawl(double amount);
    }
    public interface ISavingBankAccount : IBankAccount, IBankCard,IBankCheckBook
    {
    }

    public interface IBankCard
    {
        BankCard CardDetails { get; set; }

        //Bank Methods
    }

    public interface IBankCheckBook
    {
        CheckBook CheckBookDetails { get; set; }
        //Checkbook methods
    }

    public class RegularBankAccount : ISavingBankAccount
    {
        public BankCard CardDetails { get; set; }
        public CheckBook CheckBookDetails { get; set; }
        public double Balance { get; set; }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public bool Withdrawl(double amount)
        {
            double moneyAfterWithdrawal = Balance - amount;
            if (moneyAfterWithdrawal >= 1000)
            {
                Balance = moneyAfterWithdrawal;
                //update balace   
                return true;
            }
            else
                return false;
        }
    }
    public class SalaryBankAccount : ISavingBankAccount
    {
        public BankCard CardDetails { get; set; }
        public CheckBook CheckBookDetails { get; set; }
        public double Balance { get; set; }
        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public bool Withdrawl(double amount)
        {
            double moneyAfterWithdrawal = Balance - amount;
            //update balace   
            Balance = moneyAfterWithdrawal;

            return true;
        }
    }
    public class FixDepositBankAccount : IBankAccount
    {
        public double Balance { get; set; }
        public void Deposit(double amount)
        {
            Balance = amount;
        }

        public bool Withdrawl(double amount)
        {
            if (Balance - amount > 0)
            {
                Balance = Balance - amount;
                return true;
            }
            else
                return false;

        }


    }

    public class CreditCardAccount : IBankCard
    {
        public BankCard CardDetails { get; set; }

        //Checkbook methods
    }


}