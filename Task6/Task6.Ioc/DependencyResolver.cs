using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            UserDao = new UserDao();
            AwardDao = new AwardDao();
            UserLogic = new UserLogic(UserDao);
            AwardLogic = new AwardLogic(AwardDao);
        }
    }
}
