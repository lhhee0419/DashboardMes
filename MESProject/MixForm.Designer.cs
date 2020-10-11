namespace MESProject
{
    partial class MixForm
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // StockBtn
            // 
            this.StockBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StockBtn.Location = new System.Drawing.Point(514, 346);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(137, 61);
            this.StockBtn.TabIndex = 18;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.FaultyBtn.Location = new System.Drawing.Point(368, 346);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(129, 61);
            this.FaultyBtn.TabIndex = 17;
            this.FaultyBtn.Text = "불량 등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotDelBtn.Location = new System.Drawing.Point(22, 422);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(127, 61);
            this.LotDelBtn.TabIndex = 16;
            this.LotDelBtn.Text = "LOT 삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.ExitBtn.Location = new System.Drawing.Point(514, 422);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(134, 56);
            this.ExitBtn.TabIndex = 15;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            // 
            // EndBtn
            // 
            this.EndBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.EndBtn.Location = new System.Drawing.Point(175, 422);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(125, 61);
            this.EndBtn.TabIndex = 14;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.StopBtn.Location = new System.Drawing.Point(174, 346);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(125, 61);
            this.StopBtn.TabIndex = 13;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Font = new System.Drawing.Font("굴림", 13F);
            this.LotaddBtn.Location = new System.Drawing.Point(22, 346);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(127, 61);
            this.LotaddBtn.TabIndex = 12;
            this.LotaddBtn.Text = "LOT 추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(22, 160);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(632, 165);
            this.dataGridView2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 26);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(630, 117);
            this.dataGridView1.TabIndex = 10;
            // 
            // MixForm
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
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MixForm";
            this.Text = "bForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}