using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.EventAgrs
{
    public class UserSeatDetailsListEventArgs
    {
        private List<SeatDetails> seatDetails;
        private Int32 userId;
        private Int32 noOfSeats;

        public UserSeatDetailsListEventArgs(List<SeatDetails> seatDetails, int userId)
        {
            this.DeletedSeatDetails = seatDetails;
            this.UserId = userId;
        }

        public UserSeatDetailsListEventArgs(int userId, int noOfSeats)
        {
            this.userId = userId;
            this.noOfSeats = noOfSeats;
        }
        public UserSeatDetailsListEventArgs()
        {
        }

        public List<SeatDetails> DeletedSeatDetails
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

        public int NoOfSeats
        {
            get
            {
                return noOfSeats;
            }

            set
            {
                noOfSeats = value;
            }
        }
    }
}
