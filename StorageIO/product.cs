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
            //todo
            return new List<KeyValueProp>();
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
