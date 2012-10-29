using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSproject
{
    public class SysAdmin
    {
        string UserID { get; set; }
        string Password { set; get; }
        SysAdmin(string userID, string password)
        {
            if (authenticateSysAdmin(userID, password))
            {
                UserID = userID;
                Password = password;
            }
        }
        private bool authenticateSysAdmin(string userID, string password)
        {
            return true;
        }
        private void approveUserRequest(string userID, string requestID)
        { 
        }
        private void rejectUser(string userID, string requestID)
        { 
        }
    }
}