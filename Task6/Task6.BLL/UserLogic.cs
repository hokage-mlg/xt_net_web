using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.DAL.Interfaces;
using Task6.BLL.Interfaces;

namespace Task6.BLL
{
    public class UserLogic : IUserLogic
    {
        private IUserDao _userDao;
        public UserLogic(IUserDao userDao) { _userDao = userDao; }
        public User Add(User user) => _userDao.Add(user);
        public User GetById(int id) => _userDao.GetById(id);
        public bool RemoveById(int id) => _userDao.RemoveById(id);
        public IEnumerable<User> GetAll() => _userDao.GetAll();
        public bool GiveAward(int id, Award award) => _userDao.GiveAward(id, award);
        public bool TakeAwayAward(int id, int awardId) => _userDao.TakeAwayAward(id, awardId);
        public bool AddUserImage(int idUser, byte[] byteArrayImage) => _userDao.AddUserImage(idUser, byteArrayImage);
        public bool RemoveUserImage(int idUser) => _userDao.RemoveUserImage(idUser);
        public byte[] GetUserImage(int idUser) => _userDao.GetUserImage(idUser);
    }
}
