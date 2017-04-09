using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.ServiceModel;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using StagecraftOrganizer_ManagerApp.Model;
using StagecraftOrganizer_ManagerApp.Helper;
using StagecraftOrganizer_ManagerApp.Model.Enums;
using StagecraftOrganizer_ManagerApp.Services.WCFServiceImpl;
using StagecraftOrganizer_ManagerApp.Model.UIModel;
using StagecraftOrganizer_ManagerApp.StagecraftOrganizingService;
using StagecraftOrganizer_ManagerApp.Model.Constants;
using StagecraftOrganizer_ManagerApp.Model.EventAgrs;

namespace StagecraftOrganizer_ManagerApp.ViewModel
{
        /// <summary>
        /// This class contains properties that the main View can data bind to.
        /// <para>
        /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
        /// </para>
        /// <para>
        /// You can also use Blend to data bind with the tool's support.
        /// </para>
        /// <para>
        /// See http://www.galasoft.ch/mvvm
        /// </para>
        /// </summary>
        public class MainViewModel : ViewModelBase
        {
            #region private variables
            public RelayCommand<String> NavigateCommand { get; private set; } // delegate use to navigate between views

            //reprsents commands given from the view
            private ICommand _openLoginLayoutCommand;// represents to open the login flyout
            private ICommand _loginCommand;//represents the login submit command
            private ICommand _cancelCommand;//represents the login cancel command
            private ICommand _changePasswordCommand;//represents the change password command
            private ICommand _signUpNavCommand;//represents the direct to signup fly out command
            private ICommand _signUpCommand;//represents the signup command
            private ICommand _logOutCommand;//represents the logout command
            private ICommand _logOutCancelCommand;//represents the logout cancel command
            private ICommand _confirmCommand;
            private ICommand _cancelConfirmationCommand;
            private ICommand _closeWindowCommand;
            private Services.WCFServiceImpl.StagecraftOrganizingServiceClient _proxy;
            private String _currentUser;//represent the value of current logged in users's username
            private String _password;//represent the value of password textbox
            private String _confirmPassword;//represent the value of confirm password textbox
            private String _email;//represent the value of email textbox
            private String[] _userRoles;//represents a list of user roles
            private List<SeatDetails> _selectedSeatDetails;

            //represents visibility of fly outs
            private Boolean _loginFlyoutIsVisible;
            private Boolean _logoutFlyoutIsVisible;
            private Boolean _signUpFlyoutIsVisible;

            //represents visibility of information
            private Visibility _warningVisibility;// visibility of error messages of flyouts 
            private Visibility _adminVisibility;

            private ViewModelBase _currentViewModel;//reference to base class of view model


            private String _status;//represents errors of authentication 
            private Boolean _isWarning;// represnts there is a warinig or not to display warnings dynamially
            private String _title;//represents the title of each window

            private Boolean _isValid;// to disable or enable buttons based on the fields in login and sign up
            private String _dialogResult;// get the message from dialog box

            //references to services
            private readonly IUserDataAccessService _userDataAccessService;//user dats service
            private readonly IValidationService _validationService;//validation service
            private readonly IAuthenticationService _authenticationService;//authentication service
            private readonly IDialogCoordinator _dialogCoordinator;
           

        private readonly Dictionary<String, ICollection<CustomErrorType>>
                _validationErrors = new Dictionary<String, ICollection<CustomErrorType>>();//represents a collection of errors
            #endregion

            //constructor
            public MainViewModel(IUserDataAccessService userDataAccessService, IAuthenticationService authenticationService, IDialogCoordinator dialogCoordinator, IValidationService validationService)
        {
            NavigateCommand = new RelayCommand<String>(NavigateCommandAction);//initialize the delegate

            LoginFlyoutIsVisible = false;
            LogoutFlyoutIsVisible = false;
            IsWarning = false;
            AdminVisibility = Visibility.Hidden;
            _userDataAccessService = userDataAccessService;
            _authenticationService = authenticationService;
            _dialogCoordinator = dialogCoordinator;
            _validationService = validationService;
            
            MessengerInstance.Register<GenericMessage<String>>(this, NotifyLogOut);
            InitializeClient();
       
      
        }

        #region ICommand
        public ICommand OpenLoginLayoutCommand
        {
            get
            {
                if (_openLoginLayoutCommand == null)
                {
                    _openLoginLayoutCommand = new RelayCommand(ManageView);
                }
                return _openLoginLayoutCommand;
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    if (HasErrors)
                    {
                        IsValid = false;
                    }
                    else {
                        _loginCommand = new RelayCommand(LoginUser);
                    }

                }
                return _loginCommand;
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null)
                {
                    _cancelCommand = new RelayCommand(CancelLogin);
                }
                return _cancelCommand;
            }
        }

        public ICommand ChangePasswordCommand
        {
            get
            {
                if (_changePasswordCommand == null)
                {
                    _changePasswordCommand = new RelayCommand(ChangePassword);
                }
                return _changePasswordCommand;
            }
        }

        public ICommand LogOutCommand
        {
            get
            {
                if (_logOutCommand == null)
                {
                    _logOutCommand = new RelayCommand(Logout);
                }
                return _logOutCommand;
            }
        }

        public ICommand LogOutCancelCommand
        {
            get
            {
                if (_logOutCancelCommand == null)
                {
                    _logOutCancelCommand = new RelayCommand(() => LogoutFlyoutIsVisible = false);
                }
                return _logOutCancelCommand;
            }
        }
        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null)
                {
                    _confirmCommand = new RelayCommand(Logout);
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
                    _cancelConfirmationCommand = new RelayCommand(CloseMessageDialog);
                }
                return _cancelConfirmationCommand;
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                if (_closeWindowCommand == null)
                {
                    _closeWindowCommand = new RelayCommand(CloseWindowCommandAction);
                }
                return _closeWindowCommand;
            }
        }

        public ICommand SignUpNavCommand
        {
            get
            {
                if (_signUpNavCommand == null)
                {
                    _signUpNavCommand = new RelayCommand(OnSignUpNavigation);
                }
                return _signUpNavCommand;
            }
        }
        public ICommand SignUpCommand
        {
            get
            {
                if (_signUpCommand == null)
                {
                    _signUpCommand = new RelayCommand(RegisterUser);
                }
                return _signUpCommand;
            }
        }

        #endregion

        #region Properties
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { Set(ref _currentViewModel, value); }
        }

        public String Title
        {

            get
            {
                return _title;
            }
            set
            {
                if (value != _title)
                {
                    _title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }

        public String Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
                ValidatePassword(_password);
                if (LoginFlyoutIsVisible == true) { EnableLogin(); }
                RaisePropertyChanged("Password");
            }
        }

        public String Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
                ValidateEmail(_email);
                if (LoginFlyoutIsVisible == true) { EnableLogin(); }
                RaisePropertyChanged("Email");
            }

        }

        public Boolean LoginFlyoutIsVisible
        {
            get
            {
                return _loginFlyoutIsVisible;
            }

            set
            {
                _loginFlyoutIsVisible = value;
                RaisePropertyChanged("LoginFlyoutIsVisible");
            }
        }


        public Boolean SignUpFlyoutIsVisible
        {
            get
            {
                return _signUpFlyoutIsVisible;
            }

            set
            {
                _signUpFlyoutIsVisible = value;
                RaisePropertyChanged("SignUpFlyoutIsVisible");
            }
        }

        public String CurrentUser
        {
            get
            {
                return _currentUser;
            }

            set
            {
                _currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }


        public String ConfirmPassword
        {
            get
            {
                return _confirmPassword;
            }

            set
            {
                _confirmPassword = value;
                ValidateConfirmPassword(_confirmPassword);
                if (SignUpFlyoutIsVisible == true) { EnableSignup(); }
                RaisePropertyChanged("ConfirmPassword");
            }
        }

        public Boolean LogoutFlyoutIsVisible
        {
            get
            {
                return _logoutFlyoutIsVisible;
            }

            set
            {
                _logoutFlyoutIsVisible = value;
                RaisePropertyChanged("LogoutFlyoutIsVisible");
            }
        }


        public String Status
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

        public Boolean IsWarning
        {
            get
            {
                return _isWarning;
            }

            set
            {
                _isWarning = value;
                RaisePropertyChanged("IsWarning");
                if (IsWarning)
                {
                    WarningVisibility = Visibility.Visible;
                }
                else
                {
                    WarningVisibility = Visibility.Hidden;

                }
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


        public Boolean IsValid
        {
            get
            {
                return _isValid;
            }

            set
            {

                _isValid = value;
                RaisePropertyChanged("IsValid");
            }
        }
        public String DialogResult
        {
            get { return _dialogResult; }
            set
            {
                if (_dialogResult == value)
                {
                    return;
                }
                _dialogResult = value;
                RaisePropertyChanged("DialogResult");
            }
        }
        public String[] UserRoles
        {
            get
            {
                return _userRoles;
            }

            set
            {
                _userRoles = value;
                RaisePropertyChanged("UserRoles");
            }
        }

        public Boolean IsAuthenticated
        {
            get { return App.Current.Properties["currentUserId"] != null ? true : false; }
        }

        public List<SeatDetails> SelectedSeatDetails
        {
            get
            {
                return _selectedSeatDetails;
            }

            set
            {
                _selectedSeatDetails = value;
                RaiseErrorsChanged("SelectedSeatDetails");
            }
        }

        public Visibility AdminVisibility
        {
            get
            {
                return _adminVisibility;
            }

            set
            {
                _adminVisibility = value;
                RaiseErrorsChanged("AdminVisibility");
            }
        }
        internal Services.WCFServiceImpl.StagecraftOrganizingServiceClient Proxy
        {
            get
            {
                return _proxy;
            }

            set
            {
                _proxy = value;
                RaisePropertyChanged("Proxy");
            }
        }

#endregion

        #region methods

        //method that facilitates navigation between views using viewModelLocator
        private void NavigateCommandAction(String destination)
        {
            switch (destination)
            {
                case "manageSeatBooking":
                    Title = Properties.Resources.ManageSeatBookingTitle;
                    CurrentViewModel = ViewModelLocator.ManageSeating;
                    base.MessengerInstance.Send<NotificationMessage>(new NotificationMessage("initialize"));
                    break;
                case "manageNotificationMessages":
                    Title = Properties.Resources.ManageSeatBookingHistoryTitle;
                    if (IsAuthenticated)// if user is not authenticated direct the user to login 
                    {

                        base.MessengerInstance.Send<NotificationMessage>(new NotificationMessage("initialize"));
                        CurrentViewModel = ViewModelLocator.ManageNotificationMessages;
                    }
                    else
                    {
                        IsWarning = true;
                        Status = Properties.Resources.LoginWarning;
                        LoginFlyoutIsVisible = true;
                    }

                    break;

                default:
                    Title = Properties.Resources.ManageSeatBookingTitle;
                    CurrentViewModel = ViewModelLocator.ManageSeating;
                    break;
            }
        }

        //when directing form login page to sign up page this method is executed
        private void OnRegisterUserNavigation()
        {
            LoginFlyoutIsVisible = false;
            LoginFlyoutIsVisible = false;
        }

        //when directing form login page to sign up page this method is executed
        private void OnSignUpNavigation()
        {
            Password = String.Empty;
            ConfirmPassword = String.Empty;
            Email = String.Empty;
            IsWarning = false;
            LoginFlyoutIsVisible = false;
            LoginFlyoutIsVisible = false;
            this.SignUpFlyoutIsVisible = true;
        }
        /// <summary>
        ///  executes when user clicks logout button
        /// </summary>
        private void Logout()
        {

            if (App.Current.Properties["currentUserId"] != null)
            {
                var userId = Int32.Parse(App.Current.Properties["currentUserId"].ToString());

                App.Current.Properties["currentUserId"] = null;
                RaisePropertyChanged("IsAuthenticated");
                Status = String.Empty;
            }


            LogoutFlyoutIsVisible = false;
            CurrentUser = null;
            NavigateCommandAction("manageSeatBooking");
        }

        /// <summary>
        ///  mange visibility of flyouts
        /// </summary>
        private async void ManageView()
        {
            if (IsAuthenticated)
            {
                LogoutFlyoutIsVisible = true;
            }
            else
            {
                IsWarning = false;
                LoginFlyoutIsVisible = true;

            }
        }

        /// <summary>
        ///  executes when user needs to change the password
        /// </summary>
        private void ChangePassword()
        {

        }

        //execute when user cancel login
        private void CancelLogin()
        {
            if (SignUpFlyoutIsVisible)
            {
                this.SignUpFlyoutIsVisible = false;
                Password = String.Empty;
                ConfirmPassword = String.Empty;
                Email = String.Empty;
                IsWarning = false;
            }
            if (LoginFlyoutIsVisible)
            {
                IsWarning = false;
                this.LoginFlyoutIsVisible = false;
                Email = String.Empty;
                Password = String.Empty;
                IsWarning = false;
            }

        }

        /// <summary>
        /// execute when user submits login details
        /// </summary>
        private void LoginUser()
        {
            try
            {

                //Validate credentials through the authentication service
                User user = _authenticationService.authenticateUser(Email, Password);


                //Authenticate the user
                App.Current.Properties["currentUserId"] = user.UserId;

                //Update UI
                RaisePropertyChanged("IsAuthenticated");

                CurrentUser = UserDetailsHelper.getUserName(user.Email);//set logged in user's username

                Status = String.Empty;
                if (IsWarning)
                {
                    IsWarning = false;
                }
                NavigateCommandAction("manageNotificationMessages");
                this.LoginFlyoutIsVisible = false;
                Password = String.Empty; //reset
                Email = String.Empty; //reset
                IsWarning = false;
            }
            catch (UnauthorizedAccessException)
            {
                IsWarning = true;
                Status = Properties.Resources.UnAuthorizedAccess;
            }
            catch (Exception ex)
            {
                IsWarning = true;
                Status = String.Format("ERROR: {0}", ex.Message);
            }
        }

        /// <summary>
        ///   execute when user submits user details to get registered
        /// </summary>
        private void RegisterUser()
        {
            User userDetails = new User();
            userDetails.Email = Email;
            if (!HasErrors)
            {
                userDetails.Password = PasswordHash.HashPassword(Password);
                try
                {
                    Int32 userId = _userDataAccessService.createUser(userDetails);
                    if (userId > 0)
                    {
                        CurrentUser = UserDetailsHelper.getUserName(Email);
                        App.Current.Properties["currentUserId"] = userId;
                        RaisePropertyChanged("IsAuthenticated");
                        NavigateCommandAction("challengeSelector");
                        this.SignUpFlyoutIsVisible = false;
                        Password = String.Empty;
                        ConfirmPassword = String.Empty;
                        Email = String.Empty;
                        IsWarning = false;
                    }

                }
                catch (Exception ex)
                {
                    IsWarning = true;
                    Status = String.Format("ERROR: {0}", ex.Message);
                }
            }
        }

        /// <summary>
        ///    represents function that can be executed after dialog is closed
        /// </summary>
        private void CloseMessageDialog()
        {

        }
        private void InitializeClient()
            {
                if (Proxy != null)
                {
                    try
                    {
                        Proxy.Close();
                    }
                    catch
                    {
                        Proxy.Abort();
                    }
                    finally
                    {
                        Proxy = null;
                    }
                }

                var stagecraftOrganizingCallback = new StagecraftOrganizingCallbackService();
            stagecraftOrganizingCallback.NotifyToGetUpdatedSeatingListCallbackEvent +=HandleUpdatedSeatList;
            
            stagecraftOrganizingCallback.UpdatedListServiceCallbackEvent += ViewModelLocator.ManageSeating.HandleServiceCallbackEvent;


                //stagecraftOrganizingCallback.UpdatedListServiceCallbackEvent += ViewModelLocator.ManageSeating.HandleDeleteSeatReseravtionServiceCallbackEvent;
                var instanceContext = new InstanceContext(stagecraftOrganizingCallback);
                //var dualHttpBinding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                //var endpointAddress = new EndpointAddress(ServiceEndpointUri);
                Proxy = new Services.WCFServiceImpl.StagecraftOrganizingServiceClient(instanceContext);
            Proxy.Open();
            Proxy.Connect();
            }



       

        public void NotifyLogOut(GenericMessage<String> genericMessage)
        {
            if (genericMessage.Content.Equals("logout"))
            {
                Logout();
            }

        }

        private void CloseWindowCommandAction()
        {
            Proxy.Close();
            //Int32 userId = 0;
            //if (App.Current.Properties["currentUserId"] != null)
            //{
            //    Int32.TryParse(App.Current.Properties["currentUserId"].ToString(), out userId);
            //    if (userId > 0)
            //    {
            //        if (ViewModelLocator.ManageSeating.IssueStatus != IssueStatus.PAID)
            //        {
            //            List<SeatDetails> detailsList = ViewModelLocator.ManageSeating.SessionSelectedSeatDetails;
            //            if (detailsList != null)
            //            {
            //                Application.Current.Dispatcher.InvokeAsync(() =>
            //                {
            //                    foreach (var details in detailsList)
            //                    {
            //                        if (details.BgColour == Constants.reservedSeatColour)
            //                        {
            //                            Proxy.DeleteBookedSeat(details);
            //                        }
            //                    }
            //                });
            //            }

            //        }

            //    }
            //}

        }
        #endregion

        public void HandleUpdatedSeatList(object sender, UserSeatDetailsListEventArgs e)
        {
           
                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                   

                });

        }


        #region Validations
        //validate the confirm password
        private void ValidateConfirmPassword(String inputValue)
        {
            const String propertyKey = "ConfirmPassword";
            ICollection<CustomErrorType> validationErrors = null;
            /* Call service synchronously */
            Boolean isValid = _validationService.validateConfirmPassword(inputValue, Password, out validationErrors);

            if (!isValid)
            {
                /* Update the collection in the dictionary returned by the GetErrors method */
                _validationErrors[propertyKey] = validationErrors;
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                GetErrors(propertyKey);
            }
            else if (_validationErrors.ContainsKey(propertyKey))
            {
                /* Remove all errors for this property */
                _validationErrors.Remove(propertyKey);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                WarningVisibility = Visibility.Hidden;
            }
        }
        //validate the password
        private void ValidatePassword(String inputValue)
        {
            const String propertyKey = "Password";
            ICollection<CustomErrorType> validationErrors = null;
            /* Call service synchronously */
            Boolean isValid = _validationService.validatePassword(inputValue, out validationErrors);

            if (!isValid)
            {
                /* Update the collection in the dictionary returned by the GetErrors method */
                _validationErrors[propertyKey] = validationErrors;
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                GetErrors(propertyKey);
            }
            else if (_validationErrors.ContainsKey(propertyKey))
            {
                /* Remove all errors for this property */
                _validationErrors.Remove(propertyKey);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                WarningVisibility = Visibility.Hidden;
            }
        }

        //validate the email
        private void ValidateEmail(String inputValue)
        {
            const String propertyKey = "Email";
            ICollection<CustomErrorType> validationErrors = null;
            Boolean isValid = false;
            /* Call service synchronously */
            if (LoginFlyoutIsVisible)
            {
                isValid = _validationService.validateCurrentUser(inputValue, out validationErrors);
            }
            else
            {
                isValid = _validationService.validateNewUser(inputValue, out validationErrors);
            }

            if (!isValid)
            {
                /* Update the collection in the dictionary returned by the GetErrors method */
                _validationErrors[propertyKey] = validationErrors;
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                GetErrors(propertyKey);
            }
            else if (_validationErrors.ContainsKey(propertyKey))
            {
                /* Remove all errors for this property */
                _validationErrors.Remove(propertyKey);
                /* Raise event to tell WPF to execute the GetErrors method */
                RaiseErrorsChanged(propertyKey);
                WarningVisibility = Visibility.Hidden;
            }
        }

        //get errors for login 
        private void GetErrors(String propertyKey)
        {
            WarningVisibility = Visibility.Visible;
            String _endString = _validationErrors[propertyKey].Count == 1 ? "\n" : "";
            foreach (var error in _validationErrors[propertyKey])
            {
                Status = error.ValidationMessage + _endString;
            }
        }
        #endregion

        //based on property changes enable the login button
        private void EnableLogin()
        {
            if ((Password != null && Password != String.Empty) && (Email != null && Email != String.Empty) && !HasErrors)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;

            }
        }
        //based on property changes enable the signup button
        private void EnableSignup()
        {
            if ((Password != null && Password != String.Empty) && (Email != null && Email != String.Empty) && (ConfirmPassword != null && ConfirmPassword != String.Empty) && !HasErrors)
            {
                IsValid = true;
            }
            else
            {
                IsValid = false;

            }
        }

        #region INotifyDataErrorInfo members
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(String propertyName)
        {
            if (ErrorsChanged != null)
            {
                IsValid = false;
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }

        }


        public Boolean HasErrors
        {
            get { return _validationErrors.Count > 0; }
        }

        #endregion

        #region helper methods

        public override void Cleanup()
            {
                base.Cleanup();
                ViewModelLocator.Cleanup();

                if (Proxy != null)
                {
                    try
                    {
                        Proxy.Disconnect();
                        Proxy.Close();
                    }
                    catch
                    {
                        Proxy.Abort();
                    }
                }
            }
            #endregion
        }
    }