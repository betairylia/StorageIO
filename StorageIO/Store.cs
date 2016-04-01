using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StorageIO.Invoices;

namespace StorageIO
{
    //Table: 输出本仓库全部存货信息
    //进库，出库，自动产生记录
    public class Store
    {
        public bool Import(Product product)
        {
            return false;
        }

        public bool Export(int productID)
        {
            return false;
        }

        public bool Exchange(Product inProduct, int outProductID)
        {
            return false;
        }

        public void SaveStorageToFile(string fileName)
        {
            //todo
        }

        List<ExportLog> exportLogList;
        List<ImportLog> importLogList;
        List<ProductStorage> storageList;
    }
}
