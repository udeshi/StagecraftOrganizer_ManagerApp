using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using StagecraftOrganizer_ManagerApp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using StagecraftOrganizer_ManagerApp.Model.Enums;
using System;
using System.Windows;
using StagecraftOrganizer_ManagerApp.Services.WCFServiceImpl;
using StagecraftOrganizer_ManagerApp.Model.EventAgrs;
using System.ServiceModel;
using System.Windows.Data;
using StagecraftOrganizer_ManagerApp.Model.Constants;
using System.Windows.Threading;
using MahApps.Metro.Controls.Dialogs;
using StagecraftOrganizer_ManagerApp.View;
using GalaSoft.MvvmLight.Messaging;
using StagecraftOrganizer_ManagerApp.Model.UIModel;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using System.Threading;
using System.Threading.Tasks;

namespace StagecraftOrganizer_ManagerApp.ViewModel
{
    public class ManageSeatingViewModel : ViewModelBase
    {
        #region Private variables
        //references for services
        private readonly ISeatingService _seatingService;
        private readonly ITicketTypeDataAccessService _ticketTypeDataAccessService;
        private readonly ITicketDataAccessService _ticketDataAccessService;
        private readonly ITicketBookingDataAccessService _ticketBookingDataAccessService;
        private readonly IDialogCoordinator _dialogCoordinator;

        //observable collection to generate seat view
        private static ObservableCollection<ObservableCollection<ObservableCollection<ObservableCollection<SeatUI>>>> _seatUIList;

        private Int32 _maxTicketCount;// a variable to store the maximumm no of seats that can be booked by the user
        private Decimal _totalPrice;// avariable to update the ticket prices

        private List<TicketTypeDetails> _ticketTypeDetailsList;
        private List<BookingStatus> _bookingStatusList;



        private String _status;//represents errors 
        private Boolean _isWarning;// represnts there is a warinig or not to display warnings dynamially
        private Visibility _warningVisibility;// visibility of error messages



        private DispatcherTimer _timer = null;  // reference to the timer
        private Double _countDownTimer;// variable to track the time

        private Int32 _reservedTicketCounter = 0;//to track the maximum no of tickets that can be booked


        private IssueStatus _issueStatus;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seatingService"></param>
        /// <param name="dialogCoordinator"></param>
        /// <param name="ticketTypeDataAccessService"></param>
        /// <param name="ticketBookingDataAccessService"></param>
        /// <param name="ticketDataAccessService"></param>
        public ManageSeatingViewModel(ISeatingService seatingService, IDialogCoordinator dialogCoordinator, ITicketTypeDataAccessService ticketTypeDataAccessService, ITicketBookingDataAccessService ticketBookingDataAccessService, ITicketDataAccessService ticketDataAccessService)
        {
            _seatingService = seatingService;
            _dialogCoordinator = dialogCoordinator;
            _ticketTypeDataAccessService = ticketTypeDataAccessService;
            _ticketBookingDataAccessService = ticketBookingDataAccessService;
            _ticketDataAccessService = ticketDataAccessService;
            MaxTicketCount = Constants.maxNoOfSeatsPerSession;//initialize the variable
            SeatUIList = new ObservableCollection<ObservableCollection<ObservableCollection<ObservableCollection<SeatUI>>>>();
            WarningVisibility = Visibility.Hidden;//visibility of warnings
            GenerateSeatings();// initialize the view of the seats
            InitializeSeatDetailsList();//initilaize the list about seating status
            InitializeTicketTypeDetailsList();//initialize ticket type details
        }



  

        #region Properties
        public ObservableCollection<ObservableCollection<ObservableCollection<ObservableCollection<SeatUI>>>> SeatUIList
        {
            get
            {
                return _seatUIList;
            }

            set
            {
                _seatUIList = value;
                RaisePropertyChanged("SeatUIList");
            }
        }

        public string Status
        {
            get
            {
                return _status;
            }

            set
            {
                _status = value;
                RaisePropertyChanged("Status");
            }
        }

        public bool IsWarning
        {
            get
            {
                return _isWarning;
            }

            set
            {
                _isWarning = value;
                if (_isWarning)
                {
                    WarningVisibility = Visibility.Visible;
                }
                else
                {
                    WarningVisibility = Visibility.Hidden;
                }
                RaisePropertyChanged("IsWarning");
            }
        }

        public Visibility WarningVisibility
        {
            get
            {
                return _warningVisibility;
            }

            set
            {
                _warningVisibility = value;
                RaisePropertyChanged("WarningVisibility");
            }
        }

    

        public List<TicketTypeDetails> TicketTypeDetailsList
        {
            get
            {
                return _ticketTypeDetailsList;
            }

            set
            {
                _ticketTypeDetailsList = value;
                RaisePropertyChanged("TicketTypeDetailsList");
            }
        }

        public List<BookingStatus> BookingStatusList
        {
            get
            {
                return _bookingStatusList;
            }

            set
            {
                _bookingStatusList = value;
                RaisePropertyChanged("BookingStatusList");
            }
        }

        public int MaxTicketCount
        {
            get
            {
                return _maxTicketCount;
            }

            set
            {
                _maxTicketCount = value;
                RaisePropertyChanged("MaxTicketCount");
            }
        }

     

        #endregion


        #region Private methods

        #region Initialize the view
   
        /// <summary>
        /// Generate the view of the seats
        /// </summary>
        private void GenerateSeatings()
        {
            try
            {
                var details = _seatingService.getSeatingDetails();
                List<Block> blockDetails = _seatingService.getBlocksDetails();
                List<List<Seat>> blockSeatDetailList = (List<List<Seat>>)details[2];
                ObservableCollection<SeatUI> row = null;
                ObservableCollection<ObservableCollection<SeatUI>> block = null;
                ObservableCollection<ObservableCollection<ObservableCollection<SeatUI>>> floors = null;

                var _floors = blockDetails.GroupBy(x => x.Floor)
          .Select(g => g.First());

                var _floorCount = 0;
                foreach (var _floorDetails in _floors)//get floors
                {
                    floors = new ObservableCollection<ObservableCollection<ObservableCollection<SeatUI>>>();
                    var _blockDetails = blockDetails.Where(x => x.Floor == _floorDetails.Floor);
                    var _blockCount = 0;
                    foreach (var _blocks in _blockDetails)//get blocks in each floor
                    {
                        block = new ObservableCollection<ObservableCollection<SeatUI>>();
                        var _blockRowCount = 0;
                        var _blockRowDetails = _seatingService.getBlockRowsByBlockNo(_blocks.BlockNo);
                        foreach (var _rowDetails in _blockRowDetails)//get rows in each block
                        {
                            row = new ObservableCollection<SeatUI>();
                            var _rowSeats = _rowDetails.Seats;
                            foreach (var _seat in _rowSeats)
                            {
                                SeatUI seatDetails = new SeatUI();
                                seatDetails.BgColour = Constants.initialSeatColour;
                                seatDetails.Width = 15;
                                seatDetails.Height = 18;
                                seatDetails.SeatNo = _seat.SeatNo;
                                seatDetails.RowNo = _blockRowCount;
                                seatDetails.BlockNo = _blockCount;
                                seatDetails.FloorNo = _floorCount;
                                seatDetails.TicketNo = _seat.Ticket.TicketNo;
                                seatDetails.TicketType = _seat.Ticket.TicketType.TypeName;
                                seatDetails.IsEditable = true;
                                seatDetails.RowLetter = _seat.BlockRow.RowLetter;
                                switch (seatDetails.TicketType)
                                {
                                    case "Platinum":
                                        seatDetails.TicketTypeColour = Constants.platinumTickectColour;
                                        break;
                                    case "Gold":
                                        seatDetails.TicketTypeColour = Constants.goldTickectColour;
                                        break;
                                    case "Silver":
                                        seatDetails.TicketTypeColour = Constants.silverTickectColour;
                                        break;
                                    case "Bronze":
                                        seatDetails.TicketTypeColour = Constants.bronzeTickectColour;
                                        break;
                                    default:
                                        break;
                                }

                                if (_blocks.Direction.ToLower().Contains("left"))//align seats
                                {
                                    seatDetails.SeatAlignment = "Right";
                                }
                                else if (_blocks.Direction.ToLower().Contains("right"))
                                {
                                    seatDetails.SeatAlignment = "Left";
                                }

                                row.Add(seatDetails);
                            }
                            block.Add(row);
                            _blockRowCount++;
                        }
                        floors.Add(block);
                        _blockCount++;
                    }
                    SeatUIList.Add(floors);
                    _floorCount++;
                }
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                IsWarning = true;
            }
        }
      

        /// <summary>
        ///  initialize ticket type details
        /// </summary>
        private void InitializeTicketTypeDetailsList()
        {
            TicketTypeDetailsList = new List<TicketTypeDetails>();
            try
            {
                var ticketTypes = _ticketTypeDataAccessService.getTicketTypes();
                String symbol = "Rs. ";
                foreach (var ticketType in ticketTypes)
                {
                    TicketTypeDetails details = new TicketTypeDetails();
                    details.TicketPrice = symbol + ticketType.Price;
                    details.TicketTypeColour = ticketType.TicketTypeId == 1 ? Constants.platinumTickectColour : ticketType.TicketTypeId == 2 ? Constants.goldTickectColour : ticketType.TicketTypeId == 3 ? Constants.silverTickectColour : Constants.bronzeTickectColour;
                    TicketTypeDetailsList.Add(details);
                }
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                IsWarning = true;
            }
        }

        /// <summary>
        /// Initialize seat booking status
        /// </summary>
        private void InitializeSeatDetailsList()
        {
            BookingStatusList = new List<BookingStatus>();
            BookingStatusList.Add(new BookingStatus(Properties.Resources.BookedSeats, Constants.bookedSeatColour));
            BookingStatusList.Add(new BookingStatus(Properties.Resources.SelectedSeats, Constants.reservedSeatColour));
            BookingStatusList.Add(new BookingStatus(Properties.Resources.CurrentUsersBookedSeats, Constants.currentUsersBookedSeatsColour));
        }

        #endregion





   


            #region callbacks
        /// <summary>
        /// get updated seat details and update the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleServiceCallbackEvent(object sender, SeatDetailsListEventArgs e)
        {
            List<SeatDetails> seatDetailsList = e.SeatDetailsList;
            if (seatDetailsList != null && seatDetailsList.Count > 0)
            {

                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    foreach (var seatDetails in seatDetailsList)
                    {
                                SeatUIList[seatDetails.Floor][seatDetails.BlockNo][seatDetails.RowNo].Where(x => x.SeatNo == seatDetails.SeatNo).FirstOrDefault().BgColour = seatDetails.BgColour;
                                SeatUIList[seatDetails.Floor][seatDetails.BlockNo][seatDetails.RowNo].Where(x => x.SeatNo == seatDetails.SeatNo).FirstOrDefault().IsEditable = false;
                                MakeBooking(seatDetails);//update database

                        CollectionViewSource.GetDefaultView(SeatUIList).Refresh();//refresh the view
                    }

                });

            }
        }

        #endregion

        #region Database actions

        /// <summary>
        /// update the local database based on other clients
        /// </summary>
        /// <param name="seatDetails"></param>
        private void MakeBooking(SeatDetails seatDetails)
        {
            try
            {
                _ticketBookingDataAccessService.AddBooking(seatDetails);
            }
            catch (Exception ex)
            {
                Status = ex.Message;
                IsWarning = true;
            }
        }
        #endregion


   

        #endregion


        #region helper methods

        public override void Cleanup()
        {
            base.Cleanup();
            ViewModelLocator.Cleanup();

            if (ViewModelLocator.Main.Proxy != null)
            {
                try
                {
                    ViewModelLocator.Main.Proxy.Disconnect();
                    ViewModelLocator.Main.Proxy.Close();
                }
                catch
                {
                    ViewModelLocator.Main.Proxy.Abort();
                }
            }
        }

        #endregion

    }
}
