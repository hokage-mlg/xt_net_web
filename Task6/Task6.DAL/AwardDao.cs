using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.DAL.Interfaces;
using System.IO;

namespace Task6.DAL
{
    public class AwardDao : IAwardDao
    {
        private readonly Dictionary<int, Award> _awards;
        private static readonly string _fPath = @"D:\Studying\EpamXT\TasksVasin\Task6\Task6.PL\bin\Debug\.awards.json";

        public event Action<int> DeleteAward = delegate { };

        public AwardDao()
        {
            if (File.Exists(_fPath))
            {
                using (StreamReader streamR = new StreamReader(File.Open(_fPath, FileMode.Open)))
                {
                    string fileInside = streamR.ReadLine();
                    _awards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(fileInside);
                }
            }
            else
                _awards = new Dictionary<int, Award>();
        }
        public Award Add(Award award)
        {
            int lastId;
            if (_awards.Keys.Count > 0)
                lastId = _awards.Keys.Max();
            else
                lastId = 0;
            award.Id = lastId + 1;
            _awards.Add(award.Id, award);
            WriteAwards();
            return award;
        }
        public Award GetById(int id)
        {
            _awards.TryGetValue(id, out var award);
            return award;
        }
        public IEnumerable<Award> GetAll() => _awards.Values;
        private void WriteAwards()
        {
            if (File.Exists(_fPath))
                File.Delete(_fPath);
            using (StreamWriter streamW = new StreamWriter(File.Open(_fPath, FileMode.Create)))
                streamW.Write(JsonConvert.SerializeObject(_awards));
            File.SetAttributes(_fPath, FileAttributes.Hidden);
        }
        public bool RemoveById(int id)
        {
            bool removeResult = _awards.Remove(id);
            if (removeResult)
                DeleteAward?.Invoke(id);
            return removeResult;
        }
        public void AddUserToAward(int awardId, int userId)
        {
            _awards[awardId].Users.Add(userId);
        }
        public void RemoveUserFromAward(int awardId, int userId)
        {
            _awards[awardId].Users.Remove(userId);
        }
        public void OnDeleteUserHandler(int userId)
        {
            foreach (var award in _awards)
                award.Value.Users.Remove(userId);
            WriteAwards();
        }
        public IEnumerable<Award> GetAwardsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
        ~AwardDao()
        {
            WriteAwards();
        }
    }
}
