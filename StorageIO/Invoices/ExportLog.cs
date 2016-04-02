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
        public Product product;

        public ExportLog(Product _product, string _comm = "", string _userName = "系统")
        {
            operatorName = _userName;
            comments = _comm;
            product = _product;
            exportTime = DateTime.Now;
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
