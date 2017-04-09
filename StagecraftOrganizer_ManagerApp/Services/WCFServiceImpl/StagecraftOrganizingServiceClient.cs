using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.WCFServiceImpl
{
    internal class StagecraftOrganizingServiceClient : DuplexClientBase<IStagecraftOrganizingService>, IStagecraftOrganizingService
    {
        public StagecraftOrganizingServiceClient(InstanceContext callbackInstance)
            : base(callbackInstance)
        { }

        public void BookSeats(List<SeatDetails> seatDetailsList)
        {
            Channel.BookSeats(seatDetailsList);
        }

        public void CheckAvailibility(List<SeatDetails> seatDetails)
        {
            Channel.CheckAvailibility(seatDetails);
        }

        public void Connect()
        {
            Channel.Connect();
        }

       
        public void DeleteBookedSeat(int userId, SeatDetails seatDetails)
        {
            Channel.DeleteBookedSeat(userId, seatDetails);
        }

        public void Disconnect()
        {
            Channel.Disconnect();
        }


        public void RequestMoreSeats(int userId, int noOfSeatsNeeded)
        {
            Channel.RequestMoreSeats(userId, noOfSeatsNeeded);
        }

        public void RequestUpdatedSeatList()
        {
            Channel.RequestUpdatedSeatList();
        }

        public void SendUpdatedList(List<SeatDetails> updatedSeatDetailsList)
        {
            Channel.SendUpdatedList(updatedSeatDetailsList);
        }
    }

}
