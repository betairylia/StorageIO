using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class ProductStorage : IRowShowable
    {
        public Product m_product;
        public DateTime importTime;//进货时间
        public Money importCost { get; set; }//进货金额

        public int storageID;

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
