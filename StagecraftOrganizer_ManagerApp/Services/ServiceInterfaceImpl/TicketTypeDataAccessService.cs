using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StagecraftOrganizer_ManagerApp.Model;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class TicketTypeDataAccessService : ITicketTypeDataAccessService
    {
        StagecraftOrganizer_ManagerAppDBContext _context = null;
        public TicketTypeDataAccessService()
        {
            _context = new StagecraftOrganizer_ManagerAppDBContext();
        }

        public List<TicketType> getTicketTypes()
        {
          return  _context.TicketTypes.ToList();
        }
    }
}
