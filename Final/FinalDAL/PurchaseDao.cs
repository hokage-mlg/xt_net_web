using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Entities;
using Final.DAL.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalDAL
{
    public class PurchaseDao : IPurchaseDao
    {
        public event Action<int> DeletePurchase;
        private static string _con_str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public Purchase Add(Purchase purchase)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertPurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("FullName", purchase.FullName);
                cmd.Parameters.AddWithValue("PhoneNumber", purchase.PhoneNumber);
                cmd.Parameters.AddWithValue("Address", purchase.Address);
                int mod = (int)cmd.ExecuteScalar();
                purchase.Id = mod;
            }
            return purchase;
        }
        public void AddPurchaseToUser(int purchaseId, int userId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_MakePurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                cmd.Parameters.AddWithValue("IdUser", userId);
                var res = cmd.ExecuteNonQuery();
            }
        }
        public IEnumerable<Purchase> GetAll()
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Purchase> purchases = new List<Purchase>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAllPurchases", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    purchases.Add(new Purchase
                    {
                        Id = (int)res["Id"],
                        FullName = (string)res["FullName"],
                        PhoneNumber = (string)res["PhoneNumber"],
                        Address = (string)res["Address"]
                    });
                }
                return purchases;
            }
        }
        public Purchase GetById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetPurchaseById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new Purchase
                    {
                        Id = (int)res["Id"],
                        FullName = (string)res["FullName"],
                        PhoneNumber = (string)res["PhoneNumber"],
                        Address = (string)res["Address"]
                    };
                }
                return null;
            }
        }
        public void RemovePurchaseFromUser(int purchaseId, int userId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_CancelPurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                cmd.Parameters.AddWithValue("IdUser", userId);
                var res = cmd.ExecuteNonQuery();
            }
        }
        public bool Update(Purchase purchase)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_UpdatePurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", purchase.Id);
                cmd.Parameters.AddWithValue("@FullName", purchase.FullName);
                cmd.Parameters.AddWithValue("@PhoneNumber", purchase.PhoneNumber);
                cmd.Parameters.AddWithValue("@Address", purchase.Address);
                var res = cmd.ExecuteNonQuery();
                return res != 0 ? true : false;
            }
        }
        #region Not Implemented
        public void OnDeleteUserHandler(int userId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
