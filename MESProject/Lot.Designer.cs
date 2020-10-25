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
            this.label1 = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotAdd_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(56, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOT 수량";
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddBtn.Location = new System.Drawing.Point(112, 176);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(94, 47);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "추가";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(240, 176);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(94, 47);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // LotAdd_tb
            // 
            this.LotAdd_tb.Location = new System.Drawing.Point(192, 96);
            this.LotAdd_tb.Name = "LotAdd_tb";
            this.LotAdd_tb.Size = new System.Drawing.Size(136, 25);
            this.LotAdd_tb.TabIndex = 2;
            // 
            // Lot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(382, 253);
            this.Controls.Add(this.LotAdd_tb);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Lot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Lot_FormClosing);
            this.Load += new System.EventHandler(this.Lot_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Lot_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox LotAdd_tb;
    }
}