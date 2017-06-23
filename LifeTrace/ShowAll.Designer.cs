namespace LifeTrace
{
    partial class ShowAll
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAll));
            this.lifeTraceDBDataSet = new LifeTrace.LifeTraceDBDataSet();
            this.lifeTraceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lifeTraceTableAdapter = new LifeTrace.LifeTraceDBDataSetTableAdapters.LifeTraceTableAdapter();
            this.btnAttachSave = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.lblMark = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblRecordsCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDeleteRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lifeTraceDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifeTraceBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lifeTraceDBDataSet
            // 
            this.lifeTraceDBDataSet.DataSetName = "LifeTraceDBDataSet";
            this.lifeTraceDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lifeTraceBindingSource
            // 
            this.lifeTraceBindingSource.DataMember = "LifeTrace";
            this.lifeTraceBindingSource.DataSource = this.lifeTraceDBDataSet;
            // 
            // lifeTraceTableAdapter
            // 
            this.lifeTraceTableAdapter.ClearBeforeFill = true;
            // 
            // btnAttachSave
            // 
            this.btnAttachSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachSave.Enabled = false;
            this.btnAttachSave.Location = new System.Drawing.Point(240, 267);
            this.btnAttachSave.Name = "btnAttachSave";
            this.btnAttachSave.Size = new System.Drawing.Size(111, 23);
            this.btnAttachSave.TabIndex = 13;
            this.btnAttachSave.Text = "Save attachment";
            this.btnAttachSave.UseVisualStyleBackColor = true;
            this.btnAttachSave.Click += new System.EventHandler(this.btnAttachSave_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Location = new System.Drawing.Point(105, 312);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(65, 44);
            this.btnPrev.TabIndex = 12;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // txtComment
            // 
            this.txtComment.AcceptsReturn = true;
            this.txtComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComment.Location = new System.Drawing.Point(105, 82);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.ReadOnly = true;
            this.txtComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtComment.Size = new System.Drawing.Size(246, 179);
            this.txtComment.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Mark";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Comment";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(286, 312);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(65, 44);
            this.btnNext.TabIndex = 17;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(105, 13);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(239, 20);
            this.dateTimePicker.TabIndex = 9;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // lblMark
            // 
            this.lblMark.AutoSize = true;
            this.lblMark.Location = new System.Drawing.Point(102, 46);
            this.lblMark.Name = "lblMark";
            this.lblMark.Size = new System.Drawing.Size(47, 13);
            this.lblMark.TabIndex = 18;
            this.lblMark.Text = "[lblMark]";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblRecordsCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(374, 22);
            this.statusStrip1.TabIndex = 19;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(86, 17);
            this.toolStripStatusLabel1.Text = "Records count:";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(103, 17);
            this.lblRecordsCount.Text = "[lblRecordsCount]";
            // 
            // btnDeleteRecord
            // 
            this.btnDeleteRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteRecord.Image")));
            this.btnDeleteRecord.Location = new System.Drawing.Point(105, 267);
            this.btnDeleteRecord.Name = "btnDeleteRecord";
            this.btnDeleteRecord.Size = new System.Drawing.Size(27, 23);
            this.btnDeleteRecord.TabIndex = 20;
            this.btnDeleteRecord.UseVisualStyleBackColor = true;
            this.btnDeleteRecord.Click += new System.EventHandler(this.btnDeleteRecord_Click);
            // 
            // ShowAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 381);
            this.Controls.Add(this.btnDeleteRecord);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblMark);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAttachSave);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.dateTimePicker);
            this.Name = "ShowAll";
            this.Text = "ShowAll";
            this.Load += new System.EventHandler(this.ShowAll_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lifeTraceDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifeTraceBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private LifeTraceDBDataSet lifeTraceDBDataSet;
        private System.Windows.Forms.BindingSource lifeTraceBindingSource;
        private LifeTraceDBDataSetTableAdapters.LifeTraceTableAdapter lifeTraceTableAdapter;
        private System.Windows.Forms.Button btnAttachSave;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Label lblMark;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblRecordsCount;
        private System.Windows.Forms.Button btnDeleteRecord;
    }
}