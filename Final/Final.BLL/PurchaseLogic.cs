using System.Collections.Generic;
using Final.DAL.Interfaces;
using Final.BLL.Interfaces;
using Final.Entities;

namespace Final.BLL
{
    public class PurchaseLogic : IPurchaseLogic
    {
        private IPurchaseDao _purchaseDao;
        public PurchaseLogic(IPurchaseDao purchaseDao) { _purchaseDao = purchaseDao; }
        public void AddPurchaseToUser(int purchaseId, int userId)
        {
            _purchaseDao.AddPurchaseToUser(purchaseId, userId);
        }
        public void RemovePurchaseFromUser(int purchaseId, int userId)
        {
            _purchaseDao.RemovePurchaseFromUser(purchaseId, userId);
        }
        public Purchase Add(Purchase purchase) => _purchaseDao.Add(purchase);
        public Purchase GetById(int id) => _purchaseDao.GetById(id);
        public IEnumerable<Purchase> GetAll() => _purchaseDao.GetAll();
        public IEnumerable<Purchase> GetPurchasesByUserId(int userId) => _purchaseDao.GetPurchasesByUserId(userId);
        public bool ChangeFullname(int purchaseId, string fullname) => _purchaseDao.ChangeFullname(purchaseId, fullname);
        public bool ChangePhoneNumber(int purchaseId, string phoneNumber) => _purchaseDao.ChangePhoneNumber(purchaseId, phoneNumber);
        public bool ChangeAddress(int purchaseId, string address) => _purchaseDao.ChangeAddress(purchaseId, address);
        public bool RemoveById(int id) => _purchaseDao.RemoveById(id);
        public bool Update(Purchase purchase) => _purchaseDao.Update(purchase);
    }
}
