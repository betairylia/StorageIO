using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    abstract class Product
    {
        public string productType { get; set; }//类型
        public string productClass { get; set; }//具体型号
        public abstract List<KeyValueProp> listAllProp();
    }

    abstract class ProductWithMNo : Product
    {
        public string MNo;
    }
}
