using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task6.BLL.Interfaces;
using Task6.Common;
using Task6.Entities;
using Task6.BLL;

namespace Task10.Models
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
    }
}