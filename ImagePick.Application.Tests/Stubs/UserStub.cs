using ImagePick.DataAccess.Contracts.Entities;
using System.Collections.Generic;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class UserStub
    {
        
        public static User user_null = null;

        public static User user_1 = new User()
        {
            Id = "xxx",
            Email = "email@prueba.com",
            FirstName = "Jorge",
            LastName = "Britez",             
        };

        public static User user_2 = new User()
        {
            Id = "yyy",
            Email = "email2@prueba.com",
            FirstName = "Jorge2",
            LastName = "Britez2",
        };

        public static List<User> users = 
            new List<User>(new User[] { user_1, user_2 });

    }
}
