using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Invoices
{
    public class ImportLog : IPrintable, IRowShowable
    {
        public string operatorName = "System";
        public ProductStorage importProduct;
        public string comments = "";

        public ImportLog() { }

        public ImportLog(ProductStorage _product, string _comment = "", string userName = "系统")
        {
            importProduct = _product;
            operatorName = userName;
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
            List<KeyValueProp> result = new List<KeyValueProp>();

            result.AddRange(importProduct.ListAllProp());
            result.Add(new StringKeyValueProp("操作员", operatorName));
            result.Add(new StringKeyValueProp("备注", comments));

            return result;
        }

        public object DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
