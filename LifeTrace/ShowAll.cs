using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LifeTrace
{
    public partial class ShowAll : Form
    {
        class Record
        {
            public int ID { get; set; }
            public DateTime Date { get; set; }
            public int Mark { get; set; }
            public byte[] Attachment { get; set; } = null;
            public string AttachmentFileName { get; set; }
            public string Comment { get; set; }
        }

        string connString;
        Record currentRecord = null;

        public ShowAll()
        {
            InitializeComponent();
        }

        private void ShowAll_Load(object sender, EventArgs e)
        {
            this.connString = Properties.Settings.Default.LifeTraceDBConnectionString;
            this.lblRecordsCount.Text = GetTotalRecordsCount().ToString();
            this.btnAttachSave.Enabled = false;
            SelectNextPrevious(previous: true);
            DisplayCurrentRecord();
        }

        private void DisplayCurrentRecord()
        {
            if (currentRecord != null)
            {
                this.dateTimePicker.Value = currentRecord.Date;
                this.lblMark.Text = currentRecord.Mark.ToString();
                this.txtComment.Text = currentRecord.Comment;
                if (currentRecord.Attachment != null)
                {
                    this.btnAttachSave.Enabled = true;
                }
                else this.btnAttachSave.Enabled = false;
            }
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            SelectByDate(this.dateTimePicker.Value);
            DisplayCurrentRecord();
        }

        private void SelectByDate(DateTime date)
        {
            try
            {
                DateTime currentDate = dateTimePicker.Value.Date;

                using (SqlCeConnection con = new SqlCeConnection(this.connString))
                {
                    con.Open();
                    
                    using (SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM LifeTrace WHERE Date=@date", con))
                    {
                        cmd.Parameters.AddWithValue("@date", currentDate);
                        SqlCeDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        if (reader.Read())
                        {
                            Record rec = new Record
                            {
                                ID = int.Parse(reader["ID"].ToString()),
                                Date = DateTime.Parse(reader["Date"].ToString()),
                                Mark = int.Parse(reader["Mark"].ToString()),
                                Comment = reader["Comment"].ToString()
                            };
                            if (reader["AttachmentFileName"] != null)
                            {
                                rec.AttachmentFileName = reader["AttachmentFileName"].ToString();
                                rec.Attachment = reader["Attachment"] as byte[];
                            }
                            this.currentRecord = rec;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("No such date in the database!");
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectNextPrevious(bool previous = false, bool throwNotFoundEx=false)
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(this.connString))
                {
                    con.Open();

                    string query;

                    if (previous)
                    {
                        query = "SELECT * FROM LifeTrace WHERE Date < @date ORDER BY Date DESC";
                    }
                    else query = "SELECT * FROM LifeTrace WHERE Date > @date ORDER BY Date";

                    using (SqlCeCommand cmd = new SqlCeCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@date", dateTimePicker.Value.ToString());
                        SqlCeDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleRow);
                        if (reader.Read())
                        {
                            Record rec = new Record
                            {
                                ID = int.Parse(reader["ID"].ToString()),
                                Date = DateTime.Parse(reader["Date"].ToString()),
                                Mark = int.Parse(reader["Mark"].ToString()),
                                Comment = reader["Comment"].ToString()
                            };
                            if (reader["AttachmentFileName"] != null)
                            {
                                rec.AttachmentFileName = reader["AttachmentFileName"].ToString();
                                rec.Attachment = reader["Attachment"] as byte[];
                            }
                            this.currentRecord = rec;
                        }
                        else
                        {
                            throw new ObjectNotFoundException("No more records in the database!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex is ObjectNotFoundException && throwNotFoundEx)
                    throw ex;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteCurrentRecord()
        {
            try
            {
                using (SqlCeConnection con = new SqlCeConnection(this.connString))
                {
                    con.Open();

                    using (SqlCeCommand cmd = new SqlCeCommand("DELETE FROM LifeTrace WHERE ID=@id", con))
                    {
                        cmd.Parameters.AddWithValue("@id", currentRecord.ID);
                        cmd.ExecuteNonQuery();
                    }

                    try
                    {
                        SelectNextPrevious(previous: true, throwNotFoundEx: true);
                        DisplayCurrentRecord();
                    }
                    catch(ObjectNotFoundException)
                    {
                        currentRecord.ID = 0;
                        currentRecord.Date = DateTime.Now;
                        currentRecord.Comment = "";
                        currentRecord.Mark = 0;
                        currentRecord.Attachment = null;
                        currentRecord.AttachmentFileName = string.Empty;
                        DisplayCurrentRecord();
                    }
                }
                MessageBox.Show("Record was successfully deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (reader.Read())
                    {
                        result = reader.GetInt32(0); //first column
                    }
                }
            }
            return result;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SelectNextPrevious(previous: true);
            DisplayCurrentRecord();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SelectNextPrevious();
            DisplayCurrentRecord();
        }

        private void btnAttachSave_Click(object sender, EventArgs e)
        {
            if(currentRecord.Attachment!=null && currentRecord.AttachmentFileName!= null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.FileName = currentRecord.AttachmentFileName;

                if(saveDlg.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDlg.FileName, currentRecord.Attachment);
                    MessageBox.Show("Attachment was successfully saved!");
                }
            }
            else
            {
                MessageBox.Show("Attachment data or attachment file name is NULL!");
            }
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to delete the record FOREVER?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DeleteCurrentRecord();
            }
        }
    }
}
