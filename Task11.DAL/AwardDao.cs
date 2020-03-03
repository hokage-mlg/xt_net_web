using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.DAL.Interfaces;
using Task6.Entities;
using System.Data.SqlClient;
using System.Configuration;

namespace Task11.DAL
{
    public class AwardDao : IAwardDao
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public event Action<int> DeleteAward;
        public Award Add(Award award)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Title", award.Title);
                cmd.Parameters.AddWithValue("AwardImage", Convert.ToBase64String(award.AwardImage));
                int mod = (int)cmd.ExecuteScalar();
                award.Id = mod;
            }
            return award;
        }
        public IEnumerable<Award> GetAll()
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                List<Award> awards = new List<Award>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAllAwards", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    });
                }
                return awards;
            }
        }
        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                List<Award> awards = new List<Award>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAwardsByUserId", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", userId);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    awards.Add(new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    });
                }
                return awards;
            }
        }
        public Award GetById(int id)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAwardById", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new Award
                    {
                        Id = (int)res["Id"],
                        Title = (string)res["Title"],
                        AwardImage = Convert.FromBase64String((string)res["AwardImage"])
                    };
                }
                return null;
            }
        }
        public void RemoveAll()
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var res = cmd.ExecuteNonQuery();
            }
        }
        public bool RemoveById(int id)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveAwardById", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool Update(Award award)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_UpdateAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", award.Id);
                cmd.Parameters.AddWithValue("@Title", award.Title);
                cmd.Parameters.AddWithValue("@AwardImage", Convert.ToBase64String(award.AwardImage));
                var res = cmd.ExecuteNonQuery();
                return res != 0 ? true : false;
            }
        }
        public void AddUserToAward(int awardId, int userId)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GiveAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("AwardId", awardId);
                var res = cmd.ExecuteNonQuery();
            }
        }
        public void RemoveUserFromAward(int awardId, int userId)
        {
            using (var connect = new SqlConnection(CONNECTION_STRING))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_TakeAward", connect);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("UserId", userId);
                cmd.Parameters.AddWithValue("AwardId", awardId);
                var res = cmd.ExecuteNonQuery();
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
