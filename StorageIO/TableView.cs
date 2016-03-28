using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class TableView
    {
        /// <summary>
        /// 给某个键添加过滤器，过滤器可以同时存在多个。如果这个键已经有过滤器了则会被覆盖。
        /// </summary>
        /// <param name="key">过滤器的键值</param>
        /// <param name="value">过滤器的值</param>
        public void setFliter(string key, string value)
        {
            //todo
        }

        /// <summary>
        /// 移除某个键的过滤器。要想替换的话请直接使用setFliter。
        /// </summary>
        /// <param name="key">过滤器的键值</param>
        public void dismissFliter(string key)
        {
            //todo
        }

        /// <summary>
        /// 清空所有的过滤器
        /// </summary>
        public void clearFliters()
        {
            //todo
        }

        /// <summary>
        /// 按键值排序。
        /// </summary>
        /// <param name="key">作为关键字的键值</param>
        public void sort(string key)
        {
            //todo
        }

        /// <summary>
        /// 添加一行
        /// </summary>
        /// <param name="row">要添加的行</param>
        public void addRow(List<IRowShowable> row)
        {
            //todo
        }

        /// <summary>
        /// 清除表内数据
        /// </summary>
        public void clear()
        {
            //todo
        }

        /// <summary>
        /// 获取某行的数据
        /// </summary>
        /// <param name="rowID">行序号</param>
        /// <returns>该行的数据</returns>
        public IRowShowable getRow(int rowID)
        {
            return dataStorage[rowID];
        }

        /// <summary>
        /// 删除某一行
        /// </summary>
        /// <param name="rowID">行序号</param>
        public void deleteRow(int rowID)
        {
            //todo
        }

        /// <summary>
        /// 刷新显示
        /// </summary>
        public void flushView()
        {
            //todo
        }

        /// <summary>
        /// 直接获得表内的数据，请谨慎使用。
        /// </summary>
        /// <returns>表的数据</returns>
        public List<IRowShowable> _getRawData()
        {
            return dataStorage;
        }

        //触发器：双击某一行会触发这一行中对象的DoubleClicked()，并返回给表管理器该对象的索引。

        List<KeyValueProp> fliters;
        List<IRowShowable> dataStorage;
        ITableController controller;
    }
}
