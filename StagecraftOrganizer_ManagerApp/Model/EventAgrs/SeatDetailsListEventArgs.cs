using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.EventAgrs
{
   public class SeatDetailsListEventArgs
    {
        private List<SeatDetails> seatDetailsList;

        public List<SeatDetails> SeatDetailsList
        {
            get {
                return this.seatDetailsList;
            }
            set {
                this.seatDetailsList = value;
            }
        }

        public SeatDetailsListEventArgs(List<SeatDetails> seatDetailsList)
        {
            this.seatDetailsList = seatDetailsList;
        }
    }
}
