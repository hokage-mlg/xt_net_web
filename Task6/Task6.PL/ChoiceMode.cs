using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
using Task6.BLL.Interfaces;
using Task6.Common;

namespace Task6.PL
{
    class ChoiceMode
    {
        private static IUserLogic _userLogic = DependencyResolver.UserLogic;
        private static IAwardLogic _awardLogic = DependencyResolver.AwardLogic;
        public static void UserMode()
        {
            while (true)
            {
                ConsoleDisplay.UserMenuDisplay();
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Incorrect input. Try again!");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        {
                            User user = CreateUser();
                            _userLogic.Add(user);
                            Console.WriteLine("User added with ID - {0}", user.Id);
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            int id = GetId();
                            User user = _userLogic.GetById(id);
                            ShowUser(user);
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            ShowAllUsers();
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            int id = GetId();
                            if (_userLogic.RemoveById(id))
                                Console.WriteLine("User with ID - {0} is deleted.", id);
                            else
                                Console.WriteLine("User with this ID does not exist.");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            ShowAllUsers();
                            Console.WriteLine("Select user for rewarding.");
                            User user = _userLogic.GetById(GetId());
                            if (user == null)
                            {
                                Console.WriteLine("User with this ID does not exist.");
                                break;
                            }
                            Console.WriteLine("List of awards:");
                            ShowAllAwards();
                            Console.WriteLine("Select award for rewarding.");
                            Award award = _awardLogic.GetById(GetId());
                            if (award == null)
                            {
                                Console.WriteLine("Award with this ID does not exist.");
                                break;
                            }
                            if (_userLogic.GiveAward(user.Id, award))
                                Console.WriteLine("The award was successfully presented.");
                            else
                                Console.WriteLine("An error occurred during the presentation of award.");
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                        break;
                    default:
                        break;
                }
                if (input == 0)
                    break;
                Console.Clear();
            }
        }
        private static void ShowUser(User user)
        {
            if (user == null)
                Console.WriteLine("User with this ID does not exist.");
            else
                Console.WriteLine(user);
        }
        private static void ShowAllUsers()
        {
            IEnumerable<User> users = _userLogic.GetAll();
            if (users.Count() == 0)
                Console.WriteLine("User list is empty");
            else
                foreach (var user in users)
                    ShowUser(user);
        }
        private static User CreateUser()
        {
            string name;
            DateTime dateOfBirth;
            Console.WriteLine("Enter name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter date of birth in format: DD.MM.YYYY:");
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
                Console.WriteLine("Incorrect input. Try again!");
            return new User()
            {
                Name = name,
                DateOfBirth = dateOfBirth
            };
        }
        public static void AwardMode()
        {
            while (true)
            {
                ConsoleDisplay.AwardMenuDisplay();
                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Incorrect input. Try again!");
                    continue;
                }
                switch (input)
                {
                    case 1:
                        {
                            Award award = CreateAward();
                            _awardLogic.Add(award);
                            Console.WriteLine("Award added with ID - {0}", award.Id);
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            int id = GetId();
                            Award award = _awardLogic.GetById(id);
                            ShowAward(award);
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            IEnumerable<Award> awards = _awardLogic.GetAll();
                            if (awards.Count() == 0)
                                Console.WriteLine("Award list is empty.");
                            else
                                foreach (var award in awards)
                                    ShowAward(award);
                            Console.ReadLine();
                            break;
                        }
                    case 0:
                    default:
                        break;
                }
                if (input == 0)
                    break;
                Console.Clear();
            }
        }
        private static void ShowAward(Award award)
        {
            if (award == null)
                Console.WriteLine("Award with this ID does not exist.");
            else
                Console.WriteLine(award);
        }
        private static void ShowAllAwards()
        {
            IEnumerable<Award> awards = _awardLogic.GetAll();
            if (awards.Count() == 0)
                Console.WriteLine("Award list is empty.");
            else
                foreach (var award in awards)
                    ShowAward(award);
        }
        private static Award CreateAward()
        {
            string title;
            Console.WriteLine("Enter title of award:");
            title = Console.ReadLine();
            return new Award() { Title = title };
        }
        private static int GetId()
        {
            Console.WriteLine("Enter id:");
            int id;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out id) || id < 1)
                {
                    Console.WriteLine("Incorrect input. Try again.");
                    continue;
                }
                break;
            }
            return id;
        }
    }
}
