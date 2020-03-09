using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Final.DAL.Interfaces;
using Final.Entities;

namespace FinalDAL
{
    public class UserDao : IUserDao
    {
        private static string _con_str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public User GetById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetUserById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                };
                cmd.Parameters.Add(idPar);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new User
                    {
                        Id = (int)res["Id"],
                        Login = (string)res["Login"],
                    };
                }
                return null;
            }
        }
        public User GetByLogin(string login)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetUserByLogin", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "Login",
                    Value = login
                };
                cmd.Parameters.Add(idPar);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new User
                    {
                        Id = (int)res["Id"],
                        Login = (string)res["Login"],
                    };
                }
                return null;
            }
        }
        public IEnumerable<User> GetAll()
        {
            using (var con = new SqlConnection(_con_str))
            {
                con.Open();
                var cmd = new SqlCommand("procedure_GetAllUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                List<User> usersWeb = new List<User>();
                bool next = res.Read();
                while (next)
                {
                    var user = new User
                    {
                        Login = (string)res["Login"],
                        Password = (string)res["Password"],
                        Roles = new string[] { }
                    };
                    while ((string)res["Login"] == user.Login)
                    {
                        user.Roles = new string[] { (string)res["Name"] };
                        if (!res.Read())
                        {
                            next = false;
                            break;
                        }
                    }
                    usersWeb.Add(user);
                }
                return usersWeb;
            }
        }
        public IEnumerable<User> GetUsersByPurchaseId(int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<User> users = new List<User>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetUsersByPurchaseId", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", purchaseId);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)res["Id"],
                        Login = (string)res["Login"]
                    });
                }
                return users;
            }
        }
        public bool Add(User user)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertUser", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var LoginParam = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                };
                var PasswordParam = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Password",
                    Value = user.Password,
                };
                cmd.Parameters.Add(LoginParam);
                cmd.Parameters.Add(PasswordParam);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public bool AddUserRole(string login, string role)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GiveRole", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var loginPar = new SqlParameter
                {
                    ParameterName = "Login",
                    Value = login,
                    SqlDbType = SqlDbType.NVarChar
                };
                var rolePar = new SqlParameter
                {
                    ParameterName = "RoleName",
                    Value = role,
                    SqlDbType = SqlDbType.NVarChar
                };
                cmd.Parameters.Add(loginPar);
                cmd.Parameters.Add(rolePar);
                int res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool RemoveUserRole(string login, string role)
        {
            using (var connection = new SqlConnection(_con_str))
            {
                connection.Open();
                var cmd = new SqlCommand("procedure_RemoveRole", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Login", login);
                cmd.Parameters.AddWithValue("RoleName", role);
                int res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool RemoveById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveUserById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                };
                cmd.Parameters.Add(idPar);
                var res = cmd.ExecuteNonQuery();
                if (res != 0)
                    return true;
                return false;
            }
        }
        public bool CancelPurchase(int id, int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_CancelPurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdUser", id);
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool MakePurchase(int id, int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_MakePurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdUser", id);
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool ChangePassword(int userId, string password)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangePassword", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", userId);
                cmd.Parameters.AddWithValue("Password", password);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool Update(User user)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_UpdateUser", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = user.Id
                };
                cmd.Parameters.Add(idPar);
                var loginPar = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = user.Login
                };
                cmd.Parameters.Add(loginPar);
                var passPar = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                cmd.Parameters.Add(passPar);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
    }
}