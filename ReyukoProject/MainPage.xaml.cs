using Windows.UI.Xaml.Controls;
using ReyukoProject.Pages.Dashboard_Page;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReyukoProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public Frame AppFrame { get { return this.Frame; } }

        // Properties
        public readonly string DashboardMenuItemName = "Dashboard";
        public readonly string SalesItemName = "Sales";
        public readonly string PurchasingMenuItemName = "Purchasing";
        public readonly string ProductMenuItemName = "Product";
        public readonly string InventoryMenuItemName = "Inventory";
        public readonly string PaymentMenuItemName = "Payment";
        public readonly string AccountingMenuItemName = "Accounting";
        public readonly string ContactMenuItemName = "Contact";
        public readonly string ReportingMenuItemName = "Reporting";
        public readonly string DocumentMenuItemName = "Document";
        public readonly string CalendarMenuItemName = "Calendar";
        public readonly string POSMenuItemName = "POS";
        public readonly string ServicesMenuItemName = "Services";
        public readonly string SettingsMenuItemName = "Settings";
        

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                NavView.SelectedItem = DashBoardMenuItem;
            };
        }
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            var label = args.InvokedItem as string;
            if (label == SalesItemName)
                AppFrame.Navigate(typeof(Dashboard_Page));
            
        }
            private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }
    }
}
