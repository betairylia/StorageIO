using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class Customer : IRowShowable, IPrintable
    {
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
