using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.ViewModel
{
    public class NotificationMessageViewModel : ViewModelBase
    {
        List<String> _notificationMessageList;

        public List<string> NotificationMessageList
        {
            get
            {
                return _notificationMessageList;
            }

            set
            {
                _notificationMessageList = value;
                RaisePropertyChanged("NotificationMessageList");
            }
        }




    }
}
