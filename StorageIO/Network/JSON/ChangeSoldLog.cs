using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangeSoldLogObject : JsonObject
    {
        public SoldLog oriProduct;
        public SoldLog nowProduct;
    }

    class ChangeSoldLog : JsonSocketModule
    {
        public ChangeSoldLogObject obj;

        public ChangeSoldLog()
        {
            type = workType.CHANGE_SOLDLOG;
            minPermission = userType.USER_ADMIN;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangeSoldLogObject obj = JsonHelper.DeserializeJsonToObject<ChangeSoldLogObject>(jsonString);

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

                foreach (SoldLog l in serverMainHandler.GetSingleton().soldLogList)
                {
                    if (l.target == obj.oriProduct.target &&
                        l.cost == obj.oriProduct.cost &&
                        l.soldsmanName == obj.oriProduct.soldsmanName &&
                        l.comments == obj.oriProduct.comments &&
                        l.storeName == obj.oriProduct.storeName &&
                        l.taxed == obj.oriProduct.taxed &&
                        l.customer == obj.oriProduct.customer)
                    {
                        flag = true;
                        l.target = obj.nowProduct.target;
                        l.cost = obj.nowProduct.cost;
                        l.soldsmanName = obj.nowProduct.soldsmanName;
                        l.comments = obj.nowProduct.comments;
                        l.storeName = obj.nowProduct.storeName;
                        l.taxed = obj.nowProduct.taxed;
                        l.customer = obj.nowProduct.customer;
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
