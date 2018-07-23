namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.user_input = new System.Windows.Forms.TextBox();
            this.password_input = new System.Windows.Forms.TextBox();
            this.s_check = new System.Windows.Forms.CheckBox();
            this.t_check = new System.Windows.Forms.CheckBox();
            this.a_check = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(64, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(714, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Management System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(212, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 33);
            this.label2.TabIndex = 1;
            this.label2.Text = "user:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(212, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 33);
            this.label3.TabIndex = 2;
            this.label3.Text = "password:";
            // 
            // user_input
            // 
            this.user_input.Location = new System.Drawing.Point(377, 147);
            this.user_input.Name = "user_input";
            this.user_input.Size = new System.Drawing.Size(179, 28);
            this.user_input.TabIndex = 3;
            // 
            // password_input
            // 
            this.password_input.Location = new System.Drawing.Point(377, 222);
            this.password_input.Name = "password_input";
            this.password_input.Size = new System.Drawing.Size(179, 28);
            this.password_input.TabIndex = 4;
            this.password_input.UseSystemPasswordChar = true;
            // 
            // s_check
            // 
            this.s_check.AutoSize = true;
            this.s_check.BackColor = System.Drawing.Color.Transparent;
            this.s_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s_check.Location = new System.Drawing.Point(218, 285);
            this.s_check.Name = "s_check";
            this.s_check.Size = new System.Drawing.Size(107, 29);
            this.s_check.TabIndex = 5;
            this.s_check.Text = "student";
            this.s_check.UseVisualStyleBackColor = false;
            // 
            // t_check
            // 
            this.t_check.AutoSize = true;
            this.t_check.BackColor = System.Drawing.Color.Transparent;
            this.t_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_check.Location = new System.Drawing.Point(377, 285);
            this.t_check.Name = "t_check";
            this.t_check.Size = new System.Drawing.Size(105, 29);
            this.t_check.TabIndex = 6;
            this.t_check.Text = "teacher";
            this.t_check.UseVisualStyleBackColor = false;
            // 
            // a_check
            // 
            this.a_check.AutoSize = true;
            this.a_check.BackColor = System.Drawing.Color.Transparent;
            this.a_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a_check.Location = new System.Drawing.Point(525, 285);
            this.a_check.Name = "a_check";
            this.a_check.Size = new System.Drawing.Size(95, 29);
            this.a_check.TabIndex = 7;
            this.a_check.Text = "admin";
            this.a_check.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(340, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 61);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(562, 225);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(171, 25);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Change Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(865, 474);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.a_check);
            this.Controls.Add(this.t_check);
            this.Controls.Add(this.s_check);
            this.Controls.Add(this.password_input);
            this.Controls.Add(this.user_input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox user_input;
        private System.Windows.Forms.TextBox password_input;
        private System.Windows.Forms.CheckBox s_check;
        private System.Windows.Forms.CheckBox t_check;
        private System.Windows.Forms.CheckBox a_check;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

