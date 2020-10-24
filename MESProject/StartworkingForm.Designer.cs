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
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // StockBtn
            // 
            this.StockBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.StockBtn.Location = new System.Drawing.Point(1312, 588);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(222, 97);
            this.StockBtn.TabIndex = 27;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            this.StockBtn.Click += new System.EventHandler(this.StockBtn_Click);
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.FaultyBtn.Location = new System.Drawing.Point(1008, 588);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(222, 97);
            this.FaultyBtn.TabIndex = 26;
            this.FaultyBtn.Text = "불량 등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
            this.FaultyBtn.Click += new System.EventHandler(this.FaultyBtn_Click);
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.LotDelBtn.Location = new System.Drawing.Point(25, 588);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(222, 97);
            this.LotDelBtn.TabIndex = 25;
            this.LotDelBtn.Text = "LOT 삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            this.LotDelBtn.Click += new System.EventHandler(this.LotDelBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.ExitBtn.Location = new System.Drawing.Point(1312, 707);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(222, 97);
            this.ExitBtn.TabIndex = 24;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.EndBtn.Location = new System.Drawing.Point(334, 707);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(222, 97);
            this.EndBtn.TabIndex = 23;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            this.EndBtn.Click += new System.EventHandler(this.EndBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F);
            this.StopBtn.Location = new System.Drawing.Point(334, 588);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(222, 97);
            this.StopBtn.TabIndex = 22;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Font = new System.Drawing.Font("문체부 돋음체", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LotaddBtn.Location = new System.Drawing.Point(25, 707);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(222, 97);
            this.LotaddBtn.TabIndex = 21;
            this.LotaddBtn.Text = "LOT 추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            this.LotaddBtn.Click += new System.EventHandler(this.LotaddBtn_Click);
            // 
            // LotGrid
            // 
            this.LotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotGrid.Location = new System.Drawing.Point(25, 215);
            this.LotGrid.Name = "LotGrid";
            this.LotGrid.RowHeadersVisible = false;
            this.LotGrid.RowHeadersWidth = 51;
            this.LotGrid.RowTemplate.Height = 27;
            this.LotGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LotGrid.Size = new System.Drawing.Size(1509, 355);
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
            this.WoGrid.Size = new System.Drawing.Size(1509, 154);
            this.WoGrid.TabIndex = 19;
            // 
            // Startworking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1552, 858);
            this.Controls.Add(this.StockBtn);
            this.Controls.Add(this.FaultyBtn);
            this.Controls.Add(this.LotDelBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.EndBtn);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.LotaddBtn);
            this.Controls.Add(this.LotGrid);
            this.Controls.Add(this.WoGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Startworking";
            this.Text = "sForm1";
            this.Load += new System.EventHandler(this.Startworking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).EndInit();
            this.ResumeLayout(false);

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
    }
}