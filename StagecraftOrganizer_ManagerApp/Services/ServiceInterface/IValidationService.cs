using StagecraftOrganizer_ManagerApp.Model.UIModel;
using System;
using System.Collections.Generic;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
    public interface IValidationService
    {       
        Boolean validatePassword(String password, out ICollection<CustomErrorType> validationErrors);//validate password
        Boolean validateCurrentUser(String email, out ICollection<CustomErrorType> validationErrors);  // validate registed user details
        Boolean validateConfirmPassword(String confirmPassword, String password, out ICollection<CustomErrorType> validationErrors);     //validate confirm password value
        Boolean validateNewUser(String email, out ICollection<CustomErrorType> validationErrors);   //validate new user value
    }
}
