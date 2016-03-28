using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    /// <summary>
    /// 表呈现器TableView对应的事件控制器。
    /// </summary>
    interface ITableController
    {
        /// <summary>
        /// 处理表中元素被双击的事件。
        /// </summary>
        /// <param name="target">被双击的元素</param>
        void DoubleClicked(IRowShowable target);
    }
}
