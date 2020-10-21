namespace MESProject
{
    partial class MaterialStock
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
            this.ExitBtn = new System.Windows.Forms.Button();
            this.MtrlGrid1 = new System.Windows.Forms.DataGridView();
            this.silo1 = new System.Windows.Forms.PictureBox();
            this.silo2 = new System.Windows.Forms.PictureBox();
            this.MtrlGrid2 = new System.Windows.Forms.DataGridView();
            this.silo3 = new System.Windows.Forms.PictureBox();
            this.MtrlGrid3 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid3)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(375, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "원재료 재고 조회";
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 15F);
            this.ExitBtn.Location = new System.Drawing.Point(869, 574);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(110, 60);
            this.ExitBtn.TabIndex = 3;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // MtrlGrid1
            // 
            this.MtrlGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MtrlGrid1.Location = new System.Drawing.Point(42, 367);
            this.MtrlGrid1.Name = "MtrlGrid1";
            this.MtrlGrid1.RowHeadersWidth = 51;
            this.MtrlGrid1.RowTemplate.Height = 27;
            this.MtrlGrid1.Size = new System.Drawing.Size(240, 183);
            this.MtrlGrid1.TabIndex = 4;
            // 
            // silo1
            // 
            this.silo1.Location = new System.Drawing.Point(42, 93);
            this.silo1.Name = "silo1";
            this.silo1.Size = new System.Drawing.Size(240, 250);
            this.silo1.TabIndex = 5;
            this.silo1.TabStop = false;
            // 
            // silo2
            // 
            this.silo2.Location = new System.Drawing.Point(360, 93);
            this.silo2.Name = "silo2";
            this.silo2.Size = new System.Drawing.Size(240, 250);
            this.silo2.TabIndex = 7;
            this.silo2.TabStop = false;
            // 
            // MtrlGrid2
            // 
            this.MtrlGrid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MtrlGrid2.Location = new System.Drawing.Point(360, 367);
            this.MtrlGrid2.Name = "MtrlGrid2";
            this.MtrlGrid2.RowHeadersWidth = 51;
            this.MtrlGrid2.RowTemplate.Height = 27;
            this.MtrlGrid2.Size = new System.Drawing.Size(240, 183);
            this.MtrlGrid2.TabIndex = 6;
            // 
            // silo3
            // 
            this.silo3.Location = new System.Drawing.Point(678, 93);
            this.silo3.Name = "silo3";
            this.silo3.Size = new System.Drawing.Size(240, 250);
            this.silo3.TabIndex = 9;
            this.silo3.TabStop = false;
            // 
            // MtrlGrid3
            // 
            this.MtrlGrid3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MtrlGrid3.Location = new System.Drawing.Point(678, 367);
            this.MtrlGrid3.Name = "MtrlGrid3";
            this.MtrlGrid3.RowHeadersWidth = 51;
            this.MtrlGrid3.RowTemplate.Height = 27;
            this.MtrlGrid3.Size = new System.Drawing.Size(240, 183);
            this.MtrlGrid3.TabIndex = 8;
            // 
            // MaterialStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 646);
            this.Controls.Add(this.silo3);
            this.Controls.Add(this.MtrlGrid3);
            this.Controls.Add(this.silo2);
            this.Controls.Add(this.MtrlGrid2);
            this.Controls.Add(this.silo1);
            this.Controls.Add(this.MtrlGrid1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MaterialStock";
            this.Text = "MaterialStock";
            this.Load += new System.EventHandler(this.MaterialStock_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MaterialStock_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MaterialStock_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.silo3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MtrlGrid3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.DataGridView MtrlGrid1;
        private System.Windows.Forms.PictureBox silo1;
        private System.Windows.Forms.PictureBox silo2;
        private System.Windows.Forms.DataGridView MtrlGrid2;
        private System.Windows.Forms.PictureBox silo3;
        private System.Windows.Forms.DataGridView MtrlGrid3;
    }
}