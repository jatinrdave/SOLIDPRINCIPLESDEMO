using System;

namespace SOLID.DEMOAPP.LSP_BEFORE
{
    //Liskov Substitute Principle Example
    //Requirement : Bank have facility to open Saving bank accounts (Regular, Salary).
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
        BankCard ATMCardDetails { get; set; }
        CheckBook CheckBookDetails { get; set; }
    }
    //Rule - Minimum balance should not be less than 1000 bucks.
    public class RegularSavingAccount : IBankAccount
    {
        public BankCard ATMCardDetails { get; set; }
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
    //No minimum balance.
    public class SalarySavingAccount : IBankAccount
    {
        public BankCard ATMCardDetails { get; set; }
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
    //New Requirement - Bank wants to have new account type for fixed deposit.
    public class FixDepositSavingAccount : IBankAccount
    {
        public double Balance { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public BankCard ATMCardDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public CheckBook CheckBookDetails { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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


}