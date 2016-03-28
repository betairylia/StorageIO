using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public interface IRowShowable
    {
        List<KeyValueProp> ListAllProp();

        /// <summary>
        /// 可能将要废弃，元素双击逻辑变为 ITableController.DoubleClicked( IRowShowable target )
        /// </summary>
        /// <returns></returns>
        List<KeyValueProp> DoubleClicked();
    }
}
