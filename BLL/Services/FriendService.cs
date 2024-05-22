using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SocialNetwork.BLL.Services
{
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }
        
        public void AddFriend(FriendAddingData friendAddingData)
        {
            // проверяем, ввёл ли вообще юзер что-то в инпут
            if (string.IsNullOrEmpty(friendAddingData.RecipientEmail))
            {
                throw new ArgumentNullException();
            }

            // ищем по емейлу юзера, если такого нет, кидаем эксепшн
            var findFriendEntity = userRepository.FindByEmail(friendAddingData.RecipientEmail);
            if (findFriendEntity is null) throw new UserNotFoundException();

            // создаем сущность друга, которого нужно добавить
            var friendEntity = new FriendEntity()
            {
                user_id = friendAddingData.SenderId,
                friend_id = findFriendEntity.id
            };

            // если юзер пытается добавить в друзья сам себя, кидаем эксепшн
            if(friendEntity.user_id == friendEntity.friend_id)
            {
                throw new CantBefriendYourselfException();
            }

            // формируем список друзей, которые у нас уже есть
            var friendsList = GetFriendsByUserId(friendAddingData.SenderId);

            // если друг уже добавлен, кидаем эксепшн 
            foreach (var friend in friendsList)
            {
                if(friendEntity.friend_id == friend.FriendId)
                {
                    throw new UserIsAlreadyFriendlistedException();
                }               
            }
           
            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();

            // нашего юзера тоже нужно внести в список друзей друга, которого мы только что добавили
            var userToAddBackAsFriend = new FriendEntity()
            {
                user_id = findFriendEntity.id,
                friend_id = friendAddingData.SenderId
            };

            if (friendRepository.Create(userToAddBackAsFriend) == 0)
                throw new Exception();
        }
      
        public IEnumerable<Friend> GetFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();
            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                friends.Add(new Friend(f.id, f.user_id, f.friend_id));
            });
            return friends;
        }     
    }
}
