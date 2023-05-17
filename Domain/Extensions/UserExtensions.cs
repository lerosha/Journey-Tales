using Domain.DTO;
using Domain.Views.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class UserExtensions
    {
        public static UserView ConvertToView(this User entity)
        {
            return new UserView()
            {
                Id = entity.Id,
                Email = entity.Email,
                CreatedOn = entity.CreatedOn,
                ModifiedOb = entity.ModifiedOn
            };
        }
        public static User ConvertToEntity(this CreateUserView view)
        {
            return new User()
            {
                Email = view.Email,
                Password = view.Password,
            };
        }
        public static User ConvertToEntity(this UpdateUserView view)
        {
            return new User()
            {
            };
        }
    }
}
