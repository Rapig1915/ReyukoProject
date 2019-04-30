using ReyukoProject.UserControls;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReyukoProject.Pages.Dashboard_Page
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard_Page : Page
    {
        public Dashboard_Page()
        {
            this.InitializeComponent();

            makeData();
        }

        private void makeData()
        {
            List<ChartControl> chartList = new List<ChartControl>();
            chartList.Add(graph1);
            chartList.Add(graph2);
            chartList.Add(graph3);
            chartList.Add(graph4);

            foreach (ChartControl chart in chartList)
            {
                List<DataItem> data = new List<DataItem>();
                Random r = new Random();
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 92, 140, 150), Name = "January", Amount = r.Next(0, 100) });
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 188, 59, 76), Name = "Feburary", Amount = r.Next(0, 100) });
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 171, 133, 69), Name = "March", Amount = r.Next(0, 100) });
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 145, 79, 112), Name = "April", Amount = r.Next(0, 100) });
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 125, 152, 90), Name = "May", Amount = r.Next(0, 100) });
                data.Add(new DataItem { BarColor = Color.FromArgb(255, 121, 94, 143), Name = "June", Amount = r.Next(0, 100) });
                chart.ChartData = data;
            }

            graph1.CharTitle = "Net Income";
            graph2.CharTitle = "Cost";
            graph3.CharTitle = "EBITDA";
            graph4.CharTitle = "Net Income";

            // list provider
            List<string> listData = new List<string>();
            listData.Add("12/12/2018 News Lorem lpsum 1");
            listData.Add("12/12/2018 News Lorem lpsum 2");
            listData.Add("12/12/2018 News Lorem lpsum 3");
            listData.Add("12/12/2018 News Lorem lpsum 4");
            listData.Add("12/12/2018 News Lorem lpsum 5");
            listData.Add("12/12/2018News Lorem lpsum");

            list1.ListTitle = "Dcember 11, 2018";
            list1.TitleFontSize = 25;
            list1.ListData = listData;
            list1.ListItemClickedHandler += Item_ClickedAsync;

            // Tables 
            List<Dashboard_TableItem> tableData = new List<Dashboard_TableItem>();
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Rahmat", Amount = "Rp 234.231" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Dimas", Amount = "Rp 123.236" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Supri", Amount = "Rp 543.567" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Anna", Amount = "Rp 232.543" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Tanya", Amount = "Rp 546.321" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Ruis", Amount = "Rp 643.324" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Boris", Amount = "Rp 542.652" });
            table1.Header1Text = "Anual Invoice";
            table1.Header2Text = "Total";
            table1.EllipseColor = Color.FromArgb(255, 80, 173, 229);
            table1.TableData = tableData;

            tableData = new List<Dashboard_TableItem>();
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Yuli", Amount = "Rp 234.231" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Endar", Amount = "Rp 123.236" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Gori", Amount = "Rp 543.567" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Anyu", Amount = "Rp 232.543" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Wang", Amount = "Rp 546.321" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Chang", Amount = "Rp 643.324" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Gungfu", Amount = "Rp 542.652" });

            table2.Header1Text = "Receivable Due";
            table2.Header2Text = "Total";
            table2.EllipseColor = Color.FromArgb(255, 241, 67, 136);
            table2.TableData = tableData;

            tableData = new List<Dashboard_TableItem>();
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Paladin", Amount = "Rp 234.231" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Tom", Amount = "Rp 123.236" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Sophia", Amount = "Rp 543.567" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Alosha", Amount = "Rp 232.543" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Peny", Amount = "Rp 546.321" });
            tableData.Add(new Dashboard_TableItem { Selected = false, Name = "Maria", Amount = "Rp 643.324" });
            table3.Header1Text = "Debt Due";
            table3.Header2Text = "Total";
            table3.EllipseColor = Color.FromArgb(255, 117, 202, 63);
            table3.TableData = tableData;
        }

        private void Item_ClickedAsync(object sender, ItemClickEventArgs e)
        {
            string str = e.ClickedItem.ToString();
            Dashboard_ListDetailWindow.ListItemDetail(str, "Your content here");

        }
    }
}
