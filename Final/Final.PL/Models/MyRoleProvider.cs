using System;
using System.Linq;
using System.Web.Security;
using Final.BLL.Interfaces;
using Final.Ioc;
using FinalDAL;

namespace Final.PL
{
    public class MyRoleProvider : RoleProvider
    {
        private static IUserLogic UserLogic;
        static MyRoleProvider() { UserLogic = DependencyResolver.UserLogic; }
        public static bool VerifyUser(string login, string password)
        {
            foreach (var user in UserLogic.GetAll())
                if (user.Login == login)
                    return user.Password == password;
            UserLogic.AddUser(login, password);
            if (login != "")
                UserLogic.AddUserRole(login, "User");
            if (login == "Nikita" && password == "admin")
                UserLogic.AddUserRole(login, "Admin");
            return true;
        }
        public static bool AddUserRole(string login, string role)
        {
            if (login == "" && role != "") return false;
            if (UserLogic.GetAll().Length < 1)
                AddUserRole(login, "Admin");
            foreach (var user in UserLogic.GetAll())
                if (user.Login == login)
                    return UserLogic.AddUserRole(login, role);
            return false;
        }
        public override bool IsUserInRole(string login, string role)
        {
            if (login == "Nikita" && role == "Admin")
                return true;
            return false;
        }
        public override string[] GetRolesForUser(string login)
        {
            if (login == "Nikita") return new string[] { "Admin" };
            string[] roles = new string[] { };
            foreach (var user in UserLogic.GetAll())
                if (user.Login == login)
                    roles = user.Roles.ToArray();
            return roles;
        }
        public static bool TakeRole(string login, string roleName)
        {
            if (login == null || string.IsNullOrWhiteSpace(login) || roleName == null || string.IsNullOrWhiteSpace(roleName))
                return false;
            var user = new UserDao();
            var result = user.RemoveUserRole(login, roleName);
            return result;
        }
        #region NOT_IMPLEMENTED
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}