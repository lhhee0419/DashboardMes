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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.D_Crack = new System.Windows.Forms.RadioButton();
            this.D_Scratch = new System.Windows.Forms.RadioButton();
            this.D_STED = new System.Windows.Forms.RadioButton();
            this.D_color = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.D_EQPTERROR = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.LotID_Grid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("문체부 돋음체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckBtn.Location = new System.Drawing.Point(464, 505);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(169, 82);
            this.CheckBtn.TabIndex = 0;
            this.CheckBtn.Text = "확인";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("문체부 돋음체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(750, 505);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(169, 82);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LotID_Grid
            // 
            this.LotID_Grid.AllowUserToAddRows = false;
            this.LotID_Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotID_Grid.Location = new System.Drawing.Point(32, 72);
            this.LotID_Grid.Name = "LotID_Grid";
            this.LotID_Grid.ReadOnly = true;
            this.LotID_Grid.RowHeadersVisible = false;
            this.LotID_Grid.RowHeadersWidth = 51;
            this.LotID_Grid.RowTemplate.Height = 27;
            this.LotID_Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LotID_Grid.Size = new System.Drawing.Size(902, 400);
            this.LotID_Grid.TabIndex = 2;
            this.LotID_Grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.LotID_Grid_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("문체부 돋음체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(160, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "LOT ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("문체부 돋음체", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1040, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "불량요인";
            // 
            // D_Crack
            // 
            this.D_Crack.AutoSize = true;
            this.D_Crack.Location = new System.Drawing.Point(32, 72);
            this.D_Crack.Name = "D_Crack";
            this.D_Crack.Size = new System.Drawing.Size(103, 28);
            this.D_Crack.TabIndex = 8;
            this.D_Crack.TabStop = true;
            this.D_Crack.Text = "갈라짐";
            this.D_Crack.UseVisualStyleBackColor = true;
            this.D_Crack.Click += new System.EventHandler(this.D_Crack_Click);
            // 
            // D_Scratch
            // 
            this.D_Scratch.AutoSize = true;
            this.D_Scratch.Location = new System.Drawing.Point(32, 184);
            this.D_Scratch.Name = "D_Scratch";
            this.D_Scratch.Size = new System.Drawing.Size(79, 28);
            this.D_Scratch.TabIndex = 7;
            this.D_Scratch.TabStop = true;
            this.D_Scratch.Text = "기스";
            this.D_Scratch.UseVisualStyleBackColor = true;
            this.D_Scratch.Click += new System.EventHandler(this.D_Scratch_Click);
            // 
            // D_STED
            // 
            this.D_STED.AutoSize = true;
            this.D_STED.Location = new System.Drawing.Point(32, 128);
            this.D_STED.Name = "D_STED";
            this.D_STED.Size = new System.Drawing.Size(132, 28);
            this.D_STED.TabIndex = 9;
            this.D_STED.TabStop = true;
            this.D_STED.Text = "시작/종료";
            this.D_STED.UseVisualStyleBackColor = true;
            this.D_STED.Click += new System.EventHandler(this.D_STED_Click);
            // 
            // D_color
            // 
            this.D_color.AutoSize = true;
            this.D_color.Location = new System.Drawing.Point(32, 240);
            this.D_color.Name = "D_color";
            this.D_color.Size = new System.Drawing.Size(79, 28);
            this.D_color.TabIndex = 6;
            this.D_color.TabStop = true;
            this.D_color.Text = "색상";
            this.D_color.UseVisualStyleBackColor = true;
            this.D_color.Click += new System.EventHandler(this.D_color_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.D_EQPTERROR);
            this.groupBox1.Controls.Add(this.D_color);
            this.groupBox1.Controls.Add(this.D_STED);
            this.groupBox1.Controls.Add(this.D_Scratch);
            this.groupBox1.Controls.Add(this.D_Crack);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("문체부 돋음체", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(984, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 400);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "불량요인 선택";
            // 
            // D_EQPTERROR
            // 
            this.D_EQPTERROR.AutoSize = true;
            this.D_EQPTERROR.Location = new System.Drawing.Point(32, 296);
            this.D_EQPTERROR.Name = "D_EQPTERROR";
            this.D_EQPTERROR.Size = new System.Drawing.Size(151, 28);
            this.D_EQPTERROR.TabIndex = 6;
            this.D_EQPTERROR.TabStop = true;
            this.D_EQPTERROR.Text = "설비오작동";
            this.D_EQPTERROR.UseVisualStyleBackColor = true;
            this.D_EQPTERROR.Click += new System.EventHandler(this.D_EQPTERROR_Click);
            // 
            // Faulty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 623);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LotID_Grid);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CheckBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Faulty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Faulty";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Faulty_FormClosing);
            this.Load += new System.EventHandler(this.Faulty_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Faulty_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.LotID_Grid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.DataGridView LotID_Grid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton D_Crack;
        private System.Windows.Forms.RadioButton D_Scratch;
        private System.Windows.Forms.RadioButton D_STED;
        private System.Windows.Forms.RadioButton D_color;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton D_EQPTERROR;
    }
}