using StagecraftOrganizer_ManagerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterface
{
   public interface ISeatingService
    {
        Object[] getSeatingDetails();
        List<Seat> getSeatsDetailsByBlockRowNo(Int32 blockRowNo);
        List<BlockRow> getBlockRowsByBlockNo(Int32 blockNo);
        List<Block> getBlocksDetails();
    }
}
