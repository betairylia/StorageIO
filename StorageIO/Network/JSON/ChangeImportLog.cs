using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangeImportLogObject : JsonObject
    {
        public ImportLog oriProduct;
        public ImportLog nowProduct;
    }

    class ChangeImportLog : JsonSocketModule
    {
        public ChangeImportLogObject obj;

        public ChangeImportLog()
        {
            type = workType.CHANGE_IMPORTLOG;
            minPermission = userType.USER_ADMIN;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangeImportLogObject obj = JsonHelper.DeserializeJsonToObject<ChangeImportLogObject>(jsonString);

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

                foreach(ImportLog l in store.importLogList)
                {
                    if(l.importProduct == obj.oriProduct.importProduct &&
                        l.operatorName == obj.oriProduct.operatorName &&
                        l.comments == obj.oriProduct.comments)
                    {
                        flag = true;
                        l.importProduct = obj.nowProduct.importProduct;
                        l.operatorName = obj.nowProduct.operatorName;
                        l.comments = obj.nowProduct.comments;
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
