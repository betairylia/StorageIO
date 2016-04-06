using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Invoices
{
    public class SoldLog : IPrintable, IRowShowable
    {
        public string soldsmanName = "System";
        public string comments = "";
        public bool taxed;
        public Customer customer;
        public string storeName;//不显示
        public List<Money> cost;
        public List<ProductStorage> target;

        public SoldLog() { }
        public SoldLog(Solder _solder, Customer _customer, Store _store, List<ProductStorage> _target, List<Money> _cost, bool _taxed, string _comments)
        {
            soldsmanName = _solder.userName;
            cost = _cost;
            comments = _comments;
            taxed = _taxed;
            target = _target;
            customer = _customer;
        }

        //IPrintable
        public string print()
        {
            return "test";
        }

        //IRowShowable
        public List<KeyValueProp> ListAllProp()
        {
            return new List<KeyValueProp>();
        }

        public object DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
