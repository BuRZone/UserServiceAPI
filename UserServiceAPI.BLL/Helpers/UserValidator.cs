using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UserServiceAPI.BLL.Models;

namespace UserServiceAPI.BLL.Helpers
{
    public static class UserValidator
    {
        public static bool UserValidation(CreateUserDto userDto)
        {
            var context = new ValidationContext(userDto);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(userDto, context, results, true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool UserValidation(UpdateUserDto userDto)
        {
            var context = new ValidationContext(userDto);
            var results = new List<ValidationResult>();
            if (Validator.TryValidateObject(userDto, context, results, true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}