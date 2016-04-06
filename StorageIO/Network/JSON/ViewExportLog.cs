using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class ViewExportReturns : ServerResponseWithoutBody
    {
        public List<ExportLog> logs = new List<ExportLog>();
    }

    public class ViewExportLog : JsonSocketModule
    {
        public Store store;

        public ViewExportLog()
        {
            type = workType.STORE_VIEW_EXPORTLOG;
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

            ViewExportReturns simpleRes = new ViewExportReturns();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                simpleRes.logs = store.exportLogList;
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
