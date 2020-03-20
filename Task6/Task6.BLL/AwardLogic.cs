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
    public class AwardLogic : IAwardLogic
    {
        private IAwardDao _awardDao;
        public AwardLogic(IAwardDao awardDao) { _awardDao = awardDao; }
        public Award Add(Award award) => _awardDao.Add(award);
        public Award GetById(int id) => _awardDao.GetById(id);
        public IEnumerable<Award> GetAll() => _awardDao.GetAll();
        public bool RemoveById(int id) => _awardDao.RemoveById(id);
        public IEnumerable<Award> GetAwardsByUserId(int userId) => _awardDao.GetAwardsByUserId(userId);
        public void AddUserToAward(int awardId, int userId)
        {
            _awardDao.AddUserToAward(awardId, userId);
        }
        public void RemoveUserFromAward(int awardId, int userId)
        {
            _awardDao.RemoveUserFromAward(awardId, userId);
        }
    }
}
