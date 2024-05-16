﻿using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.BLL.Services
{
    internal class MessageService
    {
        IMessageRepository messageRepository;
        IUserRepository userRepository;

        public MessageService()
        {
            messageRepository = new MessageRepository();
            userRepository = new UserRepository();
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int recipentId)
        {
            var messages = new List<Message>();
            messageRepository.FindByRecipientId(recipentId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipentUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipentUserEntity.email));
            });
            return messages;
        }

        public IEnumerable<Message> GetOutcomingMessagesByUserId(int sendertId)
        {
            var messages = new List<Message>();
            messageRepository.FindByRecipientId(sendertId).ToList().ForEach(m =>
            {
                var senderUserEntity = userRepository.FindById(m.sender_id);
                var recipentUserEntity = userRepository.FindById(m.recipient_id);

                messages.Add(new Message(m.id, m.content, senderUserEntity.email, recipentUserEntity.email));
            });
            return messages;
        }

        public void SendMessage(MessageSendingData messageSendingData)
        {
            if (string.IsNullOrEmpty(messageSendingData.Content))
            {
                throw new ArgumentNullException();
            }
            if (messageSendingData.Content.Length > 5000)
            {
                throw new ArgumentOutOfRangeException();
            }

            var findUserEntity = userRepository.FindByEmail(messageSendingData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var messageEntity = new MessageEntity()
            {
                content = messageSendingData.Content,
                sender_id = messageSendingData.SenderId,
                recipient_id = findUserEntity.id
            };

            if (messageRepository.Create(messageEntity) == 0)
                throw new Exception();
        }
    }
}
