namespace MESProject
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.maintab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.ProcCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.WoLogBtn = new System.Windows.Forms.Button();
            this.WostBtn = new System.Windows.Forms.Button();
            this.InquiryBtn = new System.Windows.Forms.Button();
            this.WoGrid = new System.Windows.Forms.DataGridView();
            this.MaterialBtn = new System.Windows.Forms.Button();
            this.maintab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 35;
            // 
            // maintab
            // 
            this.maintab.Controls.Add(this.tabPage1);
            this.maintab.Font = new System.Drawing.Font("문체부 돋음체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.maintab.Location = new System.Drawing.Point(0, 0);
            this.maintab.Name = "maintab";
            this.maintab.SelectedIndex = 0;
            this.maintab.Size = new System.Drawing.Size(1552, 858);
            this.maintab.TabIndex = 34;
            this.maintab.MouseDown += new System.Windows.Forms.MouseEventHandler(this.maintab_MouseDown);
            this.maintab.MouseMove += new System.Windows.Forms.MouseEventHandler(this.maintab_MouseMove);
            this.maintab.MouseUp += new System.Windows.Forms.MouseEventHandler(this.maintab_MouseUp);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MaterialBtn);
            this.tabPage1.Controls.Add(this.logoutbtn);
            this.tabPage1.Controls.Add(this.ProcCombo);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.dateTimePicker1);
            this.tabPage1.Controls.Add(this.WoLogBtn);
            this.tabPage1.Controls.Add(this.WostBtn);
            this.tabPage1.Controls.Add(this.InquiryBtn);
            this.tabPage1.Controls.Add(this.WoGrid);
            this.tabPage1.Font = new System.Drawing.Font("문체부 돋음체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1544, 817);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "메인화면";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // logoutbtn
            // 
            this.logoutbtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logoutbtn.Location = new System.Drawing.Point(1303, 699);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(222, 97);
            this.logoutbtn.TabIndex = 56;
            this.logoutbtn.Text = "로그아웃";
            this.logoutbtn.UseVisualStyleBackColor = true;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // ProcCombo
            // 
            this.ProcCombo.Font = new System.Drawing.Font("굴림", 16F);
            this.ProcCombo.FormattingEnabled = true;
            this.ProcCombo.Location = new System.Drawing.Point(1110, 16);
            this.ProcCombo.Name = "ProcCombo";
            this.ProcCombo.Size = new System.Drawing.Size(150, 35);
            this.ProcCombo.TabIndex = 54;
            this.ProcCombo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(403, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 25);
            this.label1.TabIndex = 53;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Font = new System.Drawing.Font("굴림", 16F);
            this.dateTimePicker2.Location = new System.Drawing.Point(464, 116);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(399, 38);
            this.dateTimePicker2.TabIndex = 52;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 16F);
            this.dateTimePicker1.Location = new System.Drawing.Point(44, 116);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(393, 38);
            this.dateTimePicker1.TabIndex = 51;
            // 
            // WoLogBtn
            // 
            this.WoLogBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WoLogBtn.Location = new System.Drawing.Point(261, 699);
            this.WoLogBtn.Name = "WoLogBtn";
            this.WoLogBtn.Size = new System.Drawing.Size(222, 97);
            this.WoLogBtn.TabIndex = 49;
            this.WoLogBtn.Text = "작업일지";
            this.WoLogBtn.UseVisualStyleBackColor = true;
            this.WoLogBtn.Click += new System.EventHandler(this.WoLogBtn_Click);
            // 
            // WostBtn
            // 
            this.WostBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.WostBtn.Location = new System.Drawing.Point(23, 699);
            this.WostBtn.Name = "WostBtn";
            this.WostBtn.Size = new System.Drawing.Size(222, 97);
            this.WostBtn.TabIndex = 48;
            this.WostBtn.Text = "작업시작";
            this.WostBtn.UseVisualStyleBackColor = true;
            this.WostBtn.Click += new System.EventHandler(this.WostBtn_Click);
            // 
            // InquiryBtn
            // 
            this.InquiryBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InquiryBtn.Location = new System.Drawing.Point(1303, 75);
            this.InquiryBtn.Name = "InquiryBtn";
            this.InquiryBtn.Size = new System.Drawing.Size(222, 97);
            this.InquiryBtn.TabIndex = 47;
            this.InquiryBtn.Text = "조회";
            this.InquiryBtn.UseVisualStyleBackColor = true;
            this.InquiryBtn.Click += new System.EventHandler(this.InquiryBtn_Click);
            // 
            // WoGrid
            // 
            this.WoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WoGrid.Location = new System.Drawing.Point(23, 196);
            this.WoGrid.Name = "WoGrid";
            this.WoGrid.ReadOnly = true;
            this.WoGrid.RowHeadersVisible = false;
            this.WoGrid.RowHeadersWidth = 51;
            this.WoGrid.RowTemplate.Height = 27;
            this.WoGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.WoGrid.Size = new System.Drawing.Size(1502, 470);
            this.WoGrid.TabIndex = 46;
            this.WoGrid.DataSourceChanged += new System.EventHandler(this.WoGrid_DataSourceChanged);
            this.WoGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.WoGrid_CellDoubleClick);
            // 
            // MaterialBtn
            // 
            this.MaterialBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaterialBtn.Location = new System.Drawing.Point(499, 699);
            this.MaterialBtn.Name = "MaterialBtn";
            this.MaterialBtn.Size = new System.Drawing.Size(222, 97);
            this.MaterialBtn.TabIndex = 57;
            this.MaterialBtn.Text = "원재료 재고 관리";
            this.MaterialBtn.UseVisualStyleBackColor = true;
            this.MaterialBtn.Click += new System.EventHandler(this.MaterialBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1559, 857);
            this.Controls.Add(this.maintab);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.maintab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl maintab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.ComboBox ProcCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button WoLogBtn;
        private System.Windows.Forms.Button WostBtn;
        private System.Windows.Forms.Button InquiryBtn;
        private System.Windows.Forms.DataGridView WoGrid;
        private System.Windows.Forms.Button MaterialBtn;
    }
}

