using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace StorageIO.Network.JSON
{
    public class ImportObject : JsonObject
    {
        public Product product;
        public Money cost;
    }

    public class ImportToStore : JsonSocketModule
    {
        public Product product;
        public Money cost;
        
        public Store store;

        public ImportToStore()
        {
            type = workType.STORE_IMPORT;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            ImportObject obj = new ImportObject();
            obj.type = type;
            obj.user = user;
            obj.product = product;
            obj.cost = cost;

            string s = JsonHelper.SerializeObject(obj);
            return s;
        }

        public override string GetObjectServer(string jsonString)
        {
            ImportObject obj = JsonHelper.DeserializeJsonToObject<ImportObject>(jsonString);

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                if (store.Import(obj.product, obj.cost, obj.comments + "（操作：进货）", obj.user.userName))
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

//===================================================================================//

        //public override string GenerateObjectServer()
        //{
        //    return "";
        //}

        //public override string GetObjectClient(string jsonString)
        //{
        //    return "";
        //}
    }
}
