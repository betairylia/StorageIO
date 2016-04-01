using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StorageIO.Invoices;

namespace StorageIO
{
    //Table: 输出本仓库全部存货信息
    //进库，出库，自动产生记录
    public class Store : ITableController
    {
        /// <summary>
        /// 进货
        /// </summary>
        /// <param name="product">进的货物</param>
        /// <param name="cost">进货价</param>
        /// <returns>是否成功</returns>
        public bool Import(Product product, Money cost)
        {
            try
            {
                ProductStorage pStorage = new ProductStorage();

                pStorage.m_product = product;
                pStorage.importCost = cost;
                pStorage.importTime = DateTime.Now;
                
                ImportLog log = new ImportLog(pStorage);
                importLogList.Add(log);

                storageList.Add(pStorage);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 出货
        /// </summary>
        /// <param name="product">出货的货物</param>
        /// <returns>是否成功</returns>
        public bool Export(ProductStorage product)
        {
            try
            {
                //exportLog
                return storageList.Remove(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// 换货
        /// </summary>
        /// <param name="inProduct">退进来的货</param>
        /// <param name="outProduct">拿出去的货</param>
        /// <returns>是否成功</returns>
        public bool Exchange(Product inProduct, ProductStorage outProduct)
        {
            try
            {
                Money cost = new Money(0x0);
                Import(inProduct, cost);
                Export(outProduct);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        /// <summary>
        /// 换货
        /// </summary>
        /// <param name="inProduct">退进来的货</param>
        /// <param name="outProduct">拿出去的货</param>
        /// <param name="cost">价格</param>
        /// <returns>是否成功</returns>
        public bool Exchange(Product inProduct, ProductStorage outProduct, Money cost)
        {
            return false;
        }

        public void SaveStorageToFile(string fileName)
        {
            //todo
        }

        public void DoubleClicked(IRowShowable target)
        {
            ProductStorage productSelected = (ProductStorage)target;
            //弹出窗口显示详细信息
        }

        public List<IRowShowable> getTableRawData()
        {
            List<IRowShowable> raw = new List<IRowShowable>();

            foreach (ProductStorage cell in storageList)
            {
                raw.Add(cell);
            }

            return raw;
        }

        List<ExportLog> exportLogList;
        List<ImportLog> importLogList;
        List<ProductStorage> storageList;
    }
}
