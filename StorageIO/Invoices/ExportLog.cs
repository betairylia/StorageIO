using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Invoices
{
    class ExportLog : IPrintable, IRowShowable
    {
        public string operatorName = "System";
        public DateTime exportTime;
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

        public object DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
