using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows;

namespace Senri.Database
{
    class SQLite
    {
        private static String dataSource = "Data Source=Alarm.db";

        public void createDb()
        {
            using (var connection = new SQLiteConnection(dataSource))
            {
                connection.Open();
                using (SQLiteCommand command = connection.CreateCommand())
                {
                    command.CommandText = "create table Alarm(id INTEGER PRIMARY KEY AUTOINCREMENT, 名前 TEXT, 時間 TEXT, 曜日 TEXT, Scriptパス TEXT)";
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public DataTable loadDb(DataTable table)
        {
            table.Clear();
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SQLite");
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = dataSource;
                    using (connection)
                    {
                        // コマンドを作る
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT * FROM Alarm";
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;

                        // Dataadapterを作成
                        DbDataAdapter adapter = factory.CreateDataAdapter();
                        adapter.SelectCommand = command;

                        // 読み込み
                        adapter.Fill(table);
                    }
                        return table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        public void seveDb(DataTable table)
        {
            try
            {
                DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.SQLite");
                using (DbConnection connection = factory.CreateConnection())
                {
                    connection.ConnectionString = dataSource;
                    using (connection)
                    {
                        // コマンドを作る
                        DbCommand command = connection.CreateCommand();
                        command.CommandText = "SELECT * FROM Alarm";
                        command.CommandType = CommandType.Text;
                        command.Connection = connection;

                        // DataAdpterを作る
                        DbDataAdapter adapter = factory.CreateDataAdapter();
                        adapter.SelectCommand = command;

                        // INSERT, UPDATA, DELETEコマンドを作る
                        DbCommandBuilder builder = factory.CreateCommandBuilder();
                        builder.DataAdapter = adapter;
                        adapter.InsertCommand = builder.GetInsertCommand();
                        adapter.UpdateCommand = builder.GetUpdateCommand();
                        adapter.DeleteCommand = builder.GetDeleteCommand();

                        // 書き込み
                        adapter.Update(table);
                    }
                    MessageBox.Show("Seved.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
