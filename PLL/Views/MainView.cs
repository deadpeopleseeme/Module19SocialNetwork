using System;

namespace SocialNetwork.PLL.Views
{
    internal class MainView
    {
        internal void Show()
        {
            Console.WriteLine("Введите 1, чтоб войти в профиль ");
            Console.WriteLine("Введите 2, чтоб зарегистрироваться ");

            switch(Console.ReadLine())
            {
                case "1":
                    Program.authenticationView.Show();
                    break;
                case "2":
                    Program.registrationView.Show();
                    break;
                default:
                    Console.WriteLine("некорректный ввод! ");
                    break;
            }
        }
    }
}
