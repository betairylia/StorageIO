using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.ClientTables
{
    public class ProductView : ITableController
    {
        public List<ProductStorage> products;

        public void DoubleClicked(IRowShowable target)
        {
            throw new NotImplementedException();
        }

        public List<string> getColumns()
        {
            List<string> columns = new List<string>();
            columns.Add("产品类型");
            columns.Add("产品型号");
            columns.Add("产品机号");
            columns.Add("入库时间");
            columns.Add("交易金额");

            return columns;
        }

        public List<IRowShowable> getTableRawData()
        {
            List<IRowShowable> raw = new List<IRowShowable>();

            foreach (ProductStorage cell in products)
            {
                raw.Add(cell);
            }

            return raw;
        }

        public List<keyType> getTypes()
        {
            List<keyType> keyTypes = new List<keyType>();
            keyTypes.Add(keyType.KEY_STRING);
            keyTypes.Add(keyType.KEY_STRING);
            keyTypes.Add(keyType.KEY_STRING);
            keyTypes.Add(keyType.KEY_DATETIME);
            keyTypes.Add(keyType.KEY_NUMBER);

            return keyTypes;
        }
    }
}
