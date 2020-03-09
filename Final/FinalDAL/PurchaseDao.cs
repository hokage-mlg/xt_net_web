using System;
using System.Collections.Generic;
using Final.Entities;
using Final.DAL.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FinalDAL
{
    public class PurchaseDao : IPurchaseDao
    {
        private static string _con_str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
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
        public IEnumerable<Purchase> GetPurchasesByUserId(int userId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Purchase> purchases = new List<Purchase>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetPurchasesByUserId", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", userId);
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
        public bool ChangeFullname(int purchaseId, string fullname)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangeFullname", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", purchaseId);
                cmd.Parameters.AddWithValue("FullName", fullname);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool ChangePhoneNumber(int purchaseId, string phoneNumber)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangePhoneNumber", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", purchaseId);
                cmd.Parameters.AddWithValue("PhoneNumber", phoneNumber);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool ChangeAddress(int purchaseId, string address)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangeAddress", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", purchaseId);
                cmd.Parameters.AddWithValue("Address", address);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool RemoveById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemovePurchaseById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool RemoveAll()
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveAllPurchases", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var res = cmd.ExecuteNonQuery();
                return res != 0;
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
    }
}