using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StorageIO.Invoices;

namespace StorageIO
{
    /// <summary>
    /// 构成服务器的主类；
    /// 包含着所有的数据但是没有UI。
    /// </summary>
    public class serverMainHandler
    {
        /// <summary>
        /// 销售物品。
        /// </summary>
        /// <param name="store">要销售的物品所在的仓库</param>
        /// <param name="target">要销售的物品</param>
        /// <param name="cost">总售价</param>
        /// <param name="customer">购买人</param>
        /// <param name="Taxed">是否含税</param>
        /// <returns>购买是否成功</returns>
        public bool sold(Store store, List<ProductStorage> target, Money cost, Customer customer, bool Taxed, string solderName)
        {
            if(User.GetUserByName(solderName).m_userType == userType.USER_SOLDER)
            {
                SoldLog log = new SoldLog((Solder)User.GetUserByName(solderName), customer, store, target, cost, Taxed, "");
                soldLogList.Add(log);
                
                foreach(ProductStorage pro in target)
                {
                    store.Export(pro);
                }

                return true;
            }
            return false;
        }

        public Store GetStore(int index = 0)
        {
            return storeList[index];
        }

        public void SaveToFile(string fileName)
        {

        }

        List<SoldLog> soldLogList;
        List<Store> storeList;
    }
}
