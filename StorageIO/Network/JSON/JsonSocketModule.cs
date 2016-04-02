using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
JsonSocketModule负责控制通信中发送消息及接收到消息后的处理。
JsonSocketModule应有多种实现，每种实现对应一种通信模式；每个实现对应的模式由type标明。
它可以接收外部主体（store, user之类的）并将其打包成Json字符串（先将其打包为一个中间变量再序列化）并发送。
它应有一个socketBasement。客户端和服务端对应的通信模式有区别。
*/

namespace StorageIO.Network.JSON
{
    public enum workType
    {
        STORE_IMPORT = 1,
        STORE_EXPORT = 2,
        STORE_EXCHANGE = 3,
        STORE_BACK = 4,//退货
        SELL = 5,
        STORE_VIEW_PRODUCT = 6,
        STORE_VIEW_IMPORTLOG = 7,
        STORE_VIEW_EXPORTLOG = 8,
        SOLDER_VIEW_SOLDLOG = 9,
        ADMIN_VIEW_SOLDLOG = 10,
        SAVE_ALL_MANULLY = 11,
        CHANGE_PASSWORD = 12,
        CHANGE_PERMISSION = 13,
        CREATE_USER = 14,
        LOGIN_TEST = 15
    }

    public enum networkState
    {
        CLIENT = 1,
        SERVER_SUCCESS = 2,
        SERVER_FAIL_AUTHORISING = 3,
        SERVER_FAIL_OPERATION = 4,
        SERVER_FAIL_UNKNOWN = 5
    }

    public class JsonObject
    {
        public workType type;
        public networkState state;
        public string comments;

        //对于服务器端，有一个名为Server的SuperAdmin账号
        public User user;
    }

    /// <summary>
    /// 一个可以让服务器简单的回复当前操作结果的类
    /// </summary>
    public class ServerResponseWithoutBody : JsonObject
    {
        public ServerResponseWithoutBody()
        {
            user = new User();
            user.userName = "Server";
            user.m_userType = userType.USER_SUPERADMIN;
            user.userPass = "------";
        }
    }

    public abstract class JsonSocketModule
    {
        protected userType minPermission;
        public workType type;
        public User user;

        public abstract string GenerateObjectClient();
        public abstract string GetObjectServer(string jsonString);

        //public abstract string GenerateObjectServer();
        //public abstract string GetObjectClient(string jsonString);

        public virtual bool GetAuthorised(User user)
        {
            if (CheckIfExists(user))
            {
                if (user.m_userType >= minPermission)//最少需要base权限
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public virtual bool CheckIfExists(User user)
        {
            //从数据库中查询当前这个用户的名字和密码对应的权限是否存在
            return true;
        }
    }
}
