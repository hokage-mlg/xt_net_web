using System;
using System.Collections.Generic;
using Task6.BLL.Interfaces;
using Task6.Common;
using Task6.Entities;
using Task6.BLL;

namespace Task10FastRepair.Models
{
    public static class WebUI
    {
        private static IUserLogic UserLogic;
        private static IAwardLogic AwardLogic;
        public static UserWebLogic webLogic;
        static WebUI()
        {
            UserLogic = DependencyResolver.UserLogic;
            AwardLogic = DependencyResolver.AwardLogic;
        }
        public static IEnumerable<UserWeb> GetListUsers()
        {
            var users = new Task6.DAL.UserWebDao();
            return users.GetAll();
        }
        public static string PrintWebUsers(UserWeb user) => $"Login:{user.Login}; Role:{user.Roles[0]}";
        public static bool AddUserImage(string id, byte[] byteArrayImage)
        {
            try
            {
                return UserLogic.AddUserImage(Convert.ToInt32(id), byteArrayImage);
            }
            catch
            {
                return false;
            }
        }
        public static bool RemoveUserImage(string id)
        {
            try
            {
                return UserLogic.RemoveUserImage(Convert.ToInt32(id));
            }
            catch
            {
                return false;
            }
        }
        public static byte[] GetUserImage(string id)
        {
            try
            {
                return UserLogic.GetUserImage(Convert.ToInt32(id));
            }
            catch
            {
                return new byte[] { };
            }
        }
    }
}