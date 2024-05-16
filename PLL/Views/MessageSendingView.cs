using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;


namespace SocialNetwork.PLL.Views
{
    
    internal class MessageSendingView
    {
        public MessageService messageService;
        public UserService userService;

        public MessageSendingView(MessageService messageService, UserService userService)
        {
            this.messageService = messageService;
            this.userService = userService;
        }

        internal void Show(User user)
        {
            var messageSendingData = new MessageSendingData();

            Console.WriteLine("Введите e-mail получателя: ");
            messageSendingData.RecipientEmail = Console.ReadLine();

            Console.WriteLine("Введите текст сообщения, максимум 5000 символов: ");
            messageSendingData.Content = Console.ReadLine();

            messageSendingData.SenderId = user.Id;

            try
            {
                messageService.SendMessage(messageSendingData);
                SuccessMessage.Show("Сообщение отправлено успешно! ");

                user = userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с таким email не найден! ");
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("Сообщение не должно быть пустым или больше 5000 знаков! ");
            }
            catch (Exception)
            {
                AlertMessage.Show("При отправке сообщения произошла ошибка");
            }
        }
    }
}
