using ImagePick.Application.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class UserApplicationStub
    {
        public static UserApplication user_null = null;

        public static UserApplication user_1 = new UserApplication()
        {
            Id = 1,
            Email = "email@prueba.com",
            FirstName = "Jorge",
            LastName = "Britez",
        };

        public static UserApplication user_2 = new UserApplication()
        {
            Id = 2,
            Email = "email2@prueba.com",
            FirstName = "Jorge2",
            LastName = "Britez2",
        };

        public static List<UserApplication> users =
            new List<UserApplication>(new UserApplication[] { user_1, user_2 });

    }
}
