using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StorageIO
{
    public class ProductTypeClass
    {
        public string productType;
        public string productClass;
        public bool hasMNo;
    }

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

        public static bool operator ==(Product l, Product r)
        {
            return (l.productType == r.productType && l.productClass == r.productClass && l.MNo == r.MNo);
        }

        public static bool operator !=(Product l, Product r)
        {
            return !(l == r);
        }

        #region 产品类型

        public static List<ProductTypeClass> productTypeClassList;

        public static void LoadProductTypeClass(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);

                byte[] dataBuffer = new byte[65536];
                file.Seek(0, SeekOrigin.Begin);
                file.Read(dataBuffer, 0, 65536);

                productTypeClassList = JsonHelper.DeserializeJsonToList<ProductTypeClass>(
                    Encoding.Default.GetString(dataBuffer));

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void SaveProductTypeClass(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Create);

                byte[] data = Encoding.Default.GetBytes(JsonHelper.SerializeObject(productTypeClassList));
                file.Write(data, 0, data.Length);

                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static List<string> GetProductTypes()
        {
            List<string> typesList = new List<string>();

            foreach(ProductTypeClass typeClass in productTypeClassList)
            {
                if(!typesList.Contains(typeClass.productType))
                {
                    typesList.Add(typeClass.productType);
                }
            }

            return typesList;
        }

        public static List<string> GetProductClasses(string type)
        {
            List<string> classesList = new List<string>();

            foreach (ProductTypeClass typeClass in productTypeClassList)
            {
                if (typeClass.productType == type)
                {
                    classesList.Add(typeClass.productClass);
                }
            }

            return classesList;
        }

        #endregion
    }
}
