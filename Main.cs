using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Data.SQLite;


namespace CaliberMissing
{
    public partial class Main : Form
    {
        string metadataDB = "";

        public Main()
        {
            InitializeComponent();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.DBName = SelectedDB.Text;
            Properties.Settings.Default.Save();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SelectedDB.Text = Properties.Settings.Default.DBName;
            if (SelectedDB.Text != "")
            {
                if (File.Exists(SelectedDB.Text + "\\metadata.db"))
                {
                    metadataDB = SelectedDB.Text + "\\metadata.db";
                    Detect.Enabled = true;
                }
                else
                {
                    metadataDB = "";
                    Detect.Enabled = false;
                    MessageBox.Show("Selected folder is not a Caliber Library or does not exist");
                }
            }
        }

        private void CloseThis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Detect_Click(object sender, EventArgs e)
        {
            if (metadataDB == "")
            {
                MessageBox.Show("Please select a Caliber Library");
            }
            else
            {
                GetMissingBooks();
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = SelectedDB.Text;
            fbd.ShowNewFolderButton = false;
            fbd.Description = "Select Library Folder";
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
                SelectedDB.Text = fbd.SelectedPath;

            if (File.Exists(SelectedDB.Text + "\\metadata.db"))
            {
                metadataDB = SelectedDB.Text + "\\metadata.db";
                Detect.Enabled = true;
            }
            else
            {
                metadataDB = "";
                Detect.Enabled = false;
                MessageBox.Show("Selected folder is not a Caliber Library", "Select Library");
            }
        }

        private void GetMissingBooks()
        {
            string SQL = "Select b.title, b.sort, b.path || '/' || d.name  || '.' || d.format as bookfilename from books b inner join data d on b.id = d.book order by b.sort";

            this.Cursor = Cursors.WaitCursor;

            try
            {
                DataTable dt = GetDataSet(SQL);

                List<string> missingBooks = new List<string>();
                missingBooks = VerifyFormatExists(dt);
                LoadListBox(missingBooks);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void LoadListBox(List<string> lines)
        {
            if (lines.Count > 0)
            {
                foreach (string line in lines)
                    Output.Items.Add(line);
                Export.Enabled = true;
            }
            else
            {
                Output.Items.Add("No missing formats found");
                Export.Enabled = false;
            }
        }

        private DataTable GetDataSet(string sql)
        {
            SQLiteConnection db = new SQLiteConnection("Data Source=" + metadataDB + "; Version=3;Read Only=True");

            db.Open();

            SQLiteCommand sqlite_cmd;
            sqlite_cmd = db.CreateCommand();

            sqlite_cmd.CommandText = sql;

            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);
            da.Fill(dt);
            db.Close();

            return dt;
        }

        private List<string> VerifyFormatExists(DataTable tab)
        {
            List<string> result = new List<string>();
            string baseFolder = Path.GetDirectoryName(metadataDB) + "/";

            foreach (DataRow row in tab.Rows)
            {
                string fmtString = baseFolder + Convert.ToString(row["bookfilename"]);
                if (!File.Exists(fmtString))
                {
                    result.Add(fmtString);
                }
            }

            return result;
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files(txt)|*.txt|CSV Files(csv)|*.csv|All files|*.*";
            ofd.Title = "Select Output File";
            ofd.CheckFileExists = false;
            ofd.CheckPathExists = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sPath = ofd.FileName;

                System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
                foreach (var item in Output.Items)
                {
                    SaveFile.WriteLine(item);
                }

                SaveFile.Close();
            }
        }
    }
}
