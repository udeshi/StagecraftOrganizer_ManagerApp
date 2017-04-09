using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Model.Constants;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class TicketBookingDataAccessService : ITicketBookingDataAccessService
    {

        StagecraftOrganizer_ManagerAppDBContext _context = null;
        public TicketBookingDataAccessService()
        {
            _context = new StagecraftOrganizer_ManagerAppDBContext();
        }

        public async Task AddBooking(SeatDetails seatDetails)
        {
            var ticketDetails = _context.Tickets.Where(x => x.TicketNo == seatDetails.TicketDetails.TicketNo).FirstOrDefault();
            if (ticketDetails.Booking_BookingId != 0)
            {
                Booking bookingDetails = new Booking();
                bookingDetails.BookingDate = DateTime.Now;

                bookingDetails.BookingId = _context.Bookings.Count() == 0 ? 1 : _context.Bookings.Max(x => x.BookingId)+1;

                _context.Bookings.Add(bookingDetails);

                ticketDetails.Booking_BookingId = bookingDetails.BookingId;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<Int32> AddBookings(List<SeatDetails> sessionSeatDetails, int userId)
        {
            Booking bookingDetails = new Booking();
            bookingDetails.BookingDate = DateTime.Now;

            bookingDetails.BookingId = _context.Bookings.Count() == 0 ? 1 : _context.Bookings.Max(x => x.BookingId)+1;
            bookingDetails.User.UserId = userId;
            _context.Bookings.Add(bookingDetails);
            Int32 newBookingId = _context.SaveChanges();
            foreach (var details in sessionSeatDetails)
            {
                var ticketDetails=_context.Tickets.Where(x => x.TicketNo == details.TicketDetails.TicketNo).FirstOrDefault();
                ticketDetails. Booking_BookingId= bookingDetails.BookingId;
                await _context.SaveChangesAsync();
            }
            return newBookingId;
        }

        public List<SeatDetails> GetSeatBookingDetails()
        {
            List<SeatDetails> seatDetailsList = new List<SeatDetails>();
          var Bookings=  _context.Bookings.ToList();
            foreach 
                (var details in Bookings)
            {
                SeatDetails details = new SeatDetails();
                details.BgColour = Constants.bookedSeatColour;
                details.
            }
        }




        //public void createTicketIssueRecord(Booking bookingDetails, List<SeatDetails> SessionSeatDetails,Int32 userId)
        //{
        //    //try {
        //    //    var dateTime = DateTime.Now;
        //    //    bookingDetails.Customer.CustomerId = _context.Customers.Count() == 0 ? 1 : _context.Customers.Max(x => x.CustomerId) + 1;
        //    //    ticketIssueDetails.CustomerCustomerId = ticketIssueDetails.Customer.CustomerId;



        //    //    ticketIssueDetails.IssueDate = dateTime;
        //    //    ticketIssueDetails.TicketIssueId = _context.TicketIssues.Count() == 0 ? 1 : _context.TicketIssues.Max(x => x.TicketIssueId);
        //    //    ticketIssueDetails.TicketIssueDetails = new List<TicketIssueDetail>();
        //    //    ticketIssueDetails.CounterCounterNo = _context.UserAssignments.Where(x => x.UserUserId == userId).FirstOrDefault().CounterCounterNo;
        //    //    foreach (var seatDetails in SessionSeatDetails)
        //    //    {
        //    //        TicketIssueDetail details = new TicketIssueDetail();
        //    //        if (ticketIssueDetails.TicketIssueDetails.Count() == 0)
        //    //        {
        //    //            details.TicketIssueDetailsId = _context.TicketIssueDetails.Count() == 0 ? 1 : _context.TicketIssueDetails.Max(x => x.TicketIssueDetailsId);
        //    //        }
        //    //        else
        //    //        {
        //    //            details.TicketIssueDetailsId = ticketIssueDetails.TicketIssueDetails.Last().TicketIssueDetailsId + 1;
        //    //        }

        //    //        details.TicketTicketNo = seatDetails.TicketDetails.TicketNo;
        //    //        var issueStatusId = ticketIssueDetails.PendingAmount == 0 ? 1 : 2;
        //    //        details.IssueStatusIssueStatus = _context.IssueStatuses.Where(x=>x.IssueStatusId== issueStatusId).FirstOrDefault();

        //    //        details.TicketIssueTicketIssueId = ticketIssueDetails.TicketIssueId;
        //    //        // details.IssueStatusIssueStatus.

        //    //        ticketIssueDetails.TicketIssueDetails.Add(details);
        //    //    }


        //    //    _context.TicketIssues.Add(ticketIssueDetails);
        //    //    _context.SaveChanges();

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Console.WriteLine(ex.Message);

        //    //}
        //}
    }
}
