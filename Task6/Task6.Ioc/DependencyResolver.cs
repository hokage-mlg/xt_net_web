using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task11.DAL;
using Task6.DAL;
using Task6.DAL.Interfaces;
using Task6.BLL;
using Task6.BLL.Interfaces;

namespace Task6.Common
{
    public class DependencyResolver
    {
        private static IUserDao _userDao = new Task11.DAL.UserDao();
        private static IAwardDao _awardDao = new Task11.DAL.AwardDao();
        private static IUserWebDao _userWebDao = new Task11.DAL.UserWebDao();
        private static IUserLogic _userLogic = new UserLogic(_userDao);
        private static IAwardLogic _awardLogic = new AwardLogic(_awardDao);
        private static IUserWebLogic _userWebLogic = new UserWebLogic(_userWebDao);
        public static IUserLogic UserLogic => _userLogic;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IUserWebLogic UserWebLogic => _userWebLogic;
    }
}
