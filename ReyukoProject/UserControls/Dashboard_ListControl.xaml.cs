using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class Dashboard_ListControl : UserControl
    {
        private List<string> m_listData;

        public event ItemClickEventHandler ListItemClickedHandler;
        // Chart Title Font Size
        public double TitleFontSize
        {
            get
            {
                return title.FontSize;
            }
            set
            {
                title.FontSize = value;
            }
        }

        // Chart Title Get/Set Property
        public string ListTitle
        {
            get
            {
                return title.Text;
            }
            set
            {
                title.Text = value;
            }
        }

        public List<string> ListData
        {
            get
            {
                return m_listData;
            }
            set
            {
                m_listData = value;
                loadData();
            }
        }
        public Color TitleColor
        {
            get { return ((SolidColorBrush)(title.Foreground)).Color; }
            set { title.Foreground = new SolidColorBrush(value); }
        }



        public Dashboard_ListControl()
        {
            this.InitializeComponent();
            TitleColor = Colors.Black;
        }

        public void loadData()
        {
            list.ItemsSource = m_listData;
        }

        private void Item_Clicked(object sender, ItemClickEventArgs e)
        {
            if (ListItemClickedHandler != null)
                ListItemClickedHandler(sender, e);
        }
    }
}
