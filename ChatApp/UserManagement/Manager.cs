using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.DatabaseManagement;

namespace ChatApp.UserManagement
{
    class Manager
    {
        DBHandler handler = new DBHandler();

        public void AddUser(User user)
        {
            handler.AddUser(user);
        }

        public int GetLastUserId()
        {
            return handler.GetLastUserId();
        }

        public bool SearchLoginMatch(string username, string password)
        {
            return handler.SearchLoginMatch(username, password);
        }

        public bool DoesUsernameExist(string username)
        {
            return handler.DoesUsernameExist(username);
        }
    }
}
