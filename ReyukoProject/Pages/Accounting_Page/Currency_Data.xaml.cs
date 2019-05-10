using ReyukoProject.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReyukoProject.Pages.Accounting_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Currency_Data : Page
    {
        /// <summary>
        /// Gets the app-wide ViewModel instance.
        /// </summary>
        public MainViewModel ViewModel => App.ViewModel;

        public Currency_Data()
        {
            this.InitializeComponent();

        }
      
        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void New_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
            //Frame.Navigate(typeof(Currency_Data_New_Page), null, new Currency_Data_New_Page());
            NewDialogAsync();
        }
        private async System.Threading.Tasks.Task NewDialogAsync()
        {
            Contact_Data_New_Page.ShowPopup("Your content here");
        }
     
        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void Edit_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }

        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void Refresh_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }

        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void Sat_as_default_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }

        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void Setting_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }

        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void DeActivate_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }

        /// <summary>
        /// Menu flyout click control for .
        /// </summary>
        private void Play_Turtoiral_Clicked(object sender, RoutedEventArgs e)
        {
            /*if (ViewModel.SelectedCustomer != null)
            {
                Frame.Navigate(typeof(CustomerDetailPage), ViewModel.SelectedCustomer.Model.Id,
                    new DrillInNavigationTransitionInfo());
            }*/
        }


    }
}
