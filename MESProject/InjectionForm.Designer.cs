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
            this.WoGrid = new System.Windows.Forms.DataGridView();
            this.LotGrid = new System.Windows.Forms.DataGridView();
            this.LotaddBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotDelBtn = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.FaultyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // WoGrid
            // 
            this.WoGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.WoGrid.Location = new System.Drawing.Point(27, 23);
            this.WoGrid.Name = "WoGrid";
            this.WoGrid.RowHeadersWidth = 51;
            this.WoGrid.RowTemplate.Height = 27;
            this.WoGrid.Size = new System.Drawing.Size(630, 117);
            this.WoGrid.TabIndex = 0;
            // 
            // LotGrid
            // 
            this.LotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LotGrid.Location = new System.Drawing.Point(28, 157);
            this.LotGrid.Name = "LotGrid";
            this.LotGrid.RowHeadersWidth = 51;
            this.LotGrid.RowTemplate.Height = 27;
            this.LotGrid.Size = new System.Drawing.Size(632, 165);
            this.LotGrid.TabIndex = 1;
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotaddBtn.Location = new System.Drawing.Point(28, 343);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(127, 61);
            this.LotaddBtn.TabIndex = 2;
            this.LotaddBtn.Text = "LOT 추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StopBtn.Location = new System.Drawing.Point(180, 343);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(125, 61);
            this.StopBtn.TabIndex = 4;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.EndBtn.Location = new System.Drawing.Point(181, 419);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(125, 61);
            this.EndBtn.TabIndex = 5;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.ExitBtn.Location = new System.Drawing.Point(520, 419);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(134, 56);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotDelBtn.Location = new System.Drawing.Point(28, 419);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(127, 61);
            this.LotDelBtn.TabIndex = 7;
            this.LotDelBtn.Text = "LOT 삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            // 
            // StockBtn
            // 
            this.StockBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StockBtn.Location = new System.Drawing.Point(520, 343);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(137, 61);
            this.StockBtn.TabIndex = 9;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.FaultyBtn.Location = new System.Drawing.Point(374, 343);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(129, 61);
            this.FaultyBtn.TabIndex = 8;
            this.FaultyBtn.Text = "불량 등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.WoGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LotGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView WoGrid;
        private System.Windows.Forms.DataGridView LotGrid;
        private System.Windows.Forms.Button LotaddBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button LotDelBtn;
        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.Button FaultyBtn;
    }
}