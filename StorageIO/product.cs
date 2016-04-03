using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class Product : IRowShowable
    {
        public string productType { get; set; }//类型
        public string productClass { get; set; }//具体型号
        public string MNo;
        public bool hasMNo = false;

        public List<KeyValueProp> ListAllProp()
        {
            List<KeyValueProp> result = new List<KeyValueProp>();
            
            result.Add(new StringKeyValueProp("产品类型", productType));
            result.Add(new StringKeyValueProp("产品型号", productClass));

            if (hasMNo)
            {
                result.Add(new StringKeyValueProp("产品机号", MNo));
            }
            else
            {
                result.Add(new StringKeyValueProp("产品机号", "无机号"));
            }

            return result;
        }

        public object DoubleClicked()
        {
            return new List<KeyValueProp>();
        }

        public void setMNo(string _MNo)
        {
            MNo = _MNo;
            hasMNo = true;
        }
    }
}
