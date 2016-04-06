using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class ChangePermissionObject : JsonObject
    {
        public userType newPermission;
    }

    class ChangePermission : JsonSocketModule
    {
        public ChangePermissionObject obj;

        public ChangePermission()
        {
            type = workType.CHANGE_PERMISSION;
            minPermission = userType.USER_SUPERADMIN;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ChangePermissionObject obj = JsonHelper.DeserializeJsonToObject<ChangePermissionObject>(jsonString);

            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();
            simpleRes.type = type;

            try
            {
                if (!GetAuthorised(obj.user))
                {
                    simpleRes.state = networkState.SERVER_FAIL_AUTHORISING;
                    return JsonHelper.SerializeObject(simpleRes);
                }

                User.userList.Find((c) => { return c == obj.user; }).m_userType = obj.newPermission;
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
