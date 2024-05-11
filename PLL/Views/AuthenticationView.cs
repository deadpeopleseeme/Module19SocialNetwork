using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;


namespace SocialNetwork.PLL.Views
{
    internal class AuthenticationView
    {
        UserService userService;
        public AuthenticationView(UserService userService)
        {
            this.userService = userService;
        }
        internal void Show()
        {
            var authenticationData = new UserAuthenticationData();

            Console.WriteLine("Введите e-mail: ");
            authenticationData.Email = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            authenticationData.Password = Console.ReadLine();

            try
            {
                var user = userService.Authenticate(authenticationData);
                SuccessMessage.Show($"Успешный вход! Добро пожаловать в суперсоцсеть, {user.FirstName}");
                Program.userMenuView.Show(user);
            }
            catch (WrongPasswordException) 
            {
                AlertMessage.Show("Неверный пароль! ");
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден! ");
            }
        }
    }
}
