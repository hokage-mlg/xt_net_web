﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Task6.Entities;
using Task6.DAL.Interfaces;
using Newtonsoft.Json;

namespace Task6.DAL
{
    public class UserDao : IUserDao
    {
        private readonly Dictionary<int, User> _users;
        private static readonly string _fPath = @".users.json";
        public UserDao()
        {
            if (File.Exists(_fPath))
            {
                using (var streamR = new StreamReader(File.Open(_fPath, FileMode.Open)))
                {
                    string fileInside = streamR.ReadLine();
                    _users = JsonConvert.DeserializeObject<Dictionary<int, User>>(fileInside);
                }
            }
            else
                _users = new Dictionary<int, User>();
        }
        public User Add(User user)
        {
            int lastId;
            if (_users.Keys.Count > 0)
                lastId = _users.Keys.Max();
            else
                lastId = 0;
            user.Id = lastId + 1;
            _users.Add(user.Id, user);
            WriteUsers();
            return user;
        }
        public User GetById(int id)
        {
            _users.TryGetValue(id, out var user);
            return user;
        }
        public IEnumerable<User> GetAll() => _users.Values;
        public bool RemoveById(int id)
        {
            bool removed = _users.Remove(id);
            if (removed)
                WriteUsers();
            return removed;
        }
        public bool GiveAward(int id, Award award)
        {
            bool given = _users[id].AddAward(award);
            if (given)
                WriteUsers();
            return given;
        }
        private void WriteUsers()
        {
            if (File.Exists(_fPath))
                File.Delete(_fPath);
            using (StreamWriter streamW = new StreamWriter(File.Open(_fPath, FileMode.Create)))
                streamW.Write(JsonConvert.SerializeObject(_users));
            File.SetAttributes(_fPath, FileAttributes.Hidden);
        }
        ~UserDao()
        {
            WriteUsers();
        }
    }
}
