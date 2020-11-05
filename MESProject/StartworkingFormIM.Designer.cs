namespace MESProject
{
    partial class Startworking
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
            this.StockBtn = new System.Windows.Forms.Button();
            this.FaultyBtn = new System.Windows.Forms.Button();
            this.LotDelBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.LotaddBtn = new System.Windows.Forms.Button();
            this.LotGrid = new System.Windows.Forms.DataGridView();
            this.WoGrid = new System.Windows.Forms.DataGridView();
            this.IM1_STBtn = new System.Windows.Forms.Button();
            this.IM2_STBtn = new System.Windows.Forms.Button();
            this.IM2_Label1 = new System.Windows.Forms.Label();
            this.IM2_Label2 = new System.Windows.Forms.Label();
            this.IM2_Label3 = new System.Windows.Forms.Label();
            this.IM2_Label4 = new System.Windows.Forms.Label();
            this.IM1_Label1 = new System.Windows.Forms.Label();
            this.IM1_Label2 = new System.Windows.Forms.Label();
            this.IM1_Label3 = new System.Windows.Forms.Label();
            this.IM1_Label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.IM2_ProdQty = new System.Windows.Forms.Label();
            this.IM2_ProdQty_Value = new System.Windows.Forms.Label();
            this.IM1_ProdQty = new System.Windows.Forms.Label();
            this.IM1_ProdQty_Value = new System.Windows.Forms.Label();
            this.CurTime = new System.Windows.Forms.Label();
            this.IM1 = new System.Windows.Forms.PictureBox();
            this.IM2 = new System.Windows.Forms.PictureBox();
            this.silo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IM1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IM2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StockBtn
            // 
            this.StockBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.StockBtn.Location = new System.Drawing.Point(1012, 725);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(118, 86);
            this.StockBtn.TabIndex = 27;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            this.StockBtn.Click += new System.EventHandler(this.StockBtn_Click);
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.FaultyBtn.Location = new System.Drawing.Point(273, 725);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(118, 86);
            this.FaultyBtn.TabIndex = 26;
            this.FaultyBtn.Text = "불량    등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
            this.FaultyBtn.Click += new System.EventHandler(this.FaultyBtn_Click);
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.LotDelBtn.Location = new System.Drawing.Point(149, 725);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(118, 86);
            this.LotDelBtn.TabIndex = 25;
            this.LotDelBtn.Text = "LOT   삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            this.LotDelBtn.Click += new System.EventHandler(this.LotDelBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.ExitBtn.Location = new System.Drawing.Point(1416, 725);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(118, 86);
            this.ExitBtn.TabIndex = 24;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.EndBtn.Location = new System.Drawing.Point(1282, 725);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(118, 86);
            this.EndBtn.TabIndex = 23;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.StopBtn.Location = new System.Drawing.Point(1149, 725);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(118, 86);
            this.StopBtn.TabIndex = 22;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LotaddBtn.Location = new System.Drawing.Point(25, 725);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(118, 86);
            this.LotaddBtn.TabIndex = 21;
            this.LotaddBtn.Text = "LOT    추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            this.LotaddBtn.Click += new System.EventHandler(this.LotaddBtn_Click);
            // 
            // LotGrid
            // 
            this.LotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotGrid.Location = new System.Drawing.Point(882, 232);
            this.LotGrid.Name = "LotGrid";
            this.LotGrid.RowHeadersVisible = false;
            this.LotGrid.RowHeadersWidth = 51;
            this.LotGrid.RowTemplate.Height = 27;
            this.LotGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LotGrid.Size = new System.Drawing.Size(652, 436);
            this.LotGrid.TabIndex = 20;
            // 
            // WoGrid
            // 
            this.WoGrid.AllowUserToAddRows = false;
            this.WoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WoGrid.Location = new System.Drawing.Point(25, 30);
            this.WoGrid.Name = "WoGrid";
            this.WoGrid.RowHeadersVisible = false;
            this.WoGrid.RowHeadersWidth = 51;
            this.WoGrid.RowTemplate.Height = 27;
            this.WoGrid.Size = new System.Drawing.Size(1509, 186);
            this.WoGrid.TabIndex = 19;
            // 
            // IM1_STBtn
            // 
            this.IM1_STBtn.Font = new System.Drawing.Font("나눔스퀘어", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_STBtn.Location = new System.Drawing.Point(232, 400);
            this.IM1_STBtn.Name = "IM1_STBtn";
            this.IM1_STBtn.Size = new System.Drawing.Size(120, 80);
            this.IM1_STBtn.TabIndex = 36;
            this.IM1_STBtn.Text = "1호사출시작";
            this.IM1_STBtn.UseVisualStyleBackColor = true;
            this.IM1_STBtn.Click += new System.EventHandler(this.IM1_STBtn_Click);
            // 
            // IM2_STBtn
            // 
            this.IM2_STBtn.Font = new System.Drawing.Font("나눔스퀘어", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_STBtn.Location = new System.Drawing.Point(352, 400);
            this.IM2_STBtn.Name = "IM2_STBtn";
            this.IM2_STBtn.Size = new System.Drawing.Size(120, 80);
            this.IM2_STBtn.TabIndex = 37;
            this.IM2_STBtn.Text = "2호사출시작";
            this.IM2_STBtn.UseVisualStyleBackColor = true;
            this.IM2_STBtn.Click += new System.EventHandler(this.IM2_STBtn_Click);
            // 
            // IM2_Label1
            // 
            this.IM2_Label1.AutoSize = true;
            this.IM2_Label1.BackColor = System.Drawing.Color.White;
            this.IM2_Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_Label1.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_Label1.Location = new System.Drawing.Point(272, 536);
            this.IM2_Label1.Name = "IM2_Label1";
            this.IM2_Label1.Size = new System.Drawing.Size(60, 29);
            this.IM2_Label1.TabIndex = 38;
            this.IM2_Label1.Text = "충전";
            // 
            // IM2_Label2
            // 
            this.IM2_Label2.AutoSize = true;
            this.IM2_Label2.BackColor = System.Drawing.Color.White;
            this.IM2_Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_Label2.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_Label2.Location = new System.Drawing.Point(328, 536);
            this.IM2_Label2.Name = "IM2_Label2";
            this.IM2_Label2.Size = new System.Drawing.Size(60, 29);
            this.IM2_Label2.TabIndex = 38;
            this.IM2_Label2.Text = "보압";
            // 
            // IM2_Label3
            // 
            this.IM2_Label3.AutoSize = true;
            this.IM2_Label3.BackColor = System.Drawing.Color.White;
            this.IM2_Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_Label3.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_Label3.Location = new System.Drawing.Point(384, 536);
            this.IM2_Label3.Name = "IM2_Label3";
            this.IM2_Label3.Size = new System.Drawing.Size(60, 29);
            this.IM2_Label3.TabIndex = 38;
            this.IM2_Label3.Text = "냉각";
            // 
            // IM2_Label4
            // 
            this.IM2_Label4.AutoSize = true;
            this.IM2_Label4.BackColor = System.Drawing.Color.White;
            this.IM2_Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_Label4.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_Label4.Location = new System.Drawing.Point(440, 536);
            this.IM2_Label4.Name = "IM2_Label4";
            this.IM2_Label4.Size = new System.Drawing.Size(60, 29);
            this.IM2_Label4.TabIndex = 38;
            this.IM2_Label4.Text = "취출";
            // 
            // IM1_Label1
            // 
            this.IM1_Label1.AutoSize = true;
            this.IM1_Label1.BackColor = System.Drawing.Color.White;
            this.IM1_Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_Label1.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_Label1.Location = new System.Drawing.Point(480, 312);
            this.IM1_Label1.Name = "IM1_Label1";
            this.IM1_Label1.Size = new System.Drawing.Size(60, 29);
            this.IM1_Label1.TabIndex = 38;
            this.IM1_Label1.Text = "충전";
            // 
            // IM1_Label2
            // 
            this.IM1_Label2.AutoSize = true;
            this.IM1_Label2.BackColor = System.Drawing.Color.White;
            this.IM1_Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_Label2.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_Label2.Location = new System.Drawing.Point(536, 312);
            this.IM1_Label2.Name = "IM1_Label2";
            this.IM1_Label2.Size = new System.Drawing.Size(60, 29);
            this.IM1_Label2.TabIndex = 38;
            this.IM1_Label2.Text = "보압";
            // 
            // IM1_Label3
            // 
            this.IM1_Label3.AutoSize = true;
            this.IM1_Label3.BackColor = System.Drawing.Color.White;
            this.IM1_Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_Label3.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_Label3.Location = new System.Drawing.Point(592, 312);
            this.IM1_Label3.Name = "IM1_Label3";
            this.IM1_Label3.Size = new System.Drawing.Size(60, 29);
            this.IM1_Label3.TabIndex = 38;
            this.IM1_Label3.Text = "냉각";
            // 
            // IM1_Label4
            // 
            this.IM1_Label4.AutoSize = true;
            this.IM1_Label4.BackColor = System.Drawing.Color.White;
            this.IM1_Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_Label4.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_Label4.Location = new System.Drawing.Point(648, 312);
            this.IM1_Label4.Name = "IM1_Label4";
            this.IM1_Label4.Size = new System.Drawing.Size(60, 29);
            this.IM1_Label4.TabIndex = 38;
            this.IM1_Label4.Text = "취출";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Blue;
            this.label9.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(496, 216);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 27);
            this.label9.TabIndex = 38;
            // 
            // IM2_ProdQty
            // 
            this.IM2_ProdQty.AutoSize = true;
            this.IM2_ProdQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.IM2_ProdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_ProdQty.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_ProdQty.Location = new System.Drawing.Point(272, 624);
            this.IM2_ProdQty.Name = "IM2_ProdQty";
            this.IM2_ProdQty.Size = new System.Drawing.Size(135, 29);
            this.IM2_ProdQty.TabIndex = 38;
            this.IM2_ProdQty.Text = "금일 생산량";
            // 
            // IM2_ProdQty_Value
            // 
            this.IM2_ProdQty_Value.AutoSize = true;
            this.IM2_ProdQty_Value.BackColor = System.Drawing.Color.White;
            this.IM2_ProdQty_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM2_ProdQty_Value.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM2_ProdQty_Value.Location = new System.Drawing.Point(400, 624);
            this.IM2_ProdQty_Value.Name = "IM2_ProdQty_Value";
            this.IM2_ProdQty_Value.Size = new System.Drawing.Size(45, 29);
            this.IM2_ProdQty_Value.TabIndex = 38;
            this.IM2_ProdQty_Value.Text = "EA";
            // 
            // IM1_ProdQty
            // 
            this.IM1_ProdQty.AutoSize = true;
            this.IM1_ProdQty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.IM1_ProdQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_ProdQty.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_ProdQty.Location = new System.Drawing.Point(480, 272);
            this.IM1_ProdQty.Name = "IM1_ProdQty";
            this.IM1_ProdQty.Size = new System.Drawing.Size(135, 29);
            this.IM1_ProdQty.TabIndex = 38;
            this.IM1_ProdQty.Text = "금일 생산량";
            // 
            // IM1_ProdQty_Value
            // 
            this.IM1_ProdQty_Value.AutoSize = true;
            this.IM1_ProdQty_Value.BackColor = System.Drawing.Color.White;
            this.IM1_ProdQty_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IM1_ProdQty_Value.Font = new System.Drawing.Font("나눔스퀘어", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IM1_ProdQty_Value.Location = new System.Drawing.Point(608, 272);
            this.IM1_ProdQty_Value.Name = "IM1_ProdQty_Value";
            this.IM1_ProdQty_Value.Size = new System.Drawing.Size(45, 29);
            this.IM1_ProdQty_Value.TabIndex = 38;
            this.IM1_ProdQty_Value.Text = "EA";
            // 
            // CurTime
            // 
            this.CurTime.AutoSize = true;
            this.CurTime.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CurTime.Location = new System.Drawing.Point(664, 744);
            this.CurTime.Name = "CurTime";
            this.CurTime.Size = new System.Drawing.Size(83, 25);
            this.CurTime.TabIndex = 39;
            this.CurTime.Text = "label1";
            // 
            // IM1
            // 
            this.IM1.Image = global::MESProject.Properties.Resources.사출111;
            this.IM1.Location = new System.Drawing.Point(504, 368);
            this.IM1.Name = "IM1";
            this.IM1.Size = new System.Drawing.Size(192, 136);
            this.IM1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IM1.TabIndex = 41;
            this.IM1.TabStop = false;
            // 
            // IM2
            // 
            this.IM2.Image = global::MESProject.Properties.Resources.사출21;
            this.IM2.Location = new System.Drawing.Point(504, 560);
            this.IM2.Name = "IM2";
            this.IM2.Size = new System.Drawing.Size(192, 136);
            this.IM2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IM2.TabIndex = 41;
            this.IM2.TabStop = false;
            // 
            // silo
            // 
            this.silo.Image = global::MESProject.Properties.Resources.silo0101;
            this.silo.Location = new System.Drawing.Point(120, 224);
            this.silo.Name = "silo";
            this.silo.Size = new System.Drawing.Size(88, 112);
            this.silo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.silo.TabIndex = 28;
            this.silo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::MESProject.Properties.Resources.통로;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(160, 320);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 272);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // Startworking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1552, 858);
            this.Controls.Add(this.IM1);
            this.Controls.Add(this.IM2);
            this.Controls.Add(this.CurTime);
            this.Controls.Add(this.IM1_ProdQty_Value);
            this.Controls.Add(this.IM2_ProdQty_Value);
            this.Controls.Add(this.IM1_Label4);
            this.Controls.Add(this.IM1_ProdQty);
            this.Controls.Add(this.IM2_ProdQty);
            this.Controls.Add(this.IM2_Label4);
            this.Controls.Add(this.IM1_Label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.IM2_Label3);
            this.Controls.Add(this.IM1_Label2);
            this.Controls.Add(this.IM1_Label1);
            this.Controls.Add(this.IM2_Label2);
            this.Controls.Add(this.IM2_Label1);
            this.Controls.Add(this.IM2_STBtn);
            this.Controls.Add(this.IM1_STBtn);
            this.Controls.Add(this.silo);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.FaultyBtn);
            this.Controls.Add(this.LotDelBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.LotaddBtn);
            this.Controls.Add(this.LotGrid);
            this.Controls.Add(this.WoGrid);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Startworking";
            this.Text = "sForm1";
            this.Load += new System.EventHandler(this.Startworking_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Login_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Login_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IM1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IM2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.Button FaultyBtn;
        private System.Windows.Forms.Button LotDelBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button LotaddBtn;
        private System.Windows.Forms.DataGridView LotGrid;
        private System.Windows.Forms.DataGridView WoGrid;
        private System.Windows.Forms.PictureBox silo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button IM1_STBtn;
        private System.Windows.Forms.Button IM2_STBtn;
        private System.Windows.Forms.Label IM2_Label1;
        private System.Windows.Forms.Label IM2_Label2;
        private System.Windows.Forms.Label IM2_Label3;
        private System.Windows.Forms.Label IM2_Label4;
        private System.Windows.Forms.Label IM1_Label1;
        private System.Windows.Forms.Label IM1_Label2;
        private System.Windows.Forms.Label IM1_Label3;
        private System.Windows.Forms.Label IM1_Label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label IM2_ProdQty;
        private System.Windows.Forms.Label IM2_ProdQty_Value;
        private System.Windows.Forms.Label IM1_ProdQty;
        private System.Windows.Forms.Label IM1_ProdQty_Value;
        private System.Windows.Forms.Label CurTime;
        private System.Windows.Forms.PictureBox IM2;
        private System.Windows.Forms.PictureBox IM1;
    }
}