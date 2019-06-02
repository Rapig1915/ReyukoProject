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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ReyukoProject.Pages.Accounting_Page
{
    public sealed partial class Contact_Data_New_Page : UserControl
    {
        public MainViewModel ViewModel => App.ViewModel;
        private ContentDialog m_parent;

        public async static void ShowPopup(string str)
        {
            ContentDialog dlg = new ContentDialog();
            var detail = new Contact_Data_New_Page(str, dlg);
            
            dlg.Content = detail;
            await dlg.ShowAsync();

        }


        public Contact_Data_New_Page(string strTitle, ContentDialog parent)
        {
            this.InitializeComponent();
            m_parent = parent;
        }



        public void Cancel_Clicked(object sender, RoutedEventArgs e)
        {
            m_parent.Hide();
        }

        private void Add_Clicked(object sender, RoutedEventArgs e)
        {
            CurrencyViewModel selectedCurrency = listview.SelectedItem as CurrencyViewModel;
            if (selectedCurrency == null)
                return;
            m_parent.Hide();
            
            string strCurrency = selectedCurrency.Name;
            ShowAddPopup(strCurrency);
        }
        private async System.Threading.Tasks.Task ShowAddPopup(string currencyName)
        {
            Contact_Data_New_Add_Page.ShowPopup(currencyName);
        }
    }
}
