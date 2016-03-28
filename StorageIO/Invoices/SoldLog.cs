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

        public List<KeyValueProp> DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
