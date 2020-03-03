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
    public class PurchaseLogic : IPurchaseLogic
    {
        private IPurchaseDao _purchaseDao;
        public PurchaseLogic(IPurchaseDao purchaseDao) { _purchaseDao = purchaseDao; }
        public Purchase Add(Purchase purchase) => _purchaseDao.Add(purchase);
        public void AddPurchaseToUser(int purchaseId, int userId)
        {
            _purchaseDao.AddPurchaseToUser(purchaseId, userId);
        }
        public IEnumerable<Purchase> GetAll() => _purchaseDao.GetAll();
        public Purchase GetById(int id) => _purchaseDao.GetById(id);
        public void RemovePurchaseFromUser(int purchaseId, int userId)
        {
            _purchaseDao.RemovePurchaseFromUser(purchaseId, userId);
        }
        public bool Update(Purchase purchase) => _purchaseDao.Update(purchase);
    }
}
