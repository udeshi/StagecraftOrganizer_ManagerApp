using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class TicketDataAccessService : ITicketDataAccessService
    {
        StagecraftOrganizer_ManagerAppDBContext _context = null;
        public TicketDataAccessService()
        {
            _context = new StagecraftOrganizer_ManagerAppDBContext();
        }
        public decimal GetTicketPrice(string ticketType)
        {
          return (Decimal) _context.Tickets.Where(x => x.TicketType.TypeName.ToLower().Equals(ticketType)).Select(c => c.TicketType.Price).FirstOrDefault();
        }
        public List<Ticket> GetBookedTicketsByUserId(int userId)
        {
            return _context.Tickets.Where(x => x.Booking.User.UserId==userId).ToList();
        }

    }
}
