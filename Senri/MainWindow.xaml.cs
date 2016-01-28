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
using System.Windows.Threading;

using System.Data.SQLite;
namespace Senri
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        int TimeLimit = 30;
        DateTime StartTime;
        TimeSpan nowtimespan;
        TimeSpan oldtimespan;

        Senri.Alarm alarm;
        Senri.AutoCode.info_drink auto;

        public MainWindow()
        {
            InitializeComponent();

            ////データの作成
            //alarm = new Alarm();
            //var data = new ObservableCollection<Alarm>(
            //    Enumerable.Range(1, 100).Select(i => new Alarm
            //    {
            //        Behavior = "site" + i,
            //        Time = "00:00:00",
            //        Week = "火"
            //    }));
            //// DataGridに設定する
            //DataGrid dataSource;
            //dataSource.ItemsSource = data;
            //タイマーのインスタンス生成
            dispatcherTimer = new DispatcherTimer(DispatcherPriority.Normal);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            text1.Text = DateTime.Now.ToLongTimeString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Control ctrl = (Control)sender;
            switch (ctrl.Name)
            {
                case "btnStart":
                    TimeStart();
                    break;

                case "btnStop":
                    TimeStop();
                    break;

                default:
                    break;
            }
        }
        private void TimeStart()
        {
            auto = new AutoCode.info_drink();
            auto.if_drink();
        }
        private void TimeStop()
        {
            var Editwnd = new EditWindow();
            Editwnd.Show();
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement elem = e.MouseDevice.DirectlyOver as FrameworkElement;
            if (elem != null)
            {
                DataGridCell cell = elem.Parent as DataGridCell;
                if (cell != null)
                {
                    //セルの内容を処理を書く
                }
            }
        }
    }
}
