using GymDAL.Entities;
using GymPL.ViewModel.Auth;

namespace GymPL.Mapping
{
    public static class UserMapper
    {
        public static ApplicationUser EntityToApplicationUser(this CreateUserVM createUserVm)
        {
            return new ApplicationUser
            {
                UserName = createUserVm.UserName,
                Email = createUserVm.Email
            };
        }
        //public static ApplicationUser EntityToApplicationUser(this LogInUserVM logInUserVm)
        //{
        //    return new ApplicationUser
        //    {
        //        UserName = logInUserVm.UserName,
        //    };
        //}
    }
}