using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangeCustomerObject : JsonObject
    {
        public Customer oriProduct;
        public Customer nowProduct;
    }

    class ChangeCustomer : JsonSocketModule
    {
        public ChangeCustomerObject obj;

        public ChangeCustomer()
        {
            type = workType.CHANGE_CUSTOMER;
            minPermission = userType.USER_SOLDER;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangeCustomerObject obj = JsonHelper.DeserializeJsonToObject<ChangeCustomerObject>(jsonString);

            Store store = serverMainHandler.GetSingleton().GetStore();

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                bool flag = false;

                foreach (Customer l in serverMainHandler.GetSingleton().customerList)
                {
                    if (l.customerAddress == obj.oriProduct.customerAddress &&
                        l.customerName == obj.oriProduct.customerName &&
                        l.customerSexual == obj.oriProduct.customerSexual &&
                        l.customerTel == obj.oriProduct.customerTel &&
                        l.soldsmanName == obj.oriProduct.soldsmanName)
                    {
                        flag = true;
                        l.customerAddress = obj.nowProduct.customerAddress;
                        l.customerName = obj.nowProduct.customerName;
                        l.customerSexual = obj.nowProduct.customerSexual;
                        l.customerTel = obj.nowProduct.customerTel;
                        l.soldsmanName = obj.nowProduct.soldsmanName;
                    }
                }

                if (flag)
                {
                    simpleRes.state = networkState.SERVER_SUCCESS;
                }
                else
                {
                    simpleRes.state = networkState.SERVER_FAIL_OPERATION;
                }

                return JsonHelper.SerializeObject(simpleRes);
            }
            catch (Exception ex)
            {
                simpleRes.state = networkState.SERVER_FAIL_UNKNOWN;
                return JsonHelper.SerializeObject(simpleRes);
            }
        }
    }
}
