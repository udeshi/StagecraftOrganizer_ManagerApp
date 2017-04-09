using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Helper
{
    public class UserDetailsHelper
    {
        public static String getUserName(String email)
        {
            return email.Split('@')[0];
        }
    }
}
