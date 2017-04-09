using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StagecraftOrganizer_ManagerApp.Model;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
    public interface IUserDataAccessService
    {
        Int32 createUser(User user); //insert user details
        User getUserByEmail(String email);    //get user by email
        User getUserById(Int32 userId);    //get user by id
    }
}
