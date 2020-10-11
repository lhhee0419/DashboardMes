namespace MESProject
{
    partial class InjectionForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.LotaddBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.EndBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotDelBtn = new System.Windows.Forms.Button();
            this.StockBtn = new System.Windows.Forms.Button();
            this.FaultyBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 45);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(714, 145);
            this.dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(26, 217);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(714, 145);
            this.dataGridView2.TabIndex = 1;
            // 
            // LotaddBtn
            // 
            this.LotaddBtn.Location = new System.Drawing.Point(26, 392);
            this.LotaddBtn.Name = "LotaddBtn";
            this.LotaddBtn.Size = new System.Drawing.Size(108, 52);
            this.LotaddBtn.TabIndex = 2;
            this.LotaddBtn.Text = "LOT 추가";
            this.LotaddBtn.UseVisualStyleBackColor = true;
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(166, 392);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(108, 52);
            this.StopBtn.TabIndex = 4;
            this.StopBtn.Text = "작업중지/재시작";
            this.StopBtn.UseVisualStyleBackColor = true;
            // 
            // EndBtn
            // 
            this.EndBtn.Location = new System.Drawing.Point(166, 466);
            this.EndBtn.Name = "EndBtn";
            this.EndBtn.Size = new System.Drawing.Size(108, 52);
            this.EndBtn.TabIndex = 5;
            this.EndBtn.Text = "작업종료";
            this.EndBtn.UseVisualStyleBackColor = true;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(632, 466);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(108, 52);
            this.ExitBtn.TabIndex = 6;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            // 
            // LotDelBtn
            // 
            this.LotDelBtn.Location = new System.Drawing.Point(26, 466);
            this.LotDelBtn.Name = "LotDelBtn";
            this.LotDelBtn.Size = new System.Drawing.Size(108, 52);
            this.LotDelBtn.TabIndex = 7;
            this.LotDelBtn.Text = "LOT 삭제";
            this.LotDelBtn.UseVisualStyleBackColor = true;
            // 
            // StockBtn
            // 
            this.StockBtn.Location = new System.Drawing.Point(632, 392);
            this.StockBtn.Name = "StockBtn";
            this.StockBtn.Size = new System.Drawing.Size(108, 52);
            this.StockBtn.TabIndex = 9;
            this.StockBtn.Text = "원재료 재고조회";
            this.StockBtn.UseVisualStyleBackColor = true;
            // 
            // FaultyBtn
            // 
            this.FaultyBtn.Location = new System.Drawing.Point(492, 392);
            this.FaultyBtn.Name = "FaultyBtn";
            this.FaultyBtn.Size = new System.Drawing.Size(108, 52);
            this.FaultyBtn.TabIndex = 8;
            this.FaultyBtn.Text = "불량 등록";
            this.FaultyBtn.UseVisualStyleBackColor = true;
            // 
            // InjectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.Name = "InjectionForm";
            this.Text = "sForm1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button LotaddBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button EndBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button LotDelBtn;
        private System.Windows.Forms.Button StockBtn;
        private System.Windows.Forms.Button FaultyBtn;
    }
}