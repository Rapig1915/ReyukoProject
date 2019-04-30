using Windows.UI.Xaml.Controls;
using ReyukoProject.Pages.Dashboard_Page;
using ReyukoProject.Pages.Sales_Page;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using ReyukoProject.Model;
using System;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ReyukoProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public Frame AppFrame => frame;
        private string m_strMenuTitle;
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
                AppFrame.Navigate(typeof(Dashboard_Page));
                NavView.SelectedItem = DashBoardMenuItem;
            };
        }
        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            StackPanel panel = args.InvokedItem as StackPanel;
            TextBlock txt = panel.Children[1] as TextBlock;
            var strName = panel.Name;
            m_strMenuTitle = txt.Text;

            bool bSubMenuShow = true;

            Type pageType = null;
            if (m_strMenuTitle == DashboardMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else if(m_strMenuTitle == SalesItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Production", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Invoice",  IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Document", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Delivery Order", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Return", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
                
            }
            else if(m_strMenuTitle == PurchasingMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Purchased Document", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Shopping Cart", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Quotation Request", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchased Order", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Delivery", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Received Goods", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Return", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == ProductMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Product", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Service", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Measurement Unit", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchased Order", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Delivery", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Received Goods", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Return", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == InventoryMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Consignment", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Inventory Adjustment", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Location", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Production", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Inventory Checking", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;

            }
            else if (m_strMenuTitle == PaymentMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Payments", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Cash Activities", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Sales Payment", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Bank Reconciliation", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Post-Dated Cheque Issuance", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Received-Dated Cheque Issuance", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "PaymentTerms", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == AccountingMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Ldger", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "General Journal", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Account Level Setting", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Currentcy Data", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Tax Data", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Fixed Asset", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Fixed Asset Category", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Depreciation Table", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Budget", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == ContactMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Customer", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Vendor", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Employee", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Group", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Contact Clasification", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Salary Group", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Project", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Department", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == ReportingMenuItemName)
            {
               
            }
            else if (m_strMenuTitle == DocumentMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Document", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Document Type", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Notes Type", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Internal Notes", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == CalendarMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else if (m_strMenuTitle == POSMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else if (m_strMenuTitle == ServicesMenuItemName)
            {
                bSubMenuShow = false;
            }
            else if (m_strMenuTitle == SettingsMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else
            {
                bSubMenuShow = false;
            }
            if(pageType != null && pageType != AppFrame.CurrentSourcePageType)
            {
                AppFrame.Navigate(pageType);
            }
            SubMenuSplitView.IsPaneOpen = bSubMenuShow;

        }
        private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (AppFrame.CanGoBack)
            {
                AppFrame.GoBack();
            }
        }

        private void OnNavigatingToPage(object sender, NavigatingCancelEventArgs e)
        {
            // To do
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (e.SourcePageType == typeof(Dashboard_Page))
                {
                    NavView.SelectedItem = DashBoardMenuItem;
                }
                else if (e.SourcePageType == typeof(Sales_Page))
                {
                    NavView.SelectedItem = SalesMenuItem;
                }
                /*else if (e.SourcePageType == typeof(SettingsPage))
                {
                    NavView.SelectedItem = NavView.SettingsItem;
                }*/
            }
        }
        private void LvNavigationMenuSub_ItemClick(object sender, ItemClickEventArgs e)
        {
            var model = (NavigateMenuItem)e.ClickedItem;
            if (model == null)
                return;
            string menuTitle = model.Title;

            // To do
            if (m_strMenuTitle == SalesItemName)
            {
                /*
                if (menuTitle == "Production")
                    ContentFrame.Navigate(typeof(Sales_Production));
                else if (menuTitle == "Invoice")
                    ContentFrame.Navigate(typeof(Sales_Invoice));
                else if (menuTitle == "Document")
                    ContentFrame.Navigate(typeof(Sales_Document));
                else if (menuTitle == "Delivery Order")
                    ContentFrame.Navigate(typeof(Sales_DeliveryOrder));
                else if (menuTitle == "Return")
                    ContentFrame.Navigate(typeof(Sales_Return));*/
            }
            else if (m_strMenuTitle == DocumentMenuItemName)
            {
                /*string menuTitle = model.Title;
                if (menuTitle == "Document")
                    ContentFrame.Navigate(typeof(Sales_Production));
                else if (menuTitle == "Document Type")
                    ContentFrame.Navigate(typeof(Sales_Invoice));
                else if (menuTitle == "Document")
                    ContentFrame.Navigate(typeof(Sales_Document));
                else if (menuTitle == "Interal Notes")
                    ContentFrame.Navigate(typeof(Sales_DeliveryOrder));*/
            }
            SubMenuSplitView.IsPaneOpen = false;
        }

    }
}
