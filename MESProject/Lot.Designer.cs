namespace MESProject
{
    partial class Lot
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
            this.lotQtyLB = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotAdd_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lotQtyLB
            // 
            this.lotQtyLB.AutoSize = true;
            this.lotQtyLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lotQtyLB.Location = new System.Drawing.Point(58, 102);
            this.lotQtyLB.Name = "lotQtyLB";
            this.lotQtyLB.Size = new System.Drawing.Size(118, 29);
            this.lotQtyLB.TabIndex = 0;
            this.lotQtyLB.Text = "LOT 수량 :";
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.AddBtn.Location = new System.Drawing.Point(91, 189);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(99, 54);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "추가";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ExitBtn.Location = new System.Drawing.Point(261, 189);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(99, 54);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LotAdd_tb
            // 
            this.LotAdd_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.LotAdd_tb.Location = new System.Drawing.Point(196, 97);
            this.LotAdd_tb.Name = "LotAdd_tb";
            this.LotAdd_tb.Size = new System.Drawing.Size(190, 38);
            this.LotAdd_tb.TabIndex = 2;
            // 
            // Lot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 280);
            this.Controls.Add(this.LotAdd_tb);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.lotQtyLB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lot";
            this.Load += new System.EventHandler(this.Lot_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lotQtyLB;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox LotAdd_tb;
    }
}