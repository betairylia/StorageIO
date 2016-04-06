using StorageIO.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    public class ViewSoldReturns : ServerResponseWithoutBody
    {
        public List<SoldLog> logs = new List<SoldLog>();
    }

    public class ViewSoldLog : JsonSocketModule
    {
        public ViewSoldLog()
        {
            type = workType.ADMIN_VIEW_SOLDLOG;
            minPermission = userType.USER_SOLDER;
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

            ViewSoldReturns simpleRes = new ViewSoldReturns();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                if(obj.user.m_userType < userType.USER_ADMIN)
                {
                    simpleRes.logs = new List<SoldLog>();
                
                    foreach(SoldLog l in serverMainHandler.GetSingleton().soldLogList)
                    {
                        if(l.soldsmanName == obj.user.userName)
                        {
                            simpleRes.logs.Add(l);
                        }
                    }
                }
                else
                {
                    simpleRes.logs = serverMainHandler.GetSingleton().soldLogList;
                }
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
