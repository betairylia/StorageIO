using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StorageIO.Network;
using StorageIO.Network.JSON;
using System.Windows.Forms;

namespace StorageIO
{
    class ToolBox
    {
        public static bool CheckServerResponse(ServerResponseWithoutBody res)
        {
            if(res.user.userName != "Server" || res.state == networkState.SERVER_FAIL_UNKNOWN)
            {
                MessageBox.Show("发生未知错误！");
                return false;
            }

            switch(res.state)
            {
                case networkState.SERVER_SUCCESS:
                    MessageBox.Show("操作成功！");
                    return true;
                case networkState.SERVER_FAIL_AUTHORISING:
                    MessageBox.Show("无权限或用户认证失败，请重新登录！\r\n");
                    return false;
                case networkState.SERVER_FAIL_OPERATION:
                    MessageBox.Show("操作失败！请仔细检查并重新尝试！");
                    return false;
                default:
                    return false;
            }
            
        }
    }
}
