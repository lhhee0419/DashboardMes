namespace MESProject
{
    partial class EquipmentID
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
            this.ExitBtn = new System.Windows.Forms.Button();
            this.CheckBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentGrid
            // 
            this.EquipmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentGrid.Location = new System.Drawing.Point(56, 64);
            this.EquipmentGrid.Name = "EquipmentGrid";
            this.EquipmentGrid.RowHeadersWidth = 51;
            this.EquipmentGrid.RowTemplate.Height = 27;
            this.EquipmentGrid.Size = new System.Drawing.Size(584, 352);
            this.EquipmentGrid.TabIndex = 0;
            this.EquipmentGrid.Click += new System.EventHandler(this.EquipmentGrid_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(464, 448);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(75, 40);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckBtn.Location = new System.Drawing.Point(184, 448);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(75, 40);
            this.CheckBtn.TabIndex = 1;
            this.CheckBtn.Text = "선택";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // EquipmentID
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(711, 534);
            this.Controls.Add(this.CheckBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.EquipmentGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EquipmentID";
            this.Text = "EPQTIDSelect";
            this.Load += new System.EventHandler(this.EquipmentID_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView EquipmentGrid;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button CheckBtn;
    }
}