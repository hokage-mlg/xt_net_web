using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.DAL.Interfaces;
using Final.BLL.Interfaces;
using Final.Entities;

namespace Final.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;
        public UserLogic(IUserDao userDao) { _userDao = userDao; }
        public User AddUser(string login, string password)
        {
            User user = new User { Login = login, Password = password };
            if (_userDao.Add(user))
                return user;
            throw new ArgumentException("Error. User can't be added.");
        }
        public bool AddUserRole(string login, string role) => _userDao.AddUserRole(login, role);
        public bool RemoveUserRole(string login, string role) => _userDao.RemoveUserRole(login, role);
        public bool CancelPurchase(int id, int purchaseId) => _userDao.CancelPurchase(id, purchaseId);
        public User[] GetAll() => _userDao.GetAll().ToArray();
        public User GetById(int id) => _userDao.GetById(id);
        public bool MakePurchase(int id, int purchaseId) => _userDao.MakePurchase(id, purchaseId);
        public bool RemoveById(int id) => _userDao.RemoveById(id);
        public bool Update(User user) => _userDao.Update(user);
    }
}
