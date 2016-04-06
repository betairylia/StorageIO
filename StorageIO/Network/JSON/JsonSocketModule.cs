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
        STORE_IMPORT = 1,           //进货                            //Completed
        STORE_EXPORT = 2,           //出货                            //Completed
        STORE_EXCHANGE = 3,         //换货（废弃）                    //Completed
        STORE_BACK = 4,             //退货（废弃）                    //Completed
        SELL = 5,                   //销售                            //Completed
        STORE_VIEW_PRODUCT = 6,     //查看库存                        //Completed
        STORE_VIEW_IMPORTLOG = 7,   //查看入库记录                    //Completed
        STORE_VIEW_EXPORTLOG = 8,   //查看出库记录                    //Completed
        SOLDER_VIEW_SOLDLOG = 9,    //查看销售记录（个人）            //Completed
        ADMIN_VIEW_SOLDLOG = 10,    //查看销售记录（管理员）          //Completed
        SAVE_ALL_MANULLY = 11,      //保存全部信息                    //
        CHANGE_PASSWORD = 12,       //用户更改密码                    //Completed
        CHANGE_PERMISSION = 13,     //更改用户权限                    //Completed
        CREATE_USER = 14,           //创建用户                        //Completed
        GET_PREMISSION = 15,        //登录并获取权限                  //Completed
        SOLDER_VIEW_CUSTOMER = 16,  //查看客户列表（个人）            //Completed
        ADMIN_VIEW_CUSTOMER = 17,   //查看客户列表（管理员）          //Completed
        VIEW_ALL_USERS = 18,        //查看用户列表                    //Completed
        CHANGE_PRODUCTS = 19,       //更改产品                        //Completed
        CHANGE_IMPORTLOG = 20,      //更改入库信息                    //Completed
        CHANGE_EXPORTLOG = 21,      //更改出库信息                    //Completed
        CHANGE_CUSTOMER = 22,       //更改客户信息                    //Completed
        CHANGE_SOLDLOG = 23,        //更改销售记录                    //Completed
        PRODUCT_TYPECLASS_LIST = 24,//查看产品类型清单                //Completed
        CREATE_CUSTOMER = 25,       //创建新客户                      //Completed
        DELETE_CUSTOMER = 26,       //删除客户                        //Completed
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
        public string comments;

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
            if(user.m_userType <= User.GetUserPermission(user))
            {
                return true;
            }
            return false;
        }
    }
}
