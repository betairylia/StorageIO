using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageIO.Invoices;

namespace StorageIO
{
    public enum userType
    {
        USER_BASE           = 0x01,
        USER_SOLDER         = 0x01 | 0x02,
        USER_ADMIN          = 0x01 | 0x02 | 0x04,
        USER_SUPERADMIN     = 0x01 | 0x02 | 0x04 | 0x08
    }

    public abstract class User
    {
        public List<Permisson> permissonList;
        public userType m_userType = userType.USER_BASE;

        public virtual void init()
        {

        }

        public static User GetUserByName(string name)
        {
            //todo
            return new Solder();
        }

        public static List<User> userList;

        public static void SaveUsers(string fileName)
        {
            //todo
        }
    }

    public class Solder : User
    {
    }
}
