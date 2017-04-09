using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Model.UIModel
{
    public class SeatUI
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public String BgColour { get; set; }
        public Int32 BlockNo { get; set; }
        public Int32 RowNo { get; set; }
        public Int32 SeatNo { get; set; }
        public Int32 FloorNo { get; set; }
        public String SeatAlignment { get; set; }
        public Int32 TicketNo { get; set; }
        public String TicketType { get; set; }
        public String TicketTypeColour { get; set; }
        public Boolean IsEditable { get; set; }
        public String RowLetter { get; set; }
    }
}
