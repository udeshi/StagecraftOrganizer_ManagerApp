using StagecraftOrganizer_ManagerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
    public interface ITicketTypeDataAccessService
    {
        List<TicketType> getTicketTypes();
    }
}