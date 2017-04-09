using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StagecraftOrganizer_ManagerApp.ViewModel
{
    public class DialogViewModel : ViewModelBase
    {
        #region private variables
        private ICommand _confirmCommand; //represnts the confirm logout buttn click
        private ICommand _cancelConfirmationCommand; //represnts the cancel logout click
        private RelayCommand _initializeCommand;
        private String _affirmativeButtonText;
        private String _negativeButtonText;
        private String _messageContent;
        private String _warningMessageContent;
        #endregion
        /// <summary>
        /// Initializes a new instance of the DialogViewModel class.
        /// </summary>
        public DialogViewModel()
        {
            InitializeCommand = new RelayCommand(initializeView);
        }
        #region ICommands
        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand<Boolean>(m => confirmCommandAction(true));
                }
                return _confirmCommand;
            }
        }
        public ICommand CancelConfirmationCommand
        {
            get
            {
                if (_cancelConfirmationCommand == null)
                {
                    _cancelConfirmationCommand = new RelayCommand<Boolean>(m => confirmCommandAction(false));
                }
                return _cancelConfirmationCommand;
            }
        }

        public String AffirmativeButtonText
        {
            get
            {
                return _affirmativeButtonText;
            }

            set
            {
                _affirmativeButtonText = value;
                RaisePropertyChanged("AffirmativeButtonText");
            }
        }

        public String NegativeButtonText
        {
            get
            {
                return _negativeButtonText;
            }

            set
            {
                _negativeButtonText = value;
                RaisePropertyChanged("NegativeButtonText");
            }
        }

        public String MessageContent
        {
            get
            {
                return _messageContent;
            }

            set
            {
                _messageContent = value;
                RaisePropertyChanged("MessageString");
            }
        }

        public String WarninMessageContent
        {
            get
            {
                return _warningMessageContent;
            }

            set
            {
                _warningMessageContent = value;
                RaisePropertyChanged("WarningText");
            }
        }

        public RelayCommand InitializeCommand
        {
            get
            {
                return _initializeCommand;
            }

            set
            {
                _initializeCommand = value;
            }
        }
        #endregion


        private void initializeView()
        {
            RaisePropertyChanged("MessageString");
        }


        #region messanger
        private void confirmCommandAction(Boolean isConfirmed)
        {
            var messageToNotify = isConfirmed ? "Confirmed" : "Canceled";
            Messenger.Default.Send(messageToNotify);//send the message to mainviewmodel about the selected option
        }
        #endregion

        #region helper methods

        public override void Cleanup()
        {
            base.Cleanup();
            ViewModelLocator.Cleanup();
        }

        #endregion
    }
}