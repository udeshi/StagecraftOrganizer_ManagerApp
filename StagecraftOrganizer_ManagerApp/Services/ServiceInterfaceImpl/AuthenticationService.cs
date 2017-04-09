using StagecraftOrganizer_ManagerApp.Helper;
using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class AuthenticationService : IAuthenticationService
    {
        IUserDataAccessService _userDataAccessService;
        public AuthenticationService(IUserDataAccessService userDataAccessService)
        {
            _userDataAccessService = userDataAccessService;
        }
      
        //authenticate a registered user
        public User authenticateUser(String email, String password)
        {

            var userDetails = _userDataAccessService.getUserByEmail(email);
            if (userDetails == null)
            {
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
            }
            else
            {
                var pass = PasswordHash.HashPassword(password);
                if (PasswordHash.ValidatePassword(password, userDetails.Password))
                {
                    return userDetails;
                }
                else
                {
                    throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
                }
            }
        }

        //check whether the user exists in the system
        public Boolean isValidUser(String input)
        {
            var user = _userDataAccessService.getUserByEmail(input);
            if (user != null) {
                var userEmail = user.Email;
                if (userEmail != null || userEmail != String.Empty)
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


    }

}
