using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Views;
using System;

namespace SocialNetwork
{
    class Program
    {   
        public static MessageService messageService;
        public static UserService userService;
        public static AuthenticationView authenticationView;
        public static MainView mainView;
        public static MessageSendingView messageSendingView;
        public static RegistrationView registrationView;
        public static UserDataUpdateView userDataUpdateView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserInfoView userInfoView;
        public static UserMenuView userMenuView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        static void Main(string[] args)
        {
            messageService = new MessageService();
            userService = new UserService();
            authenticationView = new AuthenticationView(userService);
            mainView = new MainView();
            messageSendingView = new MessageSendingView(messageService, userService);
            registrationView = new RegistrationView(userService);
            userDataUpdateView = new UserDataUpdateView();
            userIncomingMessageView = new UserIncomingMessageView();
            userInfoView = new UserInfoView();
            userMenuView = new UserMenuView(userService);
            userOutcomingMessageView = new UserOutcomingMessageView();

            while (true)
            {
                mainView.Show();
            }
        }
    }
}