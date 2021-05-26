using ImagePick.DataAccess.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ImagePick.Application.Unit.Tests.Stubs
{
    public static class UserStub
    {
        public static User user_1 = new User()
        {
            Id = 1,
            Email = "email@prueba.com",
            FirstName = "Jorge",
            LastName = "Britez",             
        };
    }
}
