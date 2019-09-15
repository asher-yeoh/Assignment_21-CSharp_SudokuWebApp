using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuWebApp.Models
{
    public class User
    {
        public int id;
        public string username;
        public string email;
        public bool active;
        public User(int id, string username, string email, bool active)
        {
            this.id = id;
            this.username = username;
            this.email = email;
            this.active = active;
        }
    }
}
