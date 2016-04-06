using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class RemoveCustomerObject : JsonObject
    {
        public Customer customer;
    }

    class RemoveCustomer : JsonSocketModule
    {
        public RemoveCustomerObject obj;

        public RemoveCustomer()
        {
            type = workType.DELETE_CUSTOMER;
            minPermission = userType.USER_SOLDER;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            RemoveCustomerObject obj = JsonHelper.DeserializeJsonToObject<RemoveCustomerObject>(jsonString);

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

                foreach (Customer l in serverMainHandler.GetSingleton().customerList)
                {
                    if (l.customerAddress == obj.customer.customerAddress &&
                        l.customerName == obj.customer.customerName &&
                        l.customerSexual == obj.customer.customerSexual &&
                        l.customerTel == obj.customer.customerTel &&
                        l.soldsmanName == obj.customer.soldsmanName)
                    {
                        serverMainHandler.GetSingleton().customerList.Remove(l);
                        simpleRes.state = networkState.SERVER_SUCCESS;
                        return JsonHelper.SerializeObject(simpleRes);
                    }
                }

                simpleRes.state = networkState.SERVER_FAIL_OPERATION;
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
