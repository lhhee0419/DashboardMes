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
            this.StockBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StockBtn.Location = new System.Drawing.Point(518, 350);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(137, 61);
            this.StockBtn.TabIndex = 27;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.FaultyBtn.Location = new System.Drawing.Point(372, 350);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(129, 61);
            this.FaultyBtn.TabIndex = 26;
            this.FaultyBtn.Text = "불량 등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotDelBtn.Location = new System.Drawing.Point(26, 426);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(127, 61);
            this.LotDelBtn.TabIndex = 25;
            this.LotDelBtn.Text = "LOT 삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.ExitBtn.Location = new System.Drawing.Point(518, 426);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(134, 56);
            this.ExitBtn.TabIndex = 24;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.EndBtn.Location = new System.Drawing.Point(179, 426);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(125, 61);
            this.EndBtn.TabIndex = 23;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StopBtn.Location = new System.Drawing.Point(178, 350);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(125, 61);
            this.StopBtn.TabIndex = 22;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotaddBtn.Location = new System.Drawing.Point(26, 350);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(127, 61);
            this.LotaddBtn.TabIndex = 21;
            this.LotaddBtn.Text = "LOT 추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            // 
            // LotGrid
            // 
            this.LotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotGrid.Location = new System.Drawing.Point(26, 164);
            this.LotGrid.Name = "LotGrid";
            this.LotGrid.RowHeadersWidth = 51;
            this.LotGrid.RowTemplate.Height = 27;
            this.LotGrid.Size = new System.Drawing.Size(632, 165);
            this.LotGrid.TabIndex = 20;
            // 
            // WoGrid
            // 
            this.WoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WoGrid.Location = new System.Drawing.Point(25, 30);
            this.WoGrid.Name = "WoGrid";
            this.WoGrid.RowHeadersWidth = 51;
            this.WoGrid.RowTemplate.Height = 27;
            this.WoGrid.Size = new System.Drawing.Size(630, 117);
            this.WoGrid.TabIndex = 19;
            // 
            // Startworking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1262, 977);
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