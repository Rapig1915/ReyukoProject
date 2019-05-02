using Windows.UI.Xaml.Controls;
using ReyukoProject.Pages.Dashboard_Page;
using ReyukoProject.Pages.Sales_Page;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Collections.ObjectModel;
using ReyukoProject.Model;
using System;
using Windows.UI.Xaml.Input;


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
                AppFrame.Navigate(typeof(Sales_Order_List_Page));
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
                menuLst.Add(new NavigateMenuItem { Title = "Sales Proposal", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Sales Order", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Delivery Order", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Invoice", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Return", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                lvNavigationMenuSub.ItemsSource = menuLst;
                
            }
            else if(m_strMenuTitle == PurchasingMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Shopping Cart", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Request for Proposal", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Order", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchased Delivery", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Goods Receipt", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Purchase Return", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == ProductMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Product", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Service", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Measurement Unit", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Product Type", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Product Categories", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Group Product", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == InventoryMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Inventory Adjustment", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Received Consignment", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Consinment In Return", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Stock Of Name", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Location", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Production", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;

            }
            else if (m_strMenuTitle == PaymentMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Receivable & Payable", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Cash Activities", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Salary Payment", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Bank Reconciliation", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Post-Dated Cheque Issuance", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Received Post-Dated Cheque", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Installment", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == AccountingMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Ldger", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "General Journal Transaction", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Account Data", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Currency Data", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Tax Data", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Fixed Asset", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Fixed Asset Category", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Depreciation Table", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Account Budget", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Accounting Period", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Reporting", IconPath = "" });

                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == ContactMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Customer", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Vendor", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Employee", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Customer Group", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Contact Clasification", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Salary Group", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Project", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
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
                menuLst.Add(new NavigateMenuItem { Title = "Document Reference", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Document Type", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Notes", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                menuLst.Add(new NavigateMenuItem { Title = "Notes Type", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == CalendarMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "Callendar", IconPath = "/Assets/Icons/sales-proposal_drawer.png" });
                lvNavigationMenuSub.ItemsSource = menuLst;
            }
            else if (m_strMenuTitle == POSMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else if (m_strMenuTitle == ServicesMenuItemName)
            {
                pageType = typeof(Dashboard_Page);
                bSubMenuShow = false;
            }
            else if (m_strMenuTitle == SettingsMenuItemName)
            {
                var menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst = new ObservableCollection<NavigateMenuItem>();
                menuLst.Add(new NavigateMenuItem { Title = "ion", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Data Source", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Subscription", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "General", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "Role Employee", IconPath = "" });
                menuLst.Add(new NavigateMenuItem { Title = "company profile", IconPath = "" });
                lvNavigationMenuSub.ItemsSource = menuLst;
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
                else if (e.SourcePageType == typeof(Sales_Order_Detail_Page))
                {
                    NavView.SelectedItem = SalesMenuItem;
                }
                /*else if (e.SourcePageType == typeof(SettingsPage))
                {
                    NavView.SelectedItem = NavView.SettingsItem;
                }*/
            }
        }
        private void LvNavigationMenuSub_ItemClick(object sender, PointerRoutedEventArgs e)//object sender, ItemClickEventArgs e)
        {
            /*var model = (NavigateMenuItem)e.ClickedItem;
            if (model == null)
                return;
            string menuTitle = model.Title;

            // To do
            if (m_strMenuTitle == SalesItemName)
            {

                if (menuTitle == "Production")
                    AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                else if (menuTitle == "Invoice")
                    AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                else if (menuTitle == "Document")
                    AppFrame.Navigate(typeof(Sales_Order_List_Page));
                else if (menuTitle == "Delivery Order")
                    AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                else if (menuTitle == "Return")
                    AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
            }
            else if (m_strMenuTitle == DocumentMenuItemName)
            {

            }
            SubMenuSplitView.IsPaneOpen = false;*/
        }



        private void On_NewItemPressed(object sender, PointerRoutedEventArgs e)
        {
            int i;


            if (sender.GetType() == typeof(TextBlock))
            {
                TextBlock txt = sender as TextBlock;
                string menuTitle = txt.Text;

                // To do
                if (m_strMenuTitle == SalesItemName)
                {

                    if (menuTitle == "Production")
                        AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                    else if (menuTitle == "Invoice")
                        AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                    else if (menuTitle == "Document")
                        AppFrame.Navigate(typeof(Sales_Order_List_Page));
                    else if (menuTitle == "Delivery Order")
                        AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                    else if (menuTitle == "Return")
                        AppFrame.Navigate(typeof(Sales_Order_Detail_Page));
                }
                else if (m_strMenuTitle == DocumentMenuItemName)
                {

                }
                SubMenuSplitView.IsPaneOpen = false;
            }
            else if (sender.GetType() == typeof(Image))
            {
                Image menuItem = sender as Image;
                if(menuItem.Source != null)
                {
                    string subMenu = menuItem.Tag.ToString();
                    if (subMenu == "Production")
                    {
                        AppFrame.Navigate(typeof(Sales_Order_List_Page));
                    }
                }
                
                SubMenuSplitView.IsPaneOpen = false;
            }
        }
    }
}
