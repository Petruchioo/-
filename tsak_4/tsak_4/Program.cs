using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tsak_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Account
    {
        private decimal _bankCardAmountInRub = 0; // в полях насрано (названия не отображают сущность полей)
        private decimal _googlePayAmount = 0;

        public void Deposit(bool isBankCard, decimal amount)
        {
            if (isBankCard)
            {
                _bankCardAmountInRub += amount;
            }
            else
            {
                _googlePayAmount += amount;
            }
        }

        public void Withdraw(bool isBankCard, decimal amount)
        {
            if (isBankCard)
            {
                ThrowIfNotEnoughMoney(_bankCardAmountInRub, amount);
                _bankCardAmountInRub -= amount;
            }
            else
            {
                ThrowIfNotEnoughMoney(_googlePayAmount, amount);
                _googlePayAmount -= amount;
            }
        }

        public decimal GetAccountMoneyInRub(bool isBankCard) => isBankCard ?
            _bankCardAmountInRub : _googlePayAmount;  //проблема с названием, если мы хотим вернуть AccountMoneyInRub то метод не должен возвращать _googlePayAmount;

        private static void ThrowIfNotEnoughMoney(decimal accountAmountMoney, decimal tryToWithdraw)
        {
            if (accountAmountMoney - tryToWithdraw < 0)
            {
                throw new ArgumentException("Can't withdraw more than money on account");
            }
        }
    }
}
