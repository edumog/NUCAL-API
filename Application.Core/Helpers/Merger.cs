using NUCAL.Application.Core.DTOs;
using NUCAL.Application.Core.Entities;

namespace NUCAL.Application.Core.Helpers
{
    public static class Merger
    {
        public static UserDTO MergeUserResponseAndUserDb(UserDTO user, User userDb)
        {
            user.UserName = userDb.UserName;
            user.FirstName = userDb.FirstName;
            user.LastName = userDb.LastName;
            return user;
        }
    }
}
