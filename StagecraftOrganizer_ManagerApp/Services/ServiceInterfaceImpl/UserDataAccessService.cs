using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StagecraftOrganizer_ManagerApp.Model;
using System.Collections.ObjectModel;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class UserDataAccessService : IUserDataAccessService
    {
        private StagecraftOrganizer_ManagerAppDBContext _context;

        public UserDataAccessService()
        {
            _context = new StagecraftOrganizer_ManagerAppDBContext();
        }

        //insert user details
        public Int32 createUser(User user)
        {
            if (_context.Users.Count() == 0)
            {
                user.UserId = 1;
            }
            else {
                user.UserId = _context.Users.Select(u => u.UserId).Max() + 1;
            }
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Users ON");
            _context.Users.Add(user);
            _context.SaveChanges();
            //_context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Users OFF");
           
            return user.UserId;
        }

        //get user by email
        public User getUserByEmail(String email)
        {
            return _context.Users.Where(u => u.Email.Equals(email)).FirstOrDefault();
        }

        //get user by id
        public User getUserById(Int32 userId)
        {
            return _context.Users.Where(m => m.UserId == userId).FirstOrDefault();
        }

     
    }
}
