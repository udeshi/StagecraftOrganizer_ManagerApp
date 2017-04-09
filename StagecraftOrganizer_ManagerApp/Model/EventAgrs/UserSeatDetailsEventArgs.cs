using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.EventAgrs
{
    public class UserSeatDetailsEventArgs
    {
        private SeatDetails seatDetails;
        private Int32 userId;

        public SeatDetails SeatDetails
        {
            get
            {
                return this.seatDetails;
            }

            set
            {
                this.seatDetails = value;
            }
        }

        public int UserId
        {
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
            }
        }

        public UserSeatDetailsEventArgs(Int32 userId,SeatDetails seatDetails)
        {
            this.seatDetails = seatDetails;
            this.userId = userId;
        }
    }
}
