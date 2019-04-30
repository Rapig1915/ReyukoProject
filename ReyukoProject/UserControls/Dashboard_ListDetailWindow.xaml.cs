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

namespace ReyukoProject.UserControls
{
    public sealed partial class Dashboard_ListDetailWindow : UserControl
    {
        public async static void ListItemDetail(string str, string strContent)
        {
            var detail = new Dashboard_ListDetailWindow(str, strContent);
            ContentDialog dlg = new ContentDialog();

            dlg.PrimaryButtonText = "OK";
            dlg.PrimaryButtonClick += Dlg_PrimaryButtonClick;

            dlg.Content = detail;
            await dlg.ShowAsync();

        }

        public Dashboard_ListDetailWindow(string strTitle, string strContent)
        {
            this.InitializeComponent();

            title.Text = strTitle;
            txtContent.Text = strContent;

        }
        public static void Dlg_PrimaryButtonClick(ContentDialog dlg, ContentDialogButtonClickEventArgs ee)
        {
            dlg.Hide();
        }
    }
}
