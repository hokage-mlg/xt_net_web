using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.BLL.Interfaces;
using Task6.DAL.Interfaces;
using Task6.Entities;

namespace Task6.BLL
{
    public class UserWebLogic:IUserWebLogic
    {
        private readonly IUserWebDao _userWebDao;
        public UserWebLogic(IUserWebDao userWebDao) { _userWebDao = userWebDao; }    
        public UserWeb AddUser(string login,string password)
        {
            UserWeb user = new UserWeb { Login = login, Password = password };
            if (_userWebDao.Add(user))          
                return user;
            throw new ArgumentException("Error. User can't be added.");
        }
        public bool AddUserRole(string login, string role) => _userWebDao.AddUserRole(login, role);
        public UserWeb[] GetAll() => _userWebDao.GetAll().ToArray();
    }
}
