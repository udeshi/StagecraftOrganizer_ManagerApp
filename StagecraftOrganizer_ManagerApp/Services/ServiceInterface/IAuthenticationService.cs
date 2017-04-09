using StagecraftOrganizer_ManagerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
    public interface IAuthenticationService
    {
        User authenticateUser(String email, String password);//authenticate a registered user
      
        Boolean isValidUser(String input);  //check whether the user exists in the system
    }
}
