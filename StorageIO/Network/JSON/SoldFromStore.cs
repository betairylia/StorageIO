using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class SellProductObject : JsonObject
    {
        public List<ProductStorage> products;
        public List<Money> cost;
        public Customer customer;
        public bool taxed;
    }

    public class SellFromStore : JsonSocketModule
    {
        public List<ProductStorage> products;
        List<Money> cost;
        Customer customer;
        bool taxed;

        public Store store;

        public SellFromStore()
        {
            type = workType.SELL;
            minPermission = userType.USER_SOLDER;
        }

        public override string GenerateObjectClient()
        {
            SellProductObject obj = new SellProductObject();
            obj.type = type;
            obj.user = user;
            obj.comments = comments;

            obj.products = products;
            obj.cost = cost;
            obj.customer = customer;
            obj.taxed = taxed;

            string s = JsonHelper.SerializeObject(obj);
            return s;
        }

        public override string GetObjectServer(string jsonString)
        {
            SellProductObject obj = JsonHelper.DeserializeJsonToObject<SellProductObject>(jsonString);

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                if (serverMainHandler.GetSingleton().sold(serverMainHandler.GetSingleton().GetStore(),
                    obj.products,
                    obj.cost,
                    obj.customer,
                    obj.taxed,
                    obj.user.userName))
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
