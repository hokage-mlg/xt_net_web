using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.DAL.Interfaces;
using Task6.Entities;
using Newtonsoft.Json;
using System.IO;

namespace Task6.DAL
{
    public class UserWebDao:IUserWebDao
    {
        private static DirectoryInfo AllWebUsersFolder = new DirectoryInfo(@"D:\task10asp");
        private static string FileName = AllWebUsersFolder.FullName + @"\" + "JsonAllWebUsers.txt";
        private static Dictionary<string, UserWeb> _userWeb;
        public UserWebDao()
        {
            if (!AllWebUsersFolder.Exists) AllWebUsersFolder.Create();
            using (FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate))
            {
                var reader = new StreamReader(fileStream);
                string value = reader.ReadToEnd();
                if (value == "")
                    _userWeb = new Dictionary<string, UserWeb>();
                else
                    _userWeb = JsonConvert.DeserializeObject<Dictionary<string, UserWeb>>(value);
                reader.Close();
            }
        }
        public bool Add(UserWeb user)
        {
            _userWeb.Add(user.Login, user);
            Save();
            return true;
        }
        public bool AddUserRole(string login, string role)
        {
            _userWeb.TryGetValue(login, out UserWeb user);
            user.Roles = new string[] { role };
            Save();
            return true;
        }
        public IEnumerable<UserWeb> GetAll()
        {
            foreach (var user in _userWeb.Values)
                yield return user;
        }
        private void Save()
        {
            string strJson = JsonConvert.SerializeObject(_userWeb);
            using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
            {
                var strWriter = new StreamWriter(fileStream);
                strWriter.Write(strJson);
                strWriter.Close();
            }
        }
    }
}
