using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StorageIO
{
    public class TableView
    {
        class Fliter
        {
            public Fliter(KeyValueProp p, char t)
            {
                prop = p;
                type = t;
            }

            public KeyValueProp prop;
            public char type;

            public bool check(List<KeyValueProp> obj)
            {
                if (type == 'd') { return true; }//这个过滤器不起作用

                bool flag = true;
                foreach(KeyValueProp p in obj)
                {
                    if (p.type == prop.type && p.key == prop.key)
                    {
                        switch (p.type)
                        {
                            case keyType.KEY_STRING:
                                return ((StringKeyValueProp)p) == ((StringKeyValueProp)prop);
                            case keyType.KEY_NUMBER:
                                switch(type)
                                {
                                    case '<':
                                        return ((NumberKeyValueProp)p) < ((NumberKeyValueProp)prop);
                                    case '>':
                                        return ((NumberKeyValueProp)p) > ((NumberKeyValueProp)prop);
                                    case '=':
                                        return ((NumberKeyValueProp)p) == ((NumberKeyValueProp)prop);
                                    default:
                                        return false;
                                }
                            case keyType.KEY_DATETIME:
                                switch (type)
                                {
                                    case '<':
                                        return ((DateTimeKeyValueProp)p) < ((DateTimeKeyValueProp)prop);
                                    case '>':
                                        return ((DateTimeKeyValueProp)p) > ((DateTimeKeyValueProp)prop);
                                    case '=':
                                        return ((DateTimeKeyValueProp)p) == ((DateTimeKeyValueProp)prop);
                                    default:
                                        return false;
                                }
                            default:
                                return false;
                        }
                    }
                }
                return flag;
            }
        }

        /// <summary>
        /// 给某个键添加过滤器，过滤器可以同时存在多个。如果这个键已经有过滤器了则会被覆盖。
        /// </summary>
        /// <param name="key">过滤器的键值</param>
        /// <param name="value">过滤器的值</param>
        public void setFliter(string key, object value, char type)
        {
            try
            {
                int index = columns.FindIndex((c) => { return c == key; });

                fliters[index].type = type;

                switch (types[index])
                {
                    case keyType.KEY_STRING:
                        ((StringKeyValueProp)fliters[index].prop).value = (string)value;
                        return;
                    case keyType.KEY_NUMBER:
                        ((NumberKeyValueProp)fliters[index].prop).value = (double)value;
                        return;
                    case keyType.KEY_DATETIME:
                        ((DateTimeKeyValueProp)fliters[index].prop).value = (DateTime)value;
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
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
        /// 根据过滤器生成showProps
        /// </summary>
        public void flushFliters()
        {
            showProps.Clear();
            int tmpCounter = 0;

            foreach(IRowShowable row in dataStorage)
            {
                tmpCounter++;

                bool flag = true;
                List<KeyValueProp> props = row.ListAllProp();

                foreach (Fliter fliter in fliters)
                {
                    if (!fliter.check(props))
                    {
                        flag = false;
                        break;
                    }
                }

                if(flag)
                {
                    showProps.Add(row);
                }
            }
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
        public void addRow(IRowShowable row)
        {
            //todo
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">要添加的数据</param>
        public void add(List<IRowShowable> data)
        {

        }

        /// <summary>
        /// 清除表内数据
        /// </summary>
        public void clear()
        {
            dataStorage.Clear();
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
            //显示
            //清除所有行
            gridView.Rows.Clear();

            int tmpCounter = 0;

            //添加行
            DataGridViewRow row;
            foreach(IRowShowable listRow in showProps)
            {
                row = new DataGridViewRow();
                row.CreateCells(gridView);

                List<KeyValueProp> listProp = listRow.ListAllProp();

                for (int i = 0; i < listProp.Count; i++) 
                {
                    row.Cells[i+1].Value = listProp[i].ToString();
                }

                row.Cells[0].Value = tmpCounter;
                tmpCounter++;

                gridView.Rows.Add(row);
            }
        }

        public void init()
        {
            //绑定gridView的各种事件
            gridView.CellDoubleClick += GridView_CellDoubleClick;
            gridView.CellClick += GridView_CellClick;

            //获得列信息
            columns = controller.getColumns();
            types = controller.getTypes();

            //添加第一列“序号”
            columns.Insert(0, "序号");
            types.Insert(0, keyType.KEY_NUMBER);

            //设置过滤器种类
            fliters = new List<Fliter>();

            for (int i = 0; i < columns.Count; i++)
            {
                KeyValueProp p;
                if (types[i] == keyType.KEY_STRING) { p = new StringKeyValueProp(columns[i], ""); }
                else if (types[i] == keyType.KEY_NUMBER) { p = new NumberKeyValueProp(columns[i], 0.0); }
                else { p = new DateTimeKeyValueProp(columns[i], DateTime.Now); }

                Fliter fliter = new Fliter(p, 'd');
                fliters.Add(fliter);
            }

            //设置只读
            gridView.ReadOnly = true;

            //移除空行
            gridView.AllowUserToAddRows = false;

            //添加列
            DataGridViewTextBoxColumn col;
            foreach (string s in columns)
            {
                col = new DataGridViewTextBoxColumn();
                col.Name = s;
                col.HeaderText = s;

                gridView.Columns.Add(col);
            }

            //设置第一列为int型
            gridView.Columns[0].ValueType = typeof(int);

            //设置第一列的颜色
            gridView.Columns[0].DefaultCellStyle.BackColor = System.Drawing.Color.LightPink;

            showProps = new List<IRowShowable>();
        }

        public void flushData()
        {
            //获得数据
            dataStorage = controller.getTableRawData();
        }

        /// <summary>
        /// 刷新全部信息
        /// </summary>
        public void flushAll()
        {
            flushData();
            flushFliters();
            flushView();
        }

        #region 各种事件

        public delegate void IRowShowableSelected(object sender, IRowShowable selected);
        public event IRowShowableSelected RowSelected;
        public event IRowShowableSelected RowDoubleClicked;
        
        private void GridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            if(RowSelected != null)
            {
                int indexID = (int)(((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value);
                RowSelected(sender, showProps[indexID]);
            }
        }

        int doubleClickIndex = -1;

        private void GridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (doubleClickIndex > 0) { return; }

            if (e.ColumnIndex < 1) { return; }

            if (e.RowIndex < 0)
            {
                FliterSettingPage fliterSet = new FliterSettingPage(
                    types[e.ColumnIndex],
                    fliters[e.ColumnIndex].type.ToString(),
                    fliters[e.ColumnIndex].prop.getValue(),
                    fliters[e.ColumnIndex].prop.key);

                doubleClickIndex = e.ColumnIndex;

                fliterSet.FormClosed += FliterSet_FormClosed;
                fliterSet.FliterSetted += FliterSet_FliterSetted;

                fliterSet.Show();
            }
            else
            {
                if(RowDoubleClicked != null)
                    RowDoubleClicked(sender, showProps[e.RowIndex]);
            }
        }

        private void FliterSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            doubleClickIndex = -1;
        }

        private void FliterSet_FliterSetted(object sender, char type, object value)
        {
            fliters[doubleClickIndex].type = type;

            if(type != 'd')
            {
                fliters[doubleClickIndex].prop.setValue(value);
                gridView.Columns[doubleClickIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Aqua;
            }
            else
            {
                gridView.Columns[doubleClickIndex].DefaultCellStyle.BackColor = System.Drawing.Color.White;
            }

            this.flushFliters();
            this.flushView();
        }

        #endregion

        /// <summary>
        /// 直接获得表内的数据，请谨慎使用。
        /// </summary>
        /// <returns>表的数据</returns>
        public List<IRowShowable> _getRawData()
        {
            return dataStorage;
        }

        //触发器：双击某一行会触发这一行中对象的DoubleClicked()，并返回给表管理器该对象的索引。

        List<Fliter> fliters;

        List<IRowShowable> showProps;
        List<string> columns;
        List<keyType> types;

        List<IRowShowable> dataStorage;
        public ITableController controller;

        public DataGridView gridView;
    }
}
