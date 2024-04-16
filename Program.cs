using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using System;
using System.Linq.Expressions;

namespace SocialNetwork
{
    internal class Program
    {
        public static UserService userService= new UserService();  
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO SUPA DUPA SOCIAL NETWORK");

            while(true)
            {
                Console.WriteLine("enter your name: ");
                string _firstName = Console.ReadLine();

                Console.WriteLine("enter your surname: ");
                string _lastName = Console.ReadLine();

                Console.WriteLine("enter your password, min length is 8symb: ");
                string _password = Console.ReadLine();

                Console.WriteLine("enter your email address: ");
                string _email = Console.ReadLine();

                var userRegData = new UserRegistrationData(_firstName, _lastName, _password, _email);

                try
                {
                    userService.Register(userRegData);
                    Console.WriteLine("success! registration done");
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("some of data you've entered is incorrect, try one more time! ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
