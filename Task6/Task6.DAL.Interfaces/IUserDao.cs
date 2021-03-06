﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool RemoveById(int id);
        bool GiveAward(int id, Award award);
        bool TakeAwayAward(int id, int awardId);
        event Action<int, int> RemoveAward;
        void OnDeleteAwardHandler(int awardId);
        bool AddUserImage(int idUser, byte[] byteArrayImage);
        bool RemoveUserImage(int idUser);
        byte[] GetUserImage(int idUser);
    }
}
