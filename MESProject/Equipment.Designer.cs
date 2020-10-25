namespace MESProject
{
    partial class Equipment
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
            this.EquipmentGrid = new System.Windows.Forms.DataGridView();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentGrid
            // 
            this.EquipmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentGrid.Location = new System.Drawing.Point(56, 40);
            this.EquipmentGrid.Name = "EquipmentGrid";
            this.EquipmentGrid.RowHeadersWidth = 51;
            this.EquipmentGrid.RowTemplate.Height = 27;
            this.EquipmentGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentGrid.Size = new System.Drawing.Size(496, 280);
            this.EquipmentGrid.TabIndex = 0;
            this.EquipmentGrid.Click += new System.EventHandler(this.EquipmentGrid_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckBtn.Location = new System.Drawing.Point(128, 360);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(112, 48);
            this.CheckBtn.TabIndex = 1;
            this.CheckBtn.Text = "확인";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(368, 360);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(112, 48);
            this.ExitBtn.TabIndex = 2;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // Equipment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.EquipmentGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Equipment";
            this.Text = "Equipment";
            this.Load += new System.EventHandler(this.Equipment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView EquipmentGrid;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ExitBtn;
    }
}