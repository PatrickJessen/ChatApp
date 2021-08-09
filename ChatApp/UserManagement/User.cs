using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.UserManagement
{
    class User
    {
        public int UserId { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }

        public User(int userId, string name, string lastName, string username, string password, string email, string country)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            Username = username;
            Password = password;
            Email = email;
            Country = country;
        }
    }
}
