using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace SSproject
{
    public class User
    {
        string UserID { get; set; }
        string Password { set; get; }
        string EmailID { set; get; }
        string Role { set; get; }
        string Dept { set; get; }
        string UserType { set; get; }
        string Name { set; get; }
        /// <summary>
        /// Creates an user object for an existing user.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        public User(string userID, string password)
        {
            DataAccessor objDb = new DataAccessor();
            DataTable dt = objDb.getValidLogin(userID, password);
            UserID = userID;
            Password = password;
            Role = dt.Rows[0][2].ToString();
            Dept = dt.Rows[0][2].ToString();
            UserType = dt.Rows[0][2].ToString();
            Name = dt.Rows[0][3].ToString();
            EmailID = dt.Rows[0][4].ToString();
        }
        /// <summary>
        /// To add new user request.
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="requestRole"></param>
        public static void AddUser(string userID, string password, string email, string requestRole)
        {
        }
        /// <summary>
        /// gets the role of the user.
        /// </summary>
        /// <returns></returns>
        public string getRole()
        {
            return Role;
        }
        public string getUserID()
        {
            return UserID;
        }
        public string getDept()
        {
            return Dept;
        }
        public string getUserType()
        {
            return UserType;
        }
        public string getEmailID()
        {
            return EmailID;
        }
        public void deleteUser()
        { }
        public void editUser()
        {
        }
        public string getName()
        {
            return Name;
        }
    }
}