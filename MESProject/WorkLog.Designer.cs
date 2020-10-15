namespace MESProject
{
    partial class WorkLog
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
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.InquiryBtn = new System.Windows.Forms.Button();
            this.WLGrid = new System.Windows.Forms.DataGridView();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ProcCombo = new System.Windows.Forms.ComboBox();
            this.LotGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.WLGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(368, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "~";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("굴림", 15F);
            this.dateTimePicker2.Font = new System.Drawing.Font("굴림", 15F);
            this.dateTimePicker2.Location = new System.Drawing.Point(408, 78);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(327, 36);
            this.dateTimePicker2.TabIndex = 18;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("굴림", 15F);
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 15F);
            this.dateTimePicker1.Location = new System.Drawing.Point(22, 75);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(327, 36);
            this.dateTimePicker1.TabIndex = 17;
            // 
            // InquiryBtn
            // 
            this.InquiryBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InquiryBtn.Location = new System.Drawing.Point(808, 72);
            this.InquiryBtn.Name = "InquiryBtn";
            this.InquiryBtn.Size = new System.Drawing.Size(166, 66);
            this.InquiryBtn.TabIndex = 12;
            this.InquiryBtn.Text = "조회";
            this.InquiryBtn.UseVisualStyleBackColor = true;
            this.InquiryBtn.Click += new System.EventHandler(this.InquiryBtn_Click);
            // 
            // WLGrid
            // 
            this.WLGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WLGrid.Location = new System.Drawing.Point(24, 144);
            this.WLGrid.Name = "WLGrid";
            this.WLGrid.RowHeadersWidth = 51;
            this.WLGrid.RowTemplate.Height = 27;
            this.WLGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WLGrid.Size = new System.Drawing.Size(946, 350);
            this.WLGrid.TabIndex = 11;
            this.WLGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.WLGrid_MouseClick);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(808, 544);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(166, 66);
            this.ExitBtn.TabIndex = 12;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ProcCombo
            // 
            this.ProcCombo.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ProcCombo.FormattingEnabled = true;
            this.ProcCombo.Location = new System.Drawing.Point(744, 16);
            this.ProcCombo.Name = "ProcCombo";
            this.ProcCombo.Size = new System.Drawing.Size(121, 33);
            this.ProcCombo.TabIndex = 55;
            // 
            // LotGrid
            // 
            this.LotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotGrid.Location = new System.Drawing.Point(24, 496);
            this.LotGrid.Name = "LotGrid";
            this.LotGrid.RowHeadersWidth = 51;
            this.LotGrid.RowTemplate.Height = 27;
            this.LotGrid.Size = new System.Drawing.Size(695, 208);
            this.LotGrid.TabIndex = 11;
            // 
            // WorkLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.ProcCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.InquiryBtn);
            this.Controls.Add(this.LotGrid);
            this.Controls.Add(this.WLGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkLog";
            this.Text = "WorkLog";
            this.Load += new System.EventHandler(this.WorkLog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WLGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button InquiryBtn;
        private System.Windows.Forms.DataGridView WLGrid;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.ComboBox ProcCombo;
        private System.Windows.Forms.DataGridView LotGrid;
    }
}