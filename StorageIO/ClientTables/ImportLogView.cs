using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.ClientTables
{
    public class ImportLogView : ITableController
    {
        public List<ImportLog> logs;

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
            columns.Add("操作员");
            columns.Add("备注");

            return columns;
        }

        public List<IRowShowable> getTableRawData()
        {
            List<IRowShowable> raw = new List<IRowShowable>();

            foreach (ImportLog log in logs)
            {
                raw.Add(log);
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
            keyTypes.Add(keyType.KEY_STRING);
            keyTypes.Add(keyType.KEY_STRING);

            return keyTypes;
        }
    }
}
