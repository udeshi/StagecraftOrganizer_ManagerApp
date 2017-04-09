using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
    public interface ITicketBookingDataAccessService
    {
        //void createTicketIssueRecord(TicketIssue ticketIssueDetails, List<SeatDetails> SessionSeatDetails,Int32 userId);

        Task<Int32> AddBookings(List<SeatDetails> sessionSeatDetails, Int32 userId);

        Task AddBooking(SeatDetails seatDetails);

        List<SeatDetails> GetSeatBookingDetails();
    }
}
