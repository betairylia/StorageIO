using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangeProductObject : JsonObject
    {
        public ProductStorage oriProduct;
        public ProductStorage nowProduct;
    }

    class ChangeProduct : JsonSocketModule
    {
        public ChangeProductObject obj;

        public ChangeProduct()
        {
            type = workType.CHANGE_PRODUCTS;
            minPermission = userType.USER_ADMIN;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangeProductObject obj = JsonHelper.DeserializeJsonToObject<ChangeProductObject>(jsonString);

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

                if (store.Export(obj.oriProduct, obj.comments, obj.user.userName) &&
                    store.Import(obj.nowProduct.m_product, obj.nowProduct.importCost, obj.nowProduct.importTime, obj.comments, obj.user.userName))
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
