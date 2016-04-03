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
            List<KeyValueProp> result = new List<KeyValueProp>();

            result.AddRange(m_product.ListAllProp());
            result.Add(new DateTimeKeyValueProp("入库时间", importTime));
            result.Add(new NumberKeyValueProp("交易金额", importCost.realAmount));

            return result;
        }

        public object DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
