using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public abstract class Product : IRowShowable
    {
        public string productType { get; set; }//类型
        public string productClass { get; set; }//具体型号
        public Money importCost { get; set; }//进货金额

        public List<KeyValueProp> ListAllProp()
        {
            //todo
            return new List<KeyValueProp>();
        }

        public List<KeyValueProp> DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }

    public abstract class ProductWithMNo : Product
    {
        public string MNo;
    }
}
