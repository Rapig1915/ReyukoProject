using Microsoft.Toolkit.Uwp.UI.Controls;
using ReyukoProject.Model;
using ReyukoProject.Model.ViewModels;
using ReyukoProject.Views;
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

namespace ReyukoProject.Pages.Sales_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Sales_Invoice_New : Page
    {
        public Sales_Invoice_New()
        {
            this.InitializeComponent();
        }
        /// <summary>
        /// Used to bind the UI to the data.
        /// </summary>
        public CustomerViewModel ViewModel { get; set; }

        /// <summary>
        /// Navigate to the previous page when the user cancels the creation of a new customer record.
        /// </summary>
        private void AddNewCustomerCanceled(object sender, EventArgs e) => Frame.GoBack();

        /// <summary>
        /// Displays the selected customer data.
        /// </summary>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter == null)
            {
                ViewModel = new CustomerViewModel
                {
                    IsNewCustomer = true,
                    IsInEdit = true
                };
            }
            else
            {
                ViewModel = App.ViewModel.Customers.Where(
                    customer => customer.Model.Id == (Guid)e.Parameter).First();
            }

            ViewModel.AddNewCustomerCanceled += AddNewCustomerCanceled;
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Check whether there are unsaved changes and warn the user.
        /// </summary>
        protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            if (ViewModel.IsModified)
            {
                // Cancel the navigation immediately, otherwise it will continue at the await call. 
                e.Cancel = true;

                void resumeNavigation()
                {
                    if (e.NavigationMode == NavigationMode.Back)
                    {
                        Frame.GoBack();
                    }
                    else
                    {
                        Frame.Navigate(e.SourcePageType, e.Parameter, e.NavigationTransitionInfo);
                    }
                }

                var saveDialog = new SaveChangesDialog() { Title = $"Save changes?" };
                await saveDialog.ShowAsync();
                SaveChangesDialogResult result = saveDialog.Result;

                switch (result)
                {
                    case SaveChangesDialogResult.Save:
                        await ViewModel.SaveAsync();
                        resumeNavigation();
                        break;
                    case SaveChangesDialogResult.DontSave:
                        await ViewModel.RevertChangesAsync();
                        resumeNavigation();
                        break;
                    case SaveChangesDialogResult.Cancel:
                        break;
                }
            }

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// Disconnects the AddNewCustomerCanceled event handler from the ViewModel 
        /// when the parent frame navigates to a different page.
        /// </summary>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            ViewModel.AddNewCustomerCanceled -= AddNewCustomerCanceled;
            base.OnNavigatedFrom(e);
        }

        /// <summary>
        /// Initializes the AutoSuggestBox portion of the search box.
        /// </summary>
        private void CustomerSearchBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is UserControls.CollapsibleSearchBox searchBox)
            {
                searchBox.AutoSuggestBox.QuerySubmitted += CustomerSearchBox_QuerySubmitted;
                searchBox.AutoSuggestBox.TextChanged += CustomerSearchBox_TextChanged;
                searchBox.AutoSuggestBox.PlaceholderText = "Search customers...";
            }
        }

        /// <summary>
        /// Queries the database for a customer result matching the search text entered.
        /// </summary>
        private async void CustomerSearchBox_TextChanged(AutoSuggestBox sender,
            AutoSuggestBoxTextChangedEventArgs args)
        {
            // We only want to get results when it was a user typing,
            // otherwise we assume the value got filled in by TextMemberPath
            // or the handler for SuggestionChosen
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                // If no search query is entered, refresh the complete list.
                if (string.IsNullOrEmpty(sender.Text))
                {
                    sender.ItemsSource = null;
                }
                else
                {
                    try
                    {
                        sender.ItemsSource = await App.Repository.Customers.GetAsync(sender.Text);
                    }
                    catch (Exception) { }
                    
                }
            }
        }

        /// <summary>
        /// Search by customer name, email, or phone number, then display results.
        /// </summary>
        private void CustomerSearchBox_QuerySubmitted(AutoSuggestBox sender,
            AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion is SalesOrder customer)
            {
                Frame.Navigate(typeof(CustomerDetailPage), customer.Id);
            }
        }

        /// <summary>
        /// Adjust the command bar button label positions for optimimum viewing.
        /// </summary>
        private void CommandBar_Loaded(object sender, RoutedEventArgs e)
        {
            if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Bottom;
            }
            else
            {
                (sender as CommandBar).DefaultLabelPosition = CommandBarDefaultLabelPosition.Right;
            }

            // Disable dynamic overflow on this page. There are only a few commands, and it causes
            // layout problems when save and cancel commands are shown and hidden.
            (sender as CommandBar).IsDynamicOverflowEnabled = false;
        }

        /// <summary>
        /// Navigates to the order page for the customer.
        /// </summary>
        private void ViewOrderButton_Click(object sender, RoutedEventArgs e)
        {
            /*
             =>
            Frame.Navigate(typeof(OrderDetailPage), ((sender as FrameworkElement).DataContext as Order).Id,
                new DrillInNavigationTransitionInfo());
            */
        }


        /// <summary>
        /// Adds a new order for the customer.
        /// </summary>
        private void AddOrder_Click(object sender, RoutedEventArgs e)
        {
            /*
            =>
            Frame.Navigate(typeof(OrderDetailPage), ViewModel.Model.Id);
             */
        }


        /// <summary>
        /// Sorts the data in the DataGrid.
        /// </summary>
        private void DataGrid_Sorting(object sender, DataGridColumnEventArgs e)
        {
            /*
             =>
            (sender as DataGrid).Sort(e.Column, ViewModel.Orders.Sort); 
             */
        }

    }
}
