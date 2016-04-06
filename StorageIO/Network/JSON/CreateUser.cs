using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageIO.Network.JSON
{
    class CreateUser : JsonSocketModule
    {
        JsonObject obj;

        public CreateUser()
        {
            type = workType.CREATE_USER;
            minPermission = userType.USER_BASE;
        }

        public override string GenerateObjectClient()
        {
            return JsonHelper.SerializeObject(obj);
        }

        public override string GetObjectServer(string jsonString)
        {
            ServerResponseWithoutBody simpleRes = new ServerResponseWithoutBody();

            try
            {
                JsonObject obj = JsonHelper.DeserializeJsonToObject<JsonObject>(jsonString);

                foreach(User u in User.userList)
                {
                    if(u == obj.user)
                    {
                        simpleRes.state = networkState.SERVER_FAIL_OPERATION;
                        return JsonHelper.SerializeObject(simpleRes);
                    }
                }

                User.userList.Add(obj.user);

                simpleRes.state = networkState.SERVER_SUCCESS;
                return JsonHelper.SerializeObject(simpleRes);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                simpleRes.state = networkState.SERVER_FAIL_UNKNOWN;
                return JsonHelper.SerializeObject(simpleRes);
            }
        }
    }
}
