using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class ViewStoreReturns : ServerResponseWithoutBody
    {
        public List<ProductStorage> products = new List<ProductStorage>();
    }

    public class ViewStoreProduct : JsonSocketModule
    {
        public Store store;

        public ViewStoreProduct()
        {
            type = workType.STORE_VIEW_PRODUCT;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            JsonObject obj = new JsonObject();
            obj.type = type;
            obj.user = user;

            string s = JsonHelper.SerializeObject(obj);
            return s;
        }

        public override string GetObjectServer(string jsonString)
        {
            JsonObject obj = JsonHelper.DeserializeJsonToObject<JsonObject>(jsonString);

            ViewStoreReturns simpleRes = new ViewStoreReturns();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }
                
                simpleRes.products = store.getStorageRawData();
                simpleRes.state = networkState.SERVER_SUCCESS;

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
