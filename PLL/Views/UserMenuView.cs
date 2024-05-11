using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.PLL.Views
{
    internal class UserMenuView
    {
        UserService userService;
        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }
        internal void Show(User user)
        {
            while(true)
            {
                Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count}");
                Console.WriteLine($"Исходящие сообщения: {user.OutgoingMessages.Count}");

                Console.WriteLine("Посмотреть информацию о профиле: введите 1");
                Console.WriteLine("Редактировать профиль: введите 2");
                Console.WriteLine("Добавить друзей: введите 3");
                Console.WriteLine("Написать сообщение: введите 4");
                Console.WriteLine("Посмотреть входящие сообщения: введите 5");
                Console.WriteLine("Посмотреть исходящие сообщения: введите 6");
                Console.WriteLine("Выйти из профиля: введите 7");

                string input = Console.ReadLine();
                if (input == "7") break;
                switch(input)
                {
                    case "1":
                        Program.userInfoView.Show(user);
                        break;
                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;
                    case "3":
                        throw new NotImplementedException();
                        break;
                    case "4":
                        Program.messageSendingView.Show(user);
                        break;
                    case "5":
                        Program.userIncomingMessageView.Show(user);
                        break;
                    case "6":
                        Program.userOutcomingMessageView.Show(user);
                        break;

                }

            }
        }
    }
}
