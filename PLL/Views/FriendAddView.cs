using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;

namespace SocialNetwork.PLL.Views
{
    internal class FriendAddView
    {
        FriendService friendService;
        public UserService userService;
        public FriendAddView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }
        internal void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("введите 1, чтоб добавить друга. ");
                Console.WriteLine("введите 2, чтоб посмотреть список друзей. ");
                Console.WriteLine("введите 3, чтоб выйти из меню. ");

                string input = Console.ReadLine();
                if (input == "3") break;
                switch (input)
                {
                    case "1":
                        var friendAddingData = new FriendAddingData();

                        Console.WriteLine("Введите email друга: ");
                        friendAddingData.RecipientEmail = Console.ReadLine().Trim();

                        friendAddingData.SenderId = user.Id;
                        try
                        {
                            friendService.AddFriend(friendAddingData);
                            user = userService.FindById(user.Id);
                            SuccessMessage.Show($"друг {friendAddingData.RecipientEmail} успешно добавлен!");
                        }
                        catch (ArgumentNullException)
                        {
                            AlertMessage.Show("Нужно ввести email! ");
                        }
                        catch (UserNotFoundException)
                        {
                            AlertMessage.Show("Нет пользователя с таким email! ");
                        }
                        catch (UserIsAlreadyFriendlistedException)
                        {
                            AlertMessage.Show("Этот пользователь уже ваш друг! ");
                        }
                        catch (CantBefriendYourselfException)
                        {
                            AlertMessage.Show("Невозможно добавить в друзья самого себя! ");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Список ваших друзей: ");
                        var friends = friendService.GetFriendsByUserId(user.Id);
                        foreach(var fr in friends)
                        { var f = userService.FindById(fr.FriendId);
                            Console.WriteLine($"{f.FirstName} {f.LastName} ");
                        }
                        break;
                    default:
                        AlertMessage.Show("неверный ввод, только 1, 2 или 3!");
                        break;
                }
            }
        }
    }
}
