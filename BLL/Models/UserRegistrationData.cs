﻿namespace SocialNetwork.BLL.Models
{
    public class UserRegistrationData
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public UserRegistrationData(string firstName, string lastName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }

        public UserRegistrationData()
        {
        }
    }
}
