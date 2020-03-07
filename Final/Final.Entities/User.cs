using System.Collections.Generic;
using System.Text;

namespace Final.Entities
{
    public class User
    {
        public User() { _purchases = new Dictionary<int, Purchase>(); }
        public int Id { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public string[] Roles { get; set; }
        private Dictionary<int, Purchase> _purchases;
        public Dictionary<int, Purchase> Purchases
        {
            get { return _purchases; }
            set { _purchases = value; }
        }
        public bool AddPurchase(Purchase purchase)
        {
            try
            {
                Purchases.Add(purchase.Id, purchase);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            var userSB = new StringBuilder();
            userSB.Append($"Id:{Id}. Login: {Login}.");
            if (Purchases.Count != 0)
            {
                userSB.Append("Purchases:\n");
                foreach (var i in Purchases)
                    userSB.Append($" {i.Value}\n");
            }
            return userSB.ToString();
        }
    }
}
