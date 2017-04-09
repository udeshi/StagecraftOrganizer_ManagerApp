using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Helper
{
    public class ContentHelper
    {
        public static string PropCase(string strText)
        {
            return new CultureInfo("en-uk").TextInfo.ToTitleCase(strText.ToLower());
        }
    }
}
