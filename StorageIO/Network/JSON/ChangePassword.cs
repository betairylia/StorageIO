using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangePasswordObject : JsonObject
    {
        public string newPassword;
    }

    class ChangePassword : JsonSocketModule
    {
        public ChangePasswordObject obj;

        public ChangePassword()
        {
            type = workType.CHANGE_PASSWORD;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangePasswordObject obj = JsonHelper.DeserializeJsonToObject<ChangePasswordObject>(jsonString);

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                User.userList.Find((c) => { return c == obj.user; }).userPass = obj.newPassword;
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
