using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.EventAgrs
{
    public class SeatDetailsEventArgs
    {
        private SeatDetails deletedSeatDetails;

        public SeatDetails DeletedSeatDetails
        {
            get
            {
                return this.deletedSeatDetails;
            }

            set
            {
                this.deletedSeatDetails = value;
            }
        }
        public SeatDetailsEventArgs(SeatDetails seatDetails)
        {
            this.deletedSeatDetails = seatDetails;
        }
    }
}
