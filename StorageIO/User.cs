using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageIO.Invoices;

namespace StorageIO
{
    public enum userType
    {
        USER_BASE           = 1,
        USER_SOLDER         = 2,
        USER_ADMIN          = 3,
        USER_SUPERADMIN     = 4
    }

    public class User
    {
        public List<Permisson> permissonList;
        public userType m_userType = userType.USER_BASE;

        public string userName, userPass;

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
