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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lot));
            this.lotQtyLB = new System.Windows.Forms.Label();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.LotAdd_tb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lotQtyLB
            // 
            this.lotQtyLB.AutoSize = true;
            this.lotQtyLB.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 15F);
            this.lotQtyLB.Location = new System.Drawing.Point(58, 40);
            this.lotQtyLB.Name = "lotQtyLB";
            this.lotQtyLB.Size = new System.Drawing.Size(358, 27);
            this.lotQtyLB.TabIndex = 0;
            this.lotQtyLB.Text = "추가 할 LOT 수량을 입력해주세요";
            // 
            // AddBtn
            // 
            this.AddBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("AddBtn.BackgroundImage")));
            this.AddBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AddBtn.FlatAppearance.BorderSize = 0;
            this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddBtn.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.AddBtn.ForeColor = System.Drawing.Color.White;
            this.AddBtn.Location = new System.Drawing.Point(63, 189);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(127, 64);
            this.AddBtn.TabIndex = 1;
            this.AddBtn.Text = "추가";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            this.AddBtn.MouseLeave += new System.EventHandler(this.AddBtn_MouseLeave);
            this.AddBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddBtn_MouseMove);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ExitBtn.BackgroundImage")));
            this.ExitBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ExitBtn.FlatAppearance.BorderSize = 0;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("나눔스퀘어라운드 ExtraBold", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.ForeColor = System.Drawing.Color.White;
            this.ExitBtn.Location = new System.Drawing.Point(261, 189);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(127, 64);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.ExitBtn.MouseLeave += new System.EventHandler(this.ExitBtn_MouseLeave);
            this.ExitBtn.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ExitBtn_MouseMove);
            // 
            // LotAdd_tb
            // 
            this.LotAdd_tb.Font = new System.Drawing.Font("나눔스퀘어라운드 Bold", 16.2F);
            this.LotAdd_tb.Location = new System.Drawing.Point(137, 109);
            this.LotAdd_tb.Name = "LotAdd_tb";
            this.LotAdd_tb.Size = new System.Drawing.Size(189, 38);
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
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Lot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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