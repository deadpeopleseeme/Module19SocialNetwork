namespace SocialNetwork.BLL.Models
{
    public class Friend
    {
        public int FriendshipId { get; set; }
        public int UserId { get; set; }
        public int FriendId { get; set; }

        public Friend(int friendshipID, int userId, int friendId) 
        {
            FriendshipId = friendshipID;
            UserId = userId;
            FriendId = friendId;
        }
    }
}
