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
        public static IUserDao UserDao { get; private set; }
        public static IUserLogic UserLogic { get; private set; }
        public static IAwardDao AwardDao { get; set; }
        public static IAwardLogic AwardLogic { get; set; }
        static DependencyResolver()
        {
            UserDao = new Task11.DAL.UserDao();
            AwardDao = new Task11.DAL.AwardDao();
            UserLogic = new UserLogic(UserDao);
            AwardLogic = new AwardLogic(AwardDao);
        }
        private static IUserWebDao _userWebDao;
        public static IUserWebDao UserWebDao => _userWebDao ?? (_userWebDao = new Task11.DAL.UserWebDao());
        private static IUserWebLogic _userWebLogic;
        public static IUserWebLogic UserWebLogic => _userWebLogic ?? (_userWebLogic = new UserWebLogic(UserWebDao));
    }
}
