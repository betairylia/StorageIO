using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class ViewProductTypeClassReturns : ServerResponseWithoutBody
    {
        public List<ProductTypeClass> products = new List<ProductTypeClass>();
    }

    public class ViewProductTypeClassProduct : JsonSocketModule
    {
        public Store store;

        public ViewProductTypeClassProduct()
        {
            type = workType.PRODUCT_TYPECLASS_LIST;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            JsonObject obj = new JsonObject();
            obj.type = type;
            obj.user = user;
            obj.comments = comments;

            string s = JsonHelper.SerializeObject(obj);
            return s;
        }

        public override string GetObjectServer(string jsonString)
        {
            JsonObject obj = JsonHelper.DeserializeJsonToObject<JsonObject>(jsonString);

            ViewProductTypeClassReturns simpleRes = new ViewProductTypeClassReturns();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                simpleRes.products = Product.productTypeClassList;
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
