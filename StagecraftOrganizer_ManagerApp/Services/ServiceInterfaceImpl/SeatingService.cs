using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl
{
    public class SeatingService : ISeatingService
    {
        StagecraftOrganizer_ManagerAppDBContext _context =null;
        public SeatingService()
        {
            _context = new StagecraftOrganizer_ManagerAppDBContext();
        }

        public List<Block> getBlocksDetails()
        {
           //return _context.TheatreHalls.Where(m => m.TheatreHallId == 1).Select(x => x.Blocks).FirstOrDefault().ToList();
            return _context.Blocks.ToList();
        }

        public List<BlockRow> getBlockRowsByBlockNo(Int32 blockNo)
        {
            //return _context.Blocks.Where(y=>y.BlockNo == blockNo).Select(m => m.BlockRows).FirstOrDefault().ToList();
            return _context.BlockRows.Where(y => y.Block.BlockNo == blockNo).ToList();
        }

        public List<Seat> getSeatsDetailsByBlockRowNo(Int32 blockRowNo)
        {
            return _context.Seats.Where(y => y.BlockRow.RowNo == blockRowNo).ToList();
        }

        public Object[] getSeatingDetails()
        {
            Object[] seatingDetails = new Object[3];
            var blockRows= getBlocksDetails();
            List<List<BlockRow>> blockRowDetailList = new List<List<BlockRow>>();

            foreach (var block in blockRows)
            {
                blockRowDetailList.Add(getBlockRowsByBlockNo(block.BlockNo));
            }

            List<List<Seat>> blockSeatDetailList = new List<List<Seat>>();
            foreach (var block in blockRowDetailList)
            {
                foreach(var seatRow in block)
                {
                    blockSeatDetailList.Add(getSeatsDetailsByBlockRowNo(seatRow.RowNo));
                }
            }
            //Block b = new Block();
            //b.BlockRows = blockRowDetailList;
            //b.TheatreHallTheatreHall.Blocks = blockRows;

            seatingDetails[0] = blockRows;
            seatingDetails[1] = blockRowDetailList;
            seatingDetails[2] = blockSeatDetailList;

            return seatingDetails;
        }



     
    }
}
