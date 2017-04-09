using StagecraftOrganizer_ManagerApp.Model.Enums;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Model.Constants;
using StagecraftOrganizer_ManagerApp.Helper;
using StagecraftOrganizer_ManagerApp.Model.UIModel;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class ValidationService : IValidationService
    {
        private readonly IAuthenticationService _authenticationService;

        public ValidationService(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        #region supporting methods

        //get validity of the user
        private Boolean isValidUser(String input)
        {
            return _authenticationService.isValidUser(input);
        }

        //get validity of the password
        private Boolean isValidPassword(String input)
        {
            input = input != String.Empty ? input.Substring(input.Length - 1) : input;
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }

        //compare the passwords
        private Boolean isCorrectConfirmPassword(String input, String password)
        {
            var correctCharacter = Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
            if (correctCharacter)
            {
                var result = String.Compare(password, input);
                if (result == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //check validity of the email
        private Boolean isValidEmail(String input)
        {
            return Regex.IsMatch(input, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        }

        #endregion

        #region validating methods

        //validate new user value
        public Boolean validateNewUser(String email, out ICollection<CustomErrorType> validationErrors)
        {
            validationErrors = new List<CustomErrorType>();
            if (isValidEmail(email))
            {
                if (isValidUser(email))
                {
                    validationErrors.Add(new CustomErrorType("User already exist", Severity.ERROR));
                }
            }
            else
            {
                validationErrors.Add(new CustomErrorType("Invalid Email Format", Severity.ERROR));
            }
            return validationErrors.Count == 0;
        }

        //validate confirm password value
        public Boolean validateConfirmPassword(String confirmPassword, String password, out ICollection<CustomErrorType> validationErrors)
        {
            validationErrors = new List<CustomErrorType>();
            if (!isCorrectConfirmPassword(confirmPassword, password))
            {
                validationErrors.Add(new CustomErrorType("Passwords doesn't match ", Severity.ERROR));
            }
            return validationErrors.Count == 0;
        }

        // validate registed user details
        public Boolean validateCurrentUser(String email, out ICollection<CustomErrorType> validationErrors)
        {
            validationErrors = new List<CustomErrorType>();
            if (!isValidUser(email))
            {
                validationErrors.Add(new CustomErrorType("Invalid email", Severity.ERROR));
            }
            return validationErrors.Count == 0;
        }

        //validate password
        public Boolean validatePassword(String password, out ICollection<CustomErrorType> validationErrors)
        {
            validationErrors = new List<CustomErrorType>();
            if (!isValidPassword(password))
            {
                validationErrors.Add(new CustomErrorType("Invalid password", Severity.ERROR));
            }
            return validationErrors.Count == 0;
        }
        #endregion
    }
}
