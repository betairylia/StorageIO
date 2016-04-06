using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StorageIO.Invoices;

using System.IO;
using StorageIO.Network;

namespace StorageIO
{
    public enum userType
    {
        USER_WRONG_PASS     = 0,
        USER_BASE           = 1,
        USER_SOLDER         = 2,
        USER_ADMIN          = 3,
        USER_SUPERADMIN     = 4
    }

    public class User
    {
        //public List<Permisson> permissonList;
        public userType m_userType = userType.USER_BASE;

        public string userName, userPass;

        public static bool operator ==(User l, User r)
        {
            return l.userName == r.userName;
        }

        public static bool operator !=(User l, User r)
        {
            return l.userName != r.userName;
        }

        public virtual void init()
        {

        }

        public static List<User> userList;

        public static void LoadUsers(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);

                byte[] dataBuffer = new byte[65536];
                file.Seek(0, SeekOrigin.Begin);
                file.Read(dataBuffer, 0, 65536);

                userList = JsonHelper.DeserializeJsonToList<User>(
                    Encoding.Default.GetString(dataBuffer));

                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static void SaveUsers(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Create);

                byte[] data = Encoding.Default.GetBytes(JsonHelper.SerializeObject(userList));
                file.Write(data, 0, data.Length);

                file.Flush();
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public static bool CreateUser(string userName, string userPass)
        {
            User newUser = new User();
            newUser.userName = userName;
            newUser.userPass = userPass;

            foreach (User u in userList)
            {
                if (u == newUser)
                {
                    return false;
                }
            }

            userList.Add(newUser);
            return true;
        }

        public static User GetUserByName(string name)
        {
            foreach (User u in userList)
            {
                if(u.userName == name)
                {
                    return u;
                }
            }
            return null;
        }

        public static userType GetUserPermission(User user)
        {
            foreach (User u in userList)
            {
                if (u == user)
                {
                    if(u.userPass == user.userPass)
                    {
                        return u.m_userType;
                    }
                    else
                    {
                        return userType.USER_WRONG_PASS;
                    }
                }
            }
            return userType.USER_WRONG_PASS;
        }
    }

    public class Solder : User
    {
    }
}
