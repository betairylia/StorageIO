using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class Money
    {
        public Money()
        {
            //ctor
        }

        public Money(double amount)
        {
            realAmount = amount / exchangeRate;
        }

        public double realAmount;
        static public double exchangeRate = 1.00;

        public double get()
        {
            return realAmount * exchangeRate;
        }

        public override string ToString()
        {
            return "￥ " + realAmount.ToString("0.00");
        }
    }
}
