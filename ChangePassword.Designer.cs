namespace StudentManagementSystem
{
    partial class ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.id_in = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.password_in = new System.Windows.Forms.TextBox();
            this.a_check = new System.Windows.Forms.CheckBox();
            this.t_check = new System.Windows.Forms.CheckBox();
            this.s_check = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.password_in1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(293, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID: ";
            // 
            // id_in
            // 
            this.id_in.Location = new System.Drawing.Point(384, 55);
            this.id_in.Name = "id_in";
            this.id_in.Size = new System.Drawing.Size(208, 28);
            this.id_in.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "New Password: ";
            // 
            // password_in
            // 
            this.password_in.Location = new System.Drawing.Point(384, 111);
            this.password_in.Name = "password_in";
            this.password_in.Size = new System.Drawing.Size(208, 28);
            this.password_in.TabIndex = 3;
            // 
            // a_check
            // 
            this.a_check.AutoSize = true;
            this.a_check.BackColor = System.Drawing.Color.Transparent;
            this.a_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.a_check.Location = new System.Drawing.Point(500, 217);
            this.a_check.Name = "a_check";
            this.a_check.Size = new System.Drawing.Size(95, 29);
            this.a_check.TabIndex = 10;
            this.a_check.Text = "admin";
            this.a_check.UseVisualStyleBackColor = false;
            // 
            // t_check
            // 
            this.t_check.AutoSize = true;
            this.t_check.BackColor = System.Drawing.Color.Transparent;
            this.t_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_check.Location = new System.Drawing.Point(346, 217);
            this.t_check.Name = "t_check";
            this.t_check.Size = new System.Drawing.Size(105, 29);
            this.t_check.TabIndex = 9;
            this.t_check.Text = "teacher";
            this.t_check.UseVisualStyleBackColor = false;
            // 
            // s_check
            // 
            this.s_check.AutoSize = true;
            this.s_check.BackColor = System.Drawing.Color.Transparent;
            this.s_check.Font = new System.Drawing.Font("Cambria", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.s_check.Location = new System.Drawing.Point(187, 217);
            this.s_check.Name = "s_check";
            this.s_check.Size = new System.Drawing.Size(107, 29);
            this.s_check.TabIndex = 8;
            this.s_check.Text = "student";
            this.s_check.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(187, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(169, 45);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // password_in1
            // 
            this.password_in1.Location = new System.Drawing.Point(384, 167);
            this.password_in1.Name = "password_in1";
            this.password_in1.Size = new System.Drawing.Size(208, 28);
            this.password_in1.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "New Password Again: ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(384, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(169, 45);
            this.button2.TabIndex = 14;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(775, 375);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.password_in1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.a_check);
            this.Controls.Add(this.t_check);
            this.Controls.Add(this.s_check);
            this.Controls.Add(this.password_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.id_in);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangePassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox id_in;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password_in;
        private System.Windows.Forms.CheckBox a_check;
        private System.Windows.Forms.CheckBox t_check;
        private System.Windows.Forms.CheckBox s_check;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox password_in1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}