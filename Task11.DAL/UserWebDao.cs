using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.DAL.Interfaces;
using Task6.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Task11.DAL
{
    public class UserWebDao : IUserWebDao
    {
        private static string _con_str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public bool Add(UserWeb user)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertWebUser", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var LoginParam = new SqlParameter()
                {
                    DbType = DbType.String,
                    ParameterName = "@Login",
                    Value = user.Login,
                };
                var PasswordParam = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
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
        public IEnumerable<UserWeb> GetAll()
        {
            using (var con = new SqlConnection(_con_str))
            {
                con.Open();
                var cmd = new SqlCommand("procedure_GetAllWebUsers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                List<UserWeb> usersWeb = new List<UserWeb>();
                bool next = res.Read();
                while (next)
                {
                    var webUser = new UserWeb
                    {
                        Login = (string)res["Login"],
                        Password = (string)res["Password"],
                        Roles = new string[] { }
                    };
                    while ((string)res["Login"] == webUser.Login)
                    {
                        webUser.Roles = new string[] { (string)res["Name"] };
                        if (!res.Read())
                        {
                            next = false;
                            break;
                        }
                    }
                    usersWeb.Add(webUser);
                }
                return usersWeb;
            }
        }
        public bool RemoveRole(string login, string role)
        {
            using (var connection = new SqlConnection(_con_str))
            {
                connection.Open();
                var cmd = new SqlCommand("procedure_RemoveRole", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Login", login);
                cmd.Parameters.AddWithValue("RoleName", role);
                int res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
    }
}
