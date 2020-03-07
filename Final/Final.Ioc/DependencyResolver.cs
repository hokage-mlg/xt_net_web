using Final.BLL;
using Final.BLL.Interfaces;
using Final.DAL.Interfaces;

namespace Final.Ioc
{
    public class DependencyResolver
    {
        private static IUserDao _userDao = new FinalDAL.UserDao();
        private static IPurchaseDao _purchaseDao = new FinalDAL.PurchaseDao();
        private static IBookDao _bookDao = new FinalDAL.BookDao();
        private static IUserLogic _userLogic = new UserLogic(_userDao);
        private static IPurchaseLogic _purchaseLogic = new PurchaseLogic(_purchaseDao);
        private static IBookLogic _bookLogic = new BookLogic(_bookDao);
        public static IUserLogic UserLogic => _userLogic;
        public static IPurchaseLogic PurchaseLogic => _purchaseLogic;
        public static IBookLogic BookLogic => _bookLogic;
    }
}
