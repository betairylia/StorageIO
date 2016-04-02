using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class ExportObject : JsonObject
    {
        public ProductStorage product;
    }

    public class ExportFromStore : JsonSocketModule
    {
        public ProductStorage product;

        public Store store;

        public ExportFromStore()
        {
            type = workType.STORE_EXPORT;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            ExportObject obj = new ExportObject();
            obj.type = type;
            obj.user = user;
            obj.product = product;

            string s = JsonHelper.SerializeObject(obj);
            return s;
        }

        public override string GetObjectServer(string jsonString)
        {
            ExportObject obj = JsonHelper.DeserializeJsonToObject<ExportObject>(jsonString);

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                if (store.Export(obj.product, obj.comments + "（操作：普通出货）", obj.user.userName))
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
