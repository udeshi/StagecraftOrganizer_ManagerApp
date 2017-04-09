using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StagecraftOrganizer_ManagerApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
        //    int counter = 0;
        //    ObservableCollection<ObservableCollection<ObservableCollection<int>>> lsts = new ObservableCollection<ObservableCollection<ObservableCollection<int>>>();
        //    for (int x = 0; x < 5; x++)
        //    {
        //        ObservableCollection<ObservableCollection<int>> block =new ObservableCollection<ObservableCollection<int>>();
        //        for (int i = 0; i < 3; i++)
        //        {
        //            ObservableCollection < int >  row=new ObservableCollection<int>();

        //            for (int j = 0; j < 5; j++)
        //            {
        //                row.Add(counter);
        //                counter++;
        //            }
        //            block.Add(row);
        //        }
        //        lsts.Add(block);
        //    }

            InitializeComponent();

            //lst.ItemsSource = lsts;
        }

        private void lst_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }
    }
}
