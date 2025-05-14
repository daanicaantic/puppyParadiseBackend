using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Constants.ExceptionsConstants
{
    public static class UserExceptionsConstants
    {
        public const string UserWithGivenIdNotFound = "User with this ID doesn't exist.";
        public const string UserWithGivenEmailNotFound = "User with this email doesn't exist.";
        public const string UserWithGivenPhoneNumberNotFound = "User with this phone number doesn't exist.";
        public const string UserWithGivenEmailAlreadyExists = "User with this email already exists.";
        public const string UserWithGivenPhoneNumberAlreadyExists = "User with this phone number already exists.";
        public const string UserWithGivenCredentialsNotFound = "User with this email and password doesn't exist.";
        public const string UsersPasswordIsNotCorrect = "Users password is not correct.";
        public const string PasswordsDoNotMatch = "Passwords do not match.";
        public const string InvalidEmailFormat = "Invalid email format.";
        public const string InvalidPasswordFormat = "Password must be at least 6 characters and contain letters and numbers.";
        public const string RoleNotFound = "Role not found.";
    }
}
