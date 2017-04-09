using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.UIModel
{
  public  class BookingStatus
    {
        private String _status;
        private String _statusColour;

        public BookingStatus(string _status, string _statusColour)
        {
            this._status = _status;
            this._statusColour = _statusColour;
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
            }
        }

        public string StatusColour
        {
            get
            {
                return _statusColour;
            }

            set
            {
                _statusColour = value;
            }
        }
    }
}
