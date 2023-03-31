using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        }

        private void btDel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FillCanvas()
        {
            lstData = Data.AlleLesen();

            i = lstData.Count;
            ObjWidth = cnvStats.ActualWidth / i;
            ObjHeight = cnvStats.ActualHeight;


            foreach (var item in lstData)
            {
                Label lb = new Label();

                lb.Content = item.Bezeichnung;
                lb.Background = item.Farbe;
                lb.Height = item.Wert;
                lb.Width = ObjWidth;

                posX = ObjWidth * counter;

                Canvas.SetBottom(lb, 0);
                Canvas.SetLeft(lb, posX);

                cnvStats.Children.Add(lb);

                counter++;
            }

            counter = 0;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCanvas();
        }
    }
}
