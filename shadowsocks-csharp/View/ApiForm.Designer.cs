namespace Shadowsocks.View
{
    partial class ApiForm
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.progressBarLogin = new System.Windows.Forms.ProgressBar();
            this.buttonProgressCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(203, 26);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(281, 25);
            this.textBoxEmail.TabIndex = 0;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Location = new System.Drawing.Point(203, 111);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(281, 25);
            this.textBoxPass.TabIndex = 1;
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("宋体", 10F);
            this.buttonSave.Location = new System.Drawing.Point(47, 176);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(120, 44);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("宋体", 10F);
            this.labelEmail.Location = new System.Drawing.Point(44, 27);
            this.labelEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(89, 17);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Api_Email";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("宋体", 10F);
            this.labelPass.Location = new System.Drawing.Point(44, 111);
            this.labelPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(116, 17);
            this.labelPass.TabIndex = 5;
            this.labelPass.Text = "Api_Password";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("宋体", 10F);
            this.buttonCancel.Location = new System.Drawing.Point(371, 176);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(113, 44);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(177, 113);
            this.checkBox5.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(18, 17);
            this.checkBox5.TabIndex = 12;
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // progressBarLogin
            // 
            this.progressBarLogin.Location = new System.Drawing.Point(47, 264);
            this.progressBarLogin.Name = "progressBarLogin";
            this.progressBarLogin.Size = new System.Drawing.Size(328, 23);
            this.progressBarLogin.TabIndex = 13;
            this.progressBarLogin.Visible = false;
            // 
            // buttonProgressCancel
            // 
            this.buttonProgressCancel.Location = new System.Drawing.Point(409, 264);
            this.buttonProgressCancel.Name = "buttonProgressCancel";
            this.buttonProgressCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonProgressCancel.TabIndex = 14;
            this.buttonProgressCancel.Text = "stop";
            this.buttonProgressCancel.UseVisualStyleBackColor = true;
            this.buttonProgressCancel.Visible = false;
            this.buttonProgressCancel.Click += new System.EventHandler(this.buttonProgressCancel_Click);
            // 
            // ApiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 370);
            this.Controls.Add(this.buttonProgressCancel);
            this.Controls.Add(this.progressBarLogin);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelPass);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxEmail);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ApiForm";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPass;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.ProgressBar progressBarLogin;
        private System.Windows.Forms.Button buttonProgressCancel;
    }
}