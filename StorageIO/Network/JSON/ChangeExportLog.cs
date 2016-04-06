using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangeExportLogObject : JsonObject
    {
        public ExportLog oriProduct;
        public ExportLog nowProduct;
    }

    class ChangeExportLog : JsonSocketModule
    {
        public ChangeExportLogObject obj;

        public ChangeExportLog()
        {
            type = workType.CHANGE_EXPORTLOG;
            minPermission = userType.USER_ADMIN;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangeExportLogObject obj = JsonHelper.DeserializeJsonToObject<ChangeExportLogObject>(jsonString);

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

                foreach (ExportLog l in store.exportLogList)
                {
                    if (l.product == obj.oriProduct.product &&
                        l.exportTime == obj.oriProduct.exportTime &&
                        l.operatorName == obj.oriProduct.operatorName &&
                        l.comments == obj.oriProduct.comments)
                    {
                        flag = true;
                        l.product = obj.nowProduct.product;
                        l.exportTime = obj.nowProduct.exportTime;
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
