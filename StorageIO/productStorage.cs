﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO
{
    class ProductStorage : IRowShowable
    {
        public Product m_product;
        public DateTime importTime;

        public int storageID;

        public List<KeyValueProp> ListAllProp()
        {
            return new List<KeyValueProp>();
        }

        public List<KeyValueProp> DoubleClicked()
        {
            return new List<KeyValueProp>();
        }
    }
}
