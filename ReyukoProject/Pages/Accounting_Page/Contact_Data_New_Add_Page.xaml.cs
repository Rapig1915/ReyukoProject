using ReyukoProject.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
    public sealed partial class Contact_Data_New_Add_Page : UserControl
    {
        private ContentDialog m_parent;
        public Contact_Data_New_Add_Page(string str, ContentDialog parent)
        {
            this.InitializeComponent();
            txtCurrency.Text = str;
            m_parent = parent;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Hide();
        }

        private async System.Threading.Tasks.Task showMessageBoxAsync()
        {
            var dialog = new MessageDialog("Could not be empty");
            await dialog.ShowAsync();
        }
        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            if(txtRate.Text.Length == 0)
            {
                showMessageBoxAsync();
                return;
            }
            DBEngine.AddCurrencyRating(txtCurrency.Text, txtDate.Date.ToString(), txtRate.Text);
            m_parent.Hide();
        }

        public async static void ShowPopup(string str)
        {
            ContentDialog dlg = new ContentDialog();
            var detail = new Contact_Data_New_Add_Page(str, dlg);

            dlg.Content = detail;
            await dlg.ShowAsync();
        }
    }
}
