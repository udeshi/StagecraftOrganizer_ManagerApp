using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StagecraftOrganizer_ManagerApp.Model.EventAgrs;

namespace StagecraftOrganizer_ManagerApp.Services.WCFServiceImpl
{
    [CallbackBehavior(UseSynchronizationContext = false)]
    internal class StagecraftOrganizingCallbackService : IStagecraftOrganizingServiceCallback
    {
        private SynchronizationContext _syncContext = AsyncOperationManager.SynchronizationContext;
        public event EventHandler<SeatDetailsListEventArgs> UpdatedListServiceCallbackEvent;
        public event EventHandler<UserSeatDetailsEventArgs> DeleteItemServiceCallbackEvent;
        public event EventHandler<UserSeatDetailsListEventArgs> SendRequestForMoreTicketsServiceCallbackEvent;
        public event EventHandler<SeatDetailsListEventArgs> SendAvailabiltyOfSeatsServiceCallbackEvent;
        public event EventHandler<UserSeatDetailsListEventArgs> NotifyToGetUpdatedSeatingListCallbackEvent;
        public event EventHandler<UserSeatDetailsListEventArgs> NotifyToCheckAvailabiltyOfSeatsCallbackEvent;

        #region SendUpdatedSeatingList
        public void SendUpdatedSeatingList(List<SeatDetails> seatingList)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceUpdatedListServiceCallbackEvent), new SeatDetailsListEventArgs(seatingList));
        }

        private void OnServiceUpdatedListServiceCallbackEvent(object state)
        {
            EventHandler<SeatDetailsListEventArgs> handler = UpdatedListServiceCallbackEvent;
            SeatDetailsListEventArgs e = state as SeatDetailsListEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region BookedSeatDetailsToDelete
        public void SendBookedSeatDetailsToDelete(int userId, SeatDetails seatDetails)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceSendBookedSeatDetailsToDeleteCallbackEvent), new UserSeatDetailsEventArgs(userId,seatDetails));
        }
        private void OnServiceSendBookedSeatDetailsToDeleteCallbackEvent(object state)
        {
            EventHandler<UserSeatDetailsEventArgs> handler = DeleteItemServiceCallbackEvent;
            UserSeatDetailsEventArgs e = state as UserSeatDetailsEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region SendRequestForMoreTickets
        public void SendRequestForMoreTickets(int userId, int noOfSeatsNeeded)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceRequestForMoreTicketsCallbackEvent), new UserSeatDetailsListEventArgs(userId, noOfSeatsNeeded));
        }
        private void OnServiceRequestForMoreTicketsCallbackEvent(object state)
        {
            EventHandler<UserSeatDetailsListEventArgs> handler = SendRequestForMoreTicketsServiceCallbackEvent;
            UserSeatDetailsListEventArgs e = state as UserSeatDetailsListEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region SendAvailabiltyOfSeats
        public void SendAvailabiltyOfSeats(List<SeatDetails> seatDetailsList)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceSendAvailabiltyOfSeatsCallbackEvent), new SeatDetailsListEventArgs(seatDetailsList));
        }
        private void OnServiceSendAvailabiltyOfSeatsCallbackEvent(object state)
        {
            EventHandler<SeatDetailsListEventArgs> handler = SendAvailabiltyOfSeatsServiceCallbackEvent;
            SeatDetailsListEventArgs e = state as SeatDetailsListEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion

        #region NotifyToGetUpdatedSeatingList
        public void NotifyToGetUpdatedSeatingList()
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceNotifyToGetUpdatedSeatingListCallbackEvent),new  UserSeatDetailsListEventArgs());
        }

        private void OnServiceNotifyToGetUpdatedSeatingListCallbackEvent(object state)
        {
            EventHandler<UserSeatDetailsListEventArgs> handler = NotifyToGetUpdatedSeatingListCallbackEvent;
            UserSeatDetailsListEventArgs e = state as UserSeatDetailsListEventArgs;
            if (handler != null)
            {
                handler(this,e);
            }
        }
        #endregion

        #region NotifyToCheckAvailabiltyOfSeats
        public void NotifyToCheckAvailabiltyOfSeats(List<SeatDetails> seatDetailsList)
        {
            _syncContext.Post(new SendOrPostCallback(OnServiceNotifyToCheckAvailabiltyOfSeatsCallbackEvent), new SeatDetailsListEventArgs(seatDetailsList));
        }

        private void OnServiceNotifyToCheckAvailabiltyOfSeatsCallbackEvent(object state)
        {
            EventHandler<UserSeatDetailsListEventArgs> handler = NotifyToCheckAvailabiltyOfSeatsCallbackEvent;
            UserSeatDetailsListEventArgs e = state as UserSeatDetailsListEventArgs;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

      

     
    }
}

