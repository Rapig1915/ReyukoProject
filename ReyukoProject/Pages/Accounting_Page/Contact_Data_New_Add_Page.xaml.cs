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
    public sealed partial class Contact_Data_New_Add_Page : UserControl
    {
        private ContentDialog m_parent;
        public Contact_Data_New_Add_Page(string str, ContentDialog parent)
        {
            this.InitializeComponent();
            m_parent = parent;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            m_parent.Hide();
        }

        private void Save_Clicked(object sender, RoutedEventArgs e)
        {
            m_parent.Hide();
        }

        public async static void ShowPopup(string str)
        {


        }
    }
}
