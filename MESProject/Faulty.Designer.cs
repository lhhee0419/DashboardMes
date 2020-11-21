namespace MESProject
{
    partial class Faulty
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
            this.CheckBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotID_Grid = new System.Windows.Forms.DataGridView();
            this.D_Name1 = new System.Windows.Forms.RadioButton();
            this.D_Name3 = new System.Windows.Forms.RadioButton();
            this.D_Name2 = new System.Windows.Forms.RadioButton();
            this.D_Name4 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.D_Name5 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.LotID_Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 16.2F);
            this.CheckBtn.Location = new System.Drawing.Point(297, 565);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(237, 101);
            this.CheckBtn.TabIndex = 0;
            this.CheckBtn.Text = "확인";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 16.2F);
            this.ExitBtn.Location = new System.Drawing.Point(831, 565);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(237, 101);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LotID_Grid
            // 
            this.LotID_Grid.AllowUserToAddRows = false;
            this.LotID_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotID_Grid.Location = new System.Drawing.Point(19, 33);
            this.LotID_Grid.Name = "LotID_Grid";
            this.LotID_Grid.ReadOnly = true;
            this.LotID_Grid.RowHeadersVisible = false;
            this.LotID_Grid.RowHeadersWidth = 51;
            this.LotID_Grid.RowTemplate.Height = 27;
            this.LotID_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LotID_Grid.Size = new System.Drawing.Size(1049, 513);
            this.LotID_Grid.TabIndex = 2;
            this.LotID_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LotID_Grid_CellClick);
            // 
            // D_Name1
            // 
            this.D_Name1.AutoSize = true;
            this.D_Name1.Location = new System.Drawing.Point(32, 72);
            this.D_Name1.Name = "D_Name1";
            this.D_Name1.Size = new System.Drawing.Size(99, 30);
            this.D_Name1.TabIndex = 8;
            this.D_Name1.TabStop = true;
            this.D_Name1.Text = "갈라짐";
            this.D_Name1.UseVisualStyleBackColor = true;
            this.D_Name1.Click += new System.EventHandler(this.D_Name1_Click);
            // 
            // D_Name3
            // 
            this.D_Name3.AutoSize = true;
            this.D_Name3.Location = new System.Drawing.Point(32, 182);
            this.D_Name3.Name = "D_Name3";
            this.D_Name3.Size = new System.Drawing.Size(77, 30);
            this.D_Name3.TabIndex = 7;
            this.D_Name3.TabStop = true;
            this.D_Name3.Text = "기스";
            this.D_Name3.UseVisualStyleBackColor = true;
            this.D_Name3.Click += new System.EventHandler(this.D_Name3_Click);
            // 
            // D_Name2
            // 
            this.D_Name2.AutoSize = true;
            this.D_Name2.Location = new System.Drawing.Point(32, 127);
            this.D_Name2.Name = "D_Name2";
            this.D_Name2.Size = new System.Drawing.Size(131, 30);
            this.D_Name2.TabIndex = 9;
            this.D_Name2.TabStop = true;
            this.D_Name2.Text = "시작/종료";
            this.D_Name2.UseVisualStyleBackColor = true;
            this.D_Name2.Click += new System.EventHandler(this.D_Name2_Click);
            // 
            // D_Name4
            // 
            this.D_Name4.AutoSize = true;
            this.D_Name4.Location = new System.Drawing.Point(32, 237);
            this.D_Name4.Name = "D_Name4";
            this.D_Name4.Size = new System.Drawing.Size(77, 30);
            this.D_Name4.TabIndex = 6;
            this.D_Name4.TabStop = true;
            this.D_Name4.Text = "색상";
            this.D_Name4.UseVisualStyleBackColor = true;
            this.D_Name4.Click += new System.EventHandler(this.D_Name4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.D_Name5);
            this.groupBox1.Controls.Add(this.D_Name4);
            this.groupBox1.Controls.Add(this.D_Name2);
            this.groupBox1.Controls.Add(this.D_Name3);
            this.groupBox1.Controls.Add(this.D_Name1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 13.8F);
            this.groupBox1.Location = new System.Drawing.Point(1103, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 400);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "불량요인 선택";
            // 
            // D_Name5
            // 
            this.D_Name5.AutoSize = true;
            this.D_Name5.Location = new System.Drawing.Point(32, 292);
            this.D_Name5.Name = "D_Name5";
            this.D_Name5.Size = new System.Drawing.Size(77, 30);
            this.D_Name5.TabIndex = 10;
            this.D_Name5.TabStop = true;
            this.D_Name5.Text = "기타";
            this.D_Name5.UseVisualStyleBackColor = true;
            this.D_Name5.Click += new System.EventHandler(this.D_Name5_Click);
            // 
            // Faulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1367, 678);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LotID_Grid);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CheckBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Faulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Faulty_FormClosing);
            this.Load += new System.EventHandler(this.Faulty_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.LotID_Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.DataGridView LotID_Grid;
        private System.Windows.Forms.RadioButton D_Name1;
        private System.Windows.Forms.RadioButton D_Name3;
        private System.Windows.Forms.RadioButton D_Name2;
        private System.Windows.Forms.RadioButton D_Name4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton D_Name5;
    }
}