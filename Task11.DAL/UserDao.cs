using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.DAL.Interfaces;
using Task6.Entities;
using System.Configuration;
using System.Data.SqlClient;
namespace Task11.DAL
{
    public class UserDao : IUserDao
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public event Action<int, int> RemoveAward;
        public User Add(User user)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertUser", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var namePar = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };
                cmd.Parameters.Add(namePar);
                var datePar = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth
                };
                cmd.Parameters.Add(datePar);
                var imagePar = new SqlParameter
                {
                    ParameterName = "@UserImage",
                    Value = Convert.ToBase64String(user.UserImage)
                };
                cmd.Parameters.Add(imagePar);
                int mod = (int)cmd.ExecuteScalar();
                user.Id = mod;
            }
            return user;
        }
        public IEnumerable<User> GetAll()
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                List<User> users = new List<User>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAllUsers", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    users.Add(new User
                    {
                        Id = (int)res["Id"],
                        Name = (string)res["Name"],
                        DateOfBirth = (DateTime)res["DateOfBirth"],
                        UserImage = Convert.FromBase64String((string)res["UserImage"])
                    });
                }
                return users;
            }
        }
        public User GetById(int id)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetUserById", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
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
                        Name = (string)res["Name"],
                        DateOfBirth = (DateTime)res["DateOfBirth"],
                        UserImage = Convert.FromBase64String((string)res["UserImage"])
                    };
                }
                return null;
            }
        }
        public bool GiveAward(int userId, Award award)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GiveAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("AwardId", award.Id);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool RemoveById(int id)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveUserById", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "Id",
                    Value = id
                };
                cmd.Parameters.Add(idPar);
                var res = cmd.ExecuteNonQuery();
                if (res != 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool TakeAwayAward(int userId, int awardId)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_TakeAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("AwardId", awardId);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool Update(User user)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_UpdateUser", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var idPar = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = user.Id
                };
                cmd.Parameters.Add(idPar);
                var namePar = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };
                cmd.Parameters.Add(namePar);
                var datePar = new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth
                };
                cmd.Parameters.Add(datePar);
                var imagePar = new SqlParameter
                {
                    ParameterName = "@UserImage",
                    Value = Convert.ToBase64String(user.UserImage)
                };
                cmd.Parameters.Add(imagePar);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool AddUserImage(int idUser, byte[] byteArrayImage)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_AddUserImage", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var idPar = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = idUser,
                };
                var imagePar = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserImage",
                    Value = Convert.ToBase64String(byteArrayImage),
                };
                cmd.Parameters.Add(idPar);
                cmd.Parameters.Add(imagePar);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        public byte[] GetUserImage(int idUser)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetUserImage", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var idPar = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = idUser,
                };
                cmd.Parameters.Add(idPar);
                SqlDataReader sqlDR = cmd.ExecuteReader();
                byte[] imageUser = new byte[] { };
                while (sqlDR.Read())
                    if (!DBNull.Value.Equals(sqlDR["UserImage"]))
                        imageUser = Convert.FromBase64String((string)sqlDR["UserImage"]);
                return imageUser;
            }
        }
        public bool RemoveUserImage(int idUser)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_AddUserImage", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var idPar = new SqlParameter()
                {
                    DbType = System.Data.DbType.Int32,
                    ParameterName = "@Id",
                    Value = idUser,
                };
                var imagePar = new SqlParameter()
                {
                    DbType = System.Data.DbType.String,
                    ParameterName = "@UserImage",
                    Value = DBNull.Value,
                };
                cmd.Parameters.Add(idPar);
                cmd.Parameters.Add(imagePar);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        #region Not Implemented
        public void OnDeleteAwardHandler(int awardId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
