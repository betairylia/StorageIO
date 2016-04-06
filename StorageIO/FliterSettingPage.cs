using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace StorageIO
{
    public partial class FliterSettingPage : Form
    {
        public delegate void FliterSet(object sender, char type, object value);
        public event FliterSet FliterSetted;

        keyType fliterType;

        public FliterSettingPage(keyType _fliterType, string type, object value, string key)
        {
            InitializeComponent();

            fliterType = _fliterType;
            
            this.Text = "设置过滤器 - " + key;

            switch (fliterType)
            {
                case keyType.KEY_STRING:

                    if(type == "d")
                    {
                        fliterInputBox.Text = "请输入要查找的文字，所有包含这串文字的项目都会被显示出来。";
                        fliterTypeBox.Items.Remove(">");
                        fliterTypeBox.Items.Remove("<");
                    }
                    else
                    {
                        fliterInputBox.Text = (string)value;
                        fliterTypeBox.SelectedItem = fliterTypeBox.Items[0];
                    }

                    break;
                case keyType.KEY_NUMBER:

                    if (type == "d")
                    {
                        fliterInputBox.Text = "请输入要比较的数值并选择比较类型。所有符合条件的项目都会被显示。";
                    }
                    else
                    {
                        fliterInputBox.Text = ((double)value).ToString();
                        fliterTypeBox.SelectedItem = fliterTypeBox.Items[fliterTypeBox.Items.IndexOf(type)];
                    }

                    break;
                case keyType.KEY_DATETIME:

                    if (type == "d")
                    {
                        fliterInputBox.Text = "请输入要比较的日期并选择比较类型。日期请用形如" + DateTime.Now.ToString("yyyy/MM/dd") + "的方式输入。";
                    }
                    else
                    {
                        fliterInputBox.Text = ((DateTime)value).ToString("yyyy/MM/dd");
                        fliterTypeBox.SelectedItem = fliterTypeBox.Items[fliterTypeBox.Items.IndexOf(type)];
                    }

                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            object obj = null;
            char type = '=';

            if(fliterInputBox.Text == "")
            {
                obj = null;
                type = 'd';
            }
            else
            {
                type = fliterTypeBox.GetItemText(fliterTypeBox.SelectedItem).ToCharArray()[0];

                try
                {
                    switch (fliterType)
                    {
                        case keyType.KEY_STRING:
                            obj = fliterInputBox.Text;
                            break;
                        case keyType.KEY_NUMBER:
                            obj = Double.Parse(fliterInputBox.Text);
                            break;
                        case keyType.KEY_DATETIME:
                            obj = DateTime.ParseExact(fliterInputBox.Text, "yyyy/MM/dd", System.Globalization.CultureInfo.CurrentCulture);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("信息格式输入有误！\r\n如果是数字型请确认是否输入除了数字和小数点以外的字符！\r\n如果是日期请确认输入正确形如\"2016/01/01\"，而不是\"2016/1/1\"！");
                    return;
                }
            }

            if (FliterSetted != null)
            {
                FliterSetted(this, type, obj);
            }

            this.Close();
        }

        private void fliterInputBox_Enter(object sender, EventArgs e)
        {
            if( this.Text == "请输入要查找的文字，所有包含这串文字的项目都会被显示出来。" ||
                this.Text == "请输入要比较的数值并选择比较类型。所有符合条件的项目都会被显示。" ||
                this.Text.Contains("请输入要比较的日期并选择比较类型。日期请用形如"))
            {
                this.Text = "";
            }
        }
    }
}
