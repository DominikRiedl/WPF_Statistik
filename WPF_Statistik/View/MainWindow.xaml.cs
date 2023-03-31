using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace WPF_Statistik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Data> lstData = new List<Data>();
        int i = 0;
        double ObjWidth = 0;
        double ObjHeight = 0;
        int counter = 0;
        double posX = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCanvas();
        }

        private void LbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lbData.SelectedItem == null)
            {
                btDel.IsEnabled = false;
            }
            else
            {
                btDel.IsEnabled = true;
            }
        }

        private void btNew_Click(object sender, RoutedEventArgs e)
        {
            // TODO DetailDlg

            FillCanvas();
        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {
            // TODO Löschen aus Databinding
            // TODO Löschen aus Canvas und lokaler Liste

            FillCanvas();
        }

        private void FillCanvas()
        {
            // TODO Bugfixing

            cnvStats.Children.Clear();
            lstData = Data.AlleLesen();

            i = lstData.Count;
            
            ObjWidth = cnvStats.ActualWidth / i;
            ObjHeight = cnvStats.ActualHeight / 100;

            foreach (var item in lstData)
            {
                Label lb = new Label
                {
                    Content = item.Bezeichnung,
                    Background = item.Farbe,
                    Height = item.Wert * ObjHeight,
                    Width = ObjWidth
                };

                posX = ObjWidth * counter;

                Canvas.SetBottom(lb, 0);
                Canvas.SetLeft(lb, posX);

                cnvStats.Children.Add(lb);

                counter++;
            }

            counter = 0;
        }
    }
}
