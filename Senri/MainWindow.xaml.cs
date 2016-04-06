using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Data.SQLite;
using System.Data;
using System.Data.Common;

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
        static DataSet dataset = new DataSet(); // DaaSetのインスタンスを作成する。
        DataTable table = dataset.Tables.Add(); // DAtaSetにテーブルを追加する。

        Senri.Alarm alarm;

        public MainWindow()
        {
            InitializeComponent();

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

                case "AddItem":
                    Add();
                    break;

                case "LoadItem":
                    DbLoad();
                    break;

                case "SeveItem":
                    DbSeve();
                    break;

                default:
                    break;
            }
        }
        /// <summary>
        /// スタートボタン
        /// </summary>
        private void TimeStart()
        {
            Senri.AutoCode.aspit_joune_sumi auto;
            auto = new AutoCode.aspit_joune_sumi();
            auto.sumi();
            //auto.SeveFileDialog();
            var script = CSharpScript.Create("Console.WriteLune");
            //Senri.AutoCode.info_drink auto;
            //auto = new AutoCode.info_drink();
            //auto.if_drink();
        }
        private void NOUDStart()
        {
            DataGrid.SelectedEvent.GetType();
        }
        private void TimeStop()
        {
            //var Editwnd = new EditWindow();
            //Editwnd.Show();
        }
        private void Add()
        {
            DataRow row = table.NewRow();
            row[1] = "addtest";
            table.Rows.Add(row);
        }

        private void DbLoad()
        {
            Database.SQLite SQDb;
            SQDb = new Database.SQLite();
            string exePath = Environment.GetCommandLineArgs()[0];
            string exeFullPath = System.IO.Path.GetFullPath(exePath);
            string startupPath = System.IO.Path.GetDirectoryName(exeFullPath);
            string DbPath = startupPath + "\\Alarm.db";
            if (System.IO.File.Exists(DbPath))
            {
                dataGrid.DataContext = SQDb.loadDb(table);
            }
            else
            {
                SQDb.createDb();
                dataGrid.DataContext = SQDb.loadDb(table);
            }
        }

        private void DbSeve()
        {
            Database.SQLite SQDb;
            SQDb = new Database.SQLite();
            SQDb.seveDb(table);
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
