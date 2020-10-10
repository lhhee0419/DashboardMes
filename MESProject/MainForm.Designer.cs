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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InquiryBtn = new System.Windows.Forms.Button();
            this.WostBtn = new System.Windows.Forms.Button();
            this.WoLogBtn = new System.Windows.Forms.Button();
            this.EquipmanageBtn = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.ProcCombo = new System.Windows.Forms.ComboBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 230);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1177, 506);
            this.dataGridView1.TabIndex = 0;
            // 
            // InquiryBtn
            // 
            this.InquiryBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.InquiryBtn.Location = new System.Drawing.Point(1082, 135);
            this.InquiryBtn.Name = "InquiryBtn";
            this.InquiryBtn.Size = new System.Drawing.Size(166, 66);
            this.InquiryBtn.TabIndex = 1;
            this.InquiryBtn.Text = "조회";
            this.InquiryBtn.UseVisualStyleBackColor = true;
            this.InquiryBtn.Click += new System.EventHandler(this.InquiryBtn_Click);
            // 
            // WostBtn
            // 
            this.WostBtn.Font = new System.Drawing.Font("굴림", 15F);
            this.WostBtn.Location = new System.Drawing.Point(60, 766);
            this.WostBtn.Name = "WostBtn";
            this.WostBtn.Size = new System.Drawing.Size(165, 73);
            this.WostBtn.TabIndex = 2;
            this.WostBtn.Text = "작업시작";
            this.WostBtn.UseVisualStyleBackColor = true;
            // 
            // WoLogBtn
            // 
            this.WoLogBtn.Font = new System.Drawing.Font("굴림", 15F);
            this.WoLogBtn.Location = new System.Drawing.Point(306, 766);
            this.WoLogBtn.Name = "WoLogBtn";
            this.WoLogBtn.Size = new System.Drawing.Size(163, 73);
            this.WoLogBtn.TabIndex = 3;
            this.WoLogBtn.Text = "작업일지";
            this.WoLogBtn.UseVisualStyleBackColor = true;
            // 
            // EquipmanageBtn
            // 
            this.EquipmanageBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EquipmanageBtn.Location = new System.Drawing.Point(544, 766);
            this.EquipmanageBtn.Name = "EquipmanageBtn";
            this.EquipmanageBtn.Size = new System.Drawing.Size(164, 73);
            this.EquipmanageBtn.TabIndex = 5;
            this.EquipmanageBtn.Text = "설비관리";
            this.EquipmanageBtn.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker1.Location = new System.Drawing.Point(47, 150);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(327, 36);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.dateTimePicker2.Location = new System.Drawing.Point(467, 150);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(333, 36);
            this.dateTimePicker2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(406, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            // 
            // ProcCombo
            // 
            this.ProcCombo.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ProcCombo.FormattingEnabled = true;
            this.ProcCombo.Location = new System.Drawing.Point(956, 63);
            this.ProcCombo.Name = "ProcCombo";
            this.ProcCombo.Size = new System.Drawing.Size(121, 33);
            this.ProcCombo.TabIndex = 9;
            this.ProcCombo.SelectedIndexChanged += new System.EventHandler(this.ProcCombo_SelectedIndexChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(1227, 230);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 506);
            this.vScrollBar1.TabIndex = 10;
            // 
            // logoutbtn
            // 
            this.logoutbtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.logoutbtn.Location = new System.Drawing.Point(1060, 766);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(164, 73);
            this.logoutbtn.TabIndex = 11;
            this.logoutbtn.Text = "로그아웃";
            this.logoutbtn.UseVisualStyleBackColor = true;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1282, 39);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1280, 1024);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.logoutbtn);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.ProcCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.EquipmanageBtn);
            this.Controls.Add(this.WoLogBtn);
            this.Controls.Add(this.WostBtn);
            this.Controls.Add(this.InquiryBtn);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button InquiryBtn;
        private System.Windows.Forms.Button WostBtn;
        private System.Windows.Forms.Button WoLogBtn;
        private System.Windows.Forms.Button EquipmanageBtn;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ProcCombo;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Panel panel1;
    }
}

