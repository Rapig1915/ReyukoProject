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
    public class Dashboard_TableItem
    {
        public bool Selected { get; set; }
        public string Name { get; set; }
        public string Amount { get; set; }
    }
    public sealed partial class Dashboard_TableControl : UserControl
    {
        private List<Dashboard_TableItem> m_Data;
        public string Header1Text
        {
            get
            {
                return title1.Text;
            }
            set
            {
                title1.Text = value;
            }
        }
        public string Header2Text
        {
            get
            {
                return title2.Text;
            }
            set
            {
                title2.Text = value;
            }
        }
        // Chart Title Font Size
        public double TitleFontSize
        {
            get
            {
                return title1.FontSize;
            }
            set
            {
                title1.FontSize = value;
                title2.FontSize = value;
            }
        }

        // Chart Title Get/Set Property
        public string Title1
        {
            get
            {
                return title1.Text;
            }
            set
            {
                title1.Text = value;
            }
        }
        public string Title2
        {
            get
            {
                return title2.Text;
            }
            set
            {
                title2.Text = value;
            }
        }
        public Color EllipseColor
        {
            get
            {
                return ((SolidColorBrush)(ellipse.Fill)).Color;
            }
            set
            {
                ellipse.Fill = new SolidColorBrush(value);
            }
        }
        public Color HeaderBackColor
        {
            get
            {
                return ((SolidColorBrush)headerGrid.Background).Color;
            }
            set
            {
                headerGrid.Background = new SolidColorBrush(value);
            }
        }
        public List<Dashboard_TableItem> TableData
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;
                setTable();
            }
        }
        public Dashboard_TableControl()
        {
            this.InitializeComponent();
            HeaderBackColor = Color.FromArgb(255, 51, 102, 185);
            btnMore.Background = new SolidColorBrush(Color.FromArgb(255, 51, 102, 185));
        }
        private void setTable()
        {
            list.ItemsSource = m_Data;
            Header1Text = String.Format("{0}({1})", Header1Text, m_Data.Count);
        }
    }
}
