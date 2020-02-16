using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task6.PL;
using Task6.Entities;

namespace Task10.Models
{
    public class AwardService
    {
        public static void AddAward(Award award) { ChoiceMode._awardLogic.Add(award); }
        public static IEnumerable<Award> GetAll() => ChoiceMode._awardLogic.GetAll();
        public static Award ShowAward(int id) => ChoiceMode._awardLogic.GetById(id);
    }
}