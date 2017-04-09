using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.UIModel
{
    public class TicketTypeDetails
    {
        private String _ticketPrice;
        private String _ticketTypeColour;

        public string TicketPrice
        {
            get
            {
                return _ticketPrice;
            }

            set
            {
                _ticketPrice = value;
            }
        }

        public string TicketTypeColour
        {
            get
            {
                return _ticketTypeColour;
            }

            set
            {
                _ticketTypeColour = value;
            }
        }
    }
}
