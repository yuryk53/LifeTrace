using System;
using System.Collections.Generic;
using System.ComponentModel;
/*
    This program is just a diary application.
    Copyright (C) 2016-2017  Yurii Bilyk

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program. If not, see <http://www.gnu.org/licenses/>.
*/

using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlServerCe;
using System.Globalization;

using System.IO;


namespace LifeTrace
{
    public partial class Main : Form
    {
        string connString;
        byte[] attachment;
        string attachmentFileName=null;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.connString = Properties.Settings.Default.LifeTraceDBConnectionString;
            this.lblRecordsCount.Text = GetTotalRecordsCount().ToString();
        }

        private int GetTotalRecordsCount()
        {
            int result = 0;
            using (SqlCeConnection conn = new SqlCeConnection(this.connString))
            {
                conn.Open();
                string command = "SELECT COUNT(*) FROM LifeTrace";
                using (SqlCeCommand cmd = new SqlCeCommand(command, conn))
                {
                    SqlCeDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        result = reader.GetInt32(0); //first column
                    }
                }
            }
            return result;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime currentDate = dateTimePicker.Value.Date;
                int mark;
                try
                { mark = int.Parse(comboMark.SelectedItem.ToString()); }
                catch
                { throw new Exception("Mark is not selected!"); }

                using (SqlCeConnection con = new SqlCeConnection(this.connString))
                {
                    con.Open();

                    //check for duplicate

                    CheckForDuplicate(con, currentDate);
                    //---------------------


                    //insert new record into DB
                    if (this.attachment == null || this.attachmentFileName == null)
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand("INSERT INTO LifeTrace (Date, Mark, Comment) VALUES(@date, @mark, @comment)", con))
                        {
                            cmd.Parameters.AddWithValue("@date", currentDate);
                            cmd.Parameters.AddWithValue("@mark", mark);
                            cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (SqlCeCommand cmd = new SqlCeCommand(@"INSERT INTO LifeTrace (Date, Mark, Comment, Attachment, AttachmentFileName) 
                                                                     VALUES(@date, @mark, @comment, @attachment, @attachmentFileName)", con))
                        {
                            cmd.Parameters.AddWithValue("@date", currentDate);
                            cmd.Parameters.AddWithValue("@mark", mark);
                            cmd.Parameters.AddWithValue("@comment", txtComment.Text);
                            cmd.Parameters.AddWithValue("@attachment", this.attachment);
                            cmd.Parameters.AddWithValue("@attachmentFileName", this.attachmentFileName);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Record successfully saved!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckForDuplicate(SqlCeConnection con, DateTime currentDate)
        {
            using (SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM LifeTrace WHERE Date=@date", con))
            {
                cmd.Parameters.AddWithValue("@date", currentDate);

                if (cmd.ExecuteReader().Read())
                {
                    throw new Exception("Database already has this date!");
                }
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDlg = new OpenFileDialog();
                if(openDlg.ShowDialog() == DialogResult.OK)
                {
                    this.attachment = File.ReadAllBytes(openDlg.FileName);
                    this.attachmentFileName = Path.GetFileName(openDlg.FileName);
                    
                    MessageBox.Show("Attachment was successfully loaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData==(Keys.Control | Keys.D))
            {
                ShowAll showAllWindow = new ShowAll();
                showAllWindow.ShowDialog();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
