using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task6.PL;
using Task6.Entities;
using System.Text;
using Newtonsoft.Json;

namespace Task10.Models
{
    public static class UserService
    {
        public static void AddUser(Task6.Entities.User user) { ChoiceMode._userLogic.Add(user); }
        public static User ShowUser(int id) => ChoiceMode._userLogic.GetById(id);
        public static Award ShowAward(int id) => ChoiceMode._awardLogic.GetById(id);
        public static IEnumerable<User> GetAll() => ChoiceMode._userLogic.GetAll();
        public static bool GiveAward(int UserId, Award award) => ChoiceMode._userLogic.GiveAward(UserId, award);
        public static void RemoveFromAll(int awardId)
        {
            var users = ChoiceMode._userLogic.GetAll();
            foreach (var user in users)
                if (ChoiceMode._userLogic.TakeAwayAward(user.Id, awardId))
                    ChoiceMode._awardLogic.RemoveUserFromAward(awardId, user.Id);
        }
        public static void DeleteUser(int id) { ChoiceMode._userLogic.RemoveById(id); }
        public static string TakeAwayAward(int userId, int awardId)
        {
            bool status = ChoiceMode._userLogic.TakeAwayAward(userId, awardId);
            string msg;
            if (status)
            {
                ChoiceMode._awardLogic.RemoveUserFromAward(awardId, userId);
                msg = $"The award with ID - {awardId} has been taken from user with ID - {userId}.";
            }
            else
                msg = "Can't take award.";
            return msg;
        }
    }
}