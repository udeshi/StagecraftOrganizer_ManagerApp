using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.UIModel
{
    public class BookedTicketDetails
    {
        private String _ticketNo;
        private String _ticketTypeColour;
        private DateTime _purchasedDate;

        public BookedTicketDetails(string ticketNo, string ticketTypeColour, DateTime purchasedDate)
        {
            this._ticketNo = ticketNo;
            this._ticketTypeColour = ticketTypeColour;
            this._purchasedDate = purchasedDate;
        }

        public string TicketNo
        {
            get
            {
                return _ticketNo;
            }

            set
            {
                _ticketNo = value;
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

        public DateTime PurchasedDate
        {
            get
            {
                return _purchasedDate;
            }

            set
            {
                _purchasedDate = value;
            }
        }
    }
}
