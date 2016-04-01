using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Invoices
{
    class ImportLog : IPrintable, IRowShowable
    {
        public string operatorName = "System";
        public ProductStorage importProduct;
        public string comments = "";

        public ImportLog() { }

        public ImportLog(ProductStorage _product, string _comment = "No comments")
        {
            importProduct = _product;
            comments = _comment;
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
