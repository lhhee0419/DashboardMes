namespace MESProject
{
    partial class Stopworking
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
            this.SWF_REST = new System.Windows.Forms.RadioButton();
            this.SWF_ERROR = new System.Windows.Forms.RadioButton();
            this.SWF_CHECK = new System.Windows.Forms.RadioButton();
            this.SWF_MEAL = new System.Windows.Forms.RadioButton();
            this.SWF_ACCIDENT = new System.Windows.Forms.RadioButton();
            this.SWF_ETC = new System.Windows.Forms.RadioButton();
            this.CheckBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SWF_REST
            // 
            this.SWF_REST.AutoSize = true;
            this.SWF_REST.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_REST.Location = new System.Drawing.Point(72, 60);
            this.SWF_REST.Name = "SWF_REST";
            this.SWF_REST.Size = new System.Drawing.Size(154, 32);
            this.SWF_REST.TabIndex = 0;
            this.SWF_REST.Text = "쉬는 시간";
            this.SWF_REST.UseVisualStyleBackColor = true;
            this.SWF_REST.Click += new System.EventHandler(this.STW_RT_Click);
            // 
            // SWF_ERROR
            // 
            this.SWF_ERROR.AutoSize = true;
            this.SWF_ERROR.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_ERROR.Location = new System.Drawing.Point(72, 139);
            this.SWF_ERROR.Name = "SWF_ERROR";
            this.SWF_ERROR.Size = new System.Drawing.Size(145, 32);
            this.SWF_ERROR.TabIndex = 1;
            this.SWF_ERROR.Text = "설비오류";
            this.SWF_ERROR.UseVisualStyleBackColor = true;
            this.SWF_ERROR.Click += new System.EventHandler(this.SWF_ERROR_Click);
            // 
            // SWF_CHECK
            // 
            this.SWF_CHECK.AutoSize = true;
            this.SWF_CHECK.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_CHECK.Location = new System.Drawing.Point(72, 215);
            this.SWF_CHECK.Name = "SWF_CHECK";
            this.SWF_CHECK.Size = new System.Drawing.Size(145, 32);
            this.SWF_CHECK.TabIndex = 2;
            this.SWF_CHECK.Text = "설비점검";
            this.SWF_CHECK.UseVisualStyleBackColor = true;
            this.SWF_CHECK.Click += new System.EventHandler(this.SWF_CHECK_Click);
            // 
            // SWF_MEAL
            // 
            this.SWF_MEAL.AutoSize = true;
            this.SWF_MEAL.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_MEAL.Location = new System.Drawing.Point(336, 60);
            this.SWF_MEAL.Name = "SWF_MEAL";
            this.SWF_MEAL.Size = new System.Drawing.Size(154, 32);
            this.SWF_MEAL.TabIndex = 3;
            this.SWF_MEAL.Text = "식사 시간";
            this.SWF_MEAL.UseVisualStyleBackColor = true;
            this.SWF_MEAL.Click += new System.EventHandler(this.STW_MEAL_Click);
            // 
            // SWF_ACCIDENT
            // 
            this.SWF_ACCIDENT.AutoSize = true;
            this.SWF_ACCIDENT.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_ACCIDENT.Location = new System.Drawing.Point(336, 139);
            this.SWF_ACCIDENT.Name = "SWF_ACCIDENT";
            this.SWF_ACCIDENT.Size = new System.Drawing.Size(89, 32);
            this.SWF_ACCIDENT.TabIndex = 4;
            this.SWF_ACCIDENT.Text = "사고";
            this.SWF_ACCIDENT.UseVisualStyleBackColor = true;
            this.SWF_ACCIDENT.Click += new System.EventHandler(this.SWF_ACCIDENT_Click);
            // 
            // SWF_ETC
            // 
            this.SWF_ETC.AutoSize = true;
            this.SWF_ETC.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.SWF_ETC.Location = new System.Drawing.Point(336, 215);
            this.SWF_ETC.Name = "SWF_ETC";
            this.SWF_ETC.Size = new System.Drawing.Size(89, 32);
            this.SWF_ETC.TabIndex = 5;
            this.SWF_ETC.Text = "기타";
            this.SWF_ETC.UseVisualStyleBackColor = true;
            this.SWF_ETC.Click += new System.EventHandler(this.SWF_ETC_Click);
            // 
            // CheckBtn
            // 
            this.CheckBtn.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.CheckBtn.Location = new System.Drawing.Point(104, 349);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(140, 71);
            this.CheckBtn.TabIndex = 6;
            this.CheckBtn.Text = "확인";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // ExitBtn
            // 
            this.ExitBtn.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ExitBtn.Location = new System.Drawing.Point(368, 349);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(140, 71);
            this.ExitBtn.TabIndex = 7;
            this.ExitBtn.Text = "닫기";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SWF_ACCIDENT);
            this.groupBox1.Controls.Add(this.SWF_REST);
            this.groupBox1.Controls.Add(this.SWF_ERROR);
            this.groupBox1.Controls.Add(this.SWF_ETC);
            this.groupBox1.Controls.Add(this.SWF_CHECK);
            this.groupBox1.Controls.Add(this.SWF_MEAL);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(32, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 309);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "작업중지요인";
            // 
            // Stopworking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 432);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CheckBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Stopworking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stopworking";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stopworking_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Stopworking_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Stopworking_MouseUp);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton SWF_REST;
        private System.Windows.Forms.RadioButton SWF_ERROR;
        private System.Windows.Forms.RadioButton SWF_CHECK;
        private System.Windows.Forms.RadioButton SWF_MEAL;
        private System.Windows.Forms.RadioButton SWF_ACCIDENT;
        private System.Windows.Forms.RadioButton SWF_ETC;
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}