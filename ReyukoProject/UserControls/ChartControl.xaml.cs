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
using Windows.UI.Xaml.Shapes;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ReyukoProject.UserControls
{
    public class DataItem
    {
        public Color BarColor { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
    }
    public sealed partial class ChartControl : UserControl
    {
      
        // Data to show 
        private List<DataItem> m_Data;

        //componenets
        private List<Line> m_Lines;
        private List<TextBlock> m_txtPros;

        // Properties
        // Color of grid lines
        public Color GridLineColor { get; set; }

        // Color of Axis labels
        public Color LabelColor { get; set; }

        // Thickness of the grid line
        public Thickness ChartMarline { get; set; }

        // Margin in graph canvas
        public int BarMarline { get; set; }

        // step Length between chart Bars
        public double BarStep { get; set; }

        // Label Font Size of X/Y axis labels
        public int LabelFontSize { get; set; }

        // Data Binding Property
        public List<DataItem> ChartData
        {
            get
            {
                return m_Data;
            }
            set
            {
                m_Data = value;

            }
        }

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
        public string CharTitle
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
        public ChartControl()
        {
            this.InitializeComponent();
            m_Data = new List<DataItem>();

            // prepare char data

            // set the chart margine
            ChartMarline = new Thickness(30, 20, 20, 20);
            BarMarline = 20;
            BarStep = 0.7;
            LabelFontSize = 12;

            // allocates the line and label
            m_Lines = new List<Line>();
            m_txtPros = new List<TextBlock>();
            for (int i = 0; i <= 10; i++)
            {
                m_Lines.Add(new Line());
                TextBlock txt = new TextBlock();
                txt.Text = string.Format("{0}", (10 - i) * 10);
                m_txtPros.Add(txt);

            }

            // set the default component colors;
            GridLineColor = Colors.DarkGray;
            LabelColor = Colors.DarkGray;


        }
        private void Size_Changed(object sender, SizeChangedEventArgs e)
        {
            try
            {
                DarwOnCanvas();
            }
            catch (Exception)
            {

            }
        }
        private void DarwOnCanvas()
        {
            canvas.Children.Clear();

            Rectangle rt = new Rectangle();

            rt.Width = canvas.ActualWidth;
            rt.Height = canvas.ActualHeight;
            rt.Fill = new SolidColorBrush(Colors.SteelBlue);
            //canvas.Children.Add(rt);

            Rectangle rtContent = new Rectangle();
            rtContent.Width = rt.Width - ChartMarline.Left - ChartMarline.Right;
            rtContent.Height = rt.Height - ChartMarline.Top - ChartMarline.Top;
            Canvas.SetLeft(rtContent, ChartMarline.Left);
            Canvas.SetTop(rtContent, ChartMarline.Top);
            rtContent.Fill = new SolidColorBrush(Colors.Red);
            //canvas.Children.Add(rtContent);

            double nTop = (int)ChartMarline.Top;
            double dSetep = rtContent.Height / 10;
            foreach (Line line in m_Lines)
            {
                line.X1 = ChartMarline.Left; line.Y1 = nTop;
                line.X2 = rt.Width - ChartMarline.Right; line.Y2 = nTop;
                line.StrokeThickness = 0.5;
                line.Stroke = new SolidColorBrush(GridLineColor);
                canvas.Children.Add(line);

                nTop += dSetep;
            }
            nTop = (int)ChartMarline.Top;
            foreach (TextBlock txt in m_txtPros)
            {
                txt.Width = ChartMarline.Left;
                txt.TextAlignment = TextAlignment.Right;
                txt.Foreground = new SolidColorBrush(LabelColor);
                Canvas.SetLeft(txt, ChartMarline.Left - txt.Width);
                Canvas.SetTop(txt, nTop - dSetep / 2);
                nTop += dSetep;
                canvas.Children.Add(txt);
            }

            int bar_len = m_Data.Count;
            if (bar_len == 0)
                return;
            int nLen = (int)(rtContent.Width - 2 * BarMarline);
            int dBarWidth = (int)((nLen) / (bar_len + (bar_len - 1) * BarStep));
            int xLeft = (int)(ChartMarline.Left + BarMarline);
            foreach (DataItem item in m_Data)
            {
                Rectangle rtBar = new Rectangle();
                rtBar.Width = dBarWidth;
                int nPro = Math.Min(100, Math.Max(0, item.Amount));
                rtBar.Height = rtContent.Height * nPro / 100;
                Canvas.SetLeft(rtBar, xLeft);
                Canvas.SetTop(rtBar, ChartMarline.Top + rtContent.Height - rtBar.Height);
                rtBar.Fill = new SolidColorBrush(item.BarColor);
                canvas.Children.Add(rtBar);

                TextBlock txt = new TextBlock();
                txt.Width = dBarWidth + dBarWidth * BarStep / 2;
                txt.Text = item.Name;
                txt.TextAlignment = TextAlignment.Center;
                txt.FontSize = LabelFontSize;
                txt.Foreground = new SolidColorBrush(LabelColor);

                Canvas.SetLeft(txt, xLeft + (dBarWidth - txt.Width) / 2);
                Canvas.SetTop(txt, ChartMarline.Top + rtContent.Height);
                canvas.Children.Add(txt);
                xLeft += (int)(rtBar.Width * (1 + BarStep));
            }


        }

        private void On_Loaded(object sender, RoutedEventArgs e)
        {
            //DarwOnCanvas();
        }
    }
}
