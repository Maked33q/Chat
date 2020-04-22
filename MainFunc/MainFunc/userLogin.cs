using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Printing;

namespace MainFunc
{

    //public string UserName = textbox1.Text;
    public partial class userLogin : UserControl
    {
        private string db = "Chat_db.db";
        private string table1 = "Users";
        private string table2 = "Groups";
        private SQLiteDataAdapter adapt;
        private DataTable dt;

        SQLiteConnection conn;
        public userLogin()
        {
            InitializeComponent();
            if (!File.Exists(db))
            {
                SQLiteConnection.CreateFile(db);
            }
            conn = new SQLiteConnection($"Data Source={db}; Version=3;");
            conn.Open();
            string query = $"CREATE TABLE IF NOT EXISTS {table1} (" +
                "id INTEGER PRIMARY KEY NOT NULL, " +
                "name TEXT, " +
                "pass TEXT," +
                "isActive INTEGER )";

            SQLiteCommand cmd = new SQLiteCommand(query, conn);

            if (cmd.ExecuteNonQuery() == 0)
            {
                string[] query1 =
                {
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Jerry', 'qwery',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Pedro', '1234',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Tony', 'qwerty',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Bill', '111',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('FFFF', '222',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Ron', '1q2w',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Cot', 'qwe',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Rot', 'eqw',0)",
            $"INSERT INTO {table1} (name,pass,isActive) VALUES('Mot', 'abc',0)"
            };
                for (int i = 0; i < query1.Length; i++)
                {
                    cmd.CommandText = query1[i];
                    cmd.ExecuteNonQuery();
                }
            }
            conn.Close();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain.Instance.Content.Controls.Add(new userMain());
                frmMain.Instance.Content.Controls[0].SendToBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void user_b_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.Show();
        }
    }
}
