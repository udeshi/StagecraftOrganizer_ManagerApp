using StagecraftOrganizer_ManagerApp.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.UIModel
{
    public class CustomErrorType
    {
        public CustomErrorType(String validationMessage, Severity severity)
        {
            this.ValidationMessage = validationMessage;
            this.Severity = severity;
        }

        public String ValidationMessage { get; private set; }
        public Severity Severity { get; private set; }
    }
}
