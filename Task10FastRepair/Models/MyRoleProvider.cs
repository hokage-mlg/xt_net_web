﻿using System;
using System.Linq;
using System.Web.Security;
using Task6.BLL.Interfaces;
using Task6.Common;
using Task11.DAL;
namespace Task10FastRepair.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private static IUserWebLogic UserWebLogic;
        static MyRoleProvider() { UserWebLogic = DependencyResolver.UserWebLogic; }
        public static bool VerifyUser(string login, string password)
        {
            foreach (var webUser in UserWebLogic.GetAll())
                if (webUser.Login == login)
                    return webUser.Password == password;
            UserWebLogic.AddUser(login, password);
            if (login != "")
                UserWebLogic.AddUserRole(login, "User");
            if (login == "Nikita" && password == "admin")
                UserWebLogic.AddUserRole(login, "Admin");
            return true;
        }
        public static bool AddUserRole(string login, string role)
        {
            if (login == "" && role != "") return false;
            if (UserWebLogic.GetAll().Length < 1)
                AddUserRole(login, "Admin");
            foreach (var webUser in UserWebLogic.GetAll())
                if (webUser.Login == login)
                    return UserWebLogic.AddUserRole(login, role);
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
            foreach (var webUser in UserWebLogic.GetAll())
                if (webUser.Login == login)
                    roles = webUser.Roles.ToArray();
            return roles;
        }
        public static bool TakeRole(string login, string roleName)
        {
            if (login == null || string.IsNullOrWhiteSpace(login) || roleName == null || string.IsNullOrWhiteSpace(roleName))
                return false;
            var userWeb = new UserWebDao();
            var result = userWeb.RemoveRole(login, roleName);
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