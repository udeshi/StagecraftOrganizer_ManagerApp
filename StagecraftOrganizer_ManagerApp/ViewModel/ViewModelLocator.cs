/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:StagecraftOrganizer_ManagerApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.ServiceLocation;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterface;
using StagecraftOrganizer_ManagerApp.Services.ServiceInterfaceImpl;

namespace StagecraftOrganizer_ManagerApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<IUserDataAccessService, UserDataAccessService>();
            SimpleIoc.Default.Register<IAuthenticationService, AuthenticationService>();
            SimpleIoc.Default.Register<IValidationService, ValidationService>();
            SimpleIoc.Default.Register<ISeatingService, SeatingService>();
            SimpleIoc.Default.Register<IDialogCoordinator, DialogCoordinator>();
            SimpleIoc.Default.Register<ITicketDataAccessService, TicketDataAccessService>();
            SimpleIoc.Default.Register<ITicketBookingDataAccessService, TicketBookingDataAccessService>();
            SimpleIoc.Default.Register<ITicketTypeDataAccessService, TicketTypeDataAccessService>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ManageSeatingViewModel>();
            SimpleIoc.Default.Register<NotificationMessageViewModel>(true);
            SimpleIoc.Default.Register<DialogViewModel>();
        }

        public static MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static ManageSeatingViewModel ManageSeating
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ManageSeatingViewModel>();
            }
        }

        public static NotificationMessageViewModel ManageNotificationMessages
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NotificationMessageViewModel>();
            }
        }

        //public DialogViewModel Dialog
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<DialogViewModel>();
        //    }
        //}
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}