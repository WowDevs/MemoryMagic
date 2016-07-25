namespace MemoryMagic
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.cmdDance = new System.Windows.Forms.Button();
            this.cmdShoot = new System.Windows.Forms.Button();
            this.cmdSmite = new System.Windows.Forms.Button();
            this.cmdMyName = new System.Windows.Forms.Button();
            this.cmdMyZone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(3, 3);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(628, 432);
            this.LogTextBox.TabIndex = 1;
            this.LogTextBox.Text = "";
            // 
            // cmdLogin
            // 
            this.cmdLogin.Location = new System.Drawing.Point(634, 3);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(70, 25);
            this.cmdLogin.TabIndex = 8;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.UseVisualStyleBackColor = true;
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // cmdDance
            // 
            this.cmdDance.Location = new System.Drawing.Point(634, 31);
            this.cmdDance.Name = "cmdDance";
            this.cmdDance.Size = new System.Drawing.Size(70, 25);
            this.cmdDance.TabIndex = 9;
            this.cmdDance.Text = "Dance";
            this.cmdDance.UseVisualStyleBackColor = true;
            this.cmdDance.Click += new System.EventHandler(this.cmdDance_Click);
            // 
            // cmdShoot
            // 
            this.cmdShoot.Location = new System.Drawing.Point(634, 59);
            this.cmdShoot.Name = "cmdShoot";
            this.cmdShoot.Size = new System.Drawing.Size(70, 25);
            this.cmdShoot.TabIndex = 10;
            this.cmdShoot.Text = "Shoot";
            this.cmdShoot.UseVisualStyleBackColor = true;
            this.cmdShoot.Click += new System.EventHandler(this.cmdShoot_Click);
            // 
            // cmdSmite
            // 
            this.cmdSmite.Location = new System.Drawing.Point(634, 86);
            this.cmdSmite.Name = "cmdSmite";
            this.cmdSmite.Size = new System.Drawing.Size(70, 25);
            this.cmdSmite.TabIndex = 11;
            this.cmdSmite.Text = "Smite";
            this.cmdSmite.UseVisualStyleBackColor = true;
            this.cmdSmite.Click += new System.EventHandler(this.cmdSmite_Click);
            // 
            // cmdMyName
            // 
            this.cmdMyName.Location = new System.Drawing.Point(634, 112);
            this.cmdMyName.Name = "cmdMyName";
            this.cmdMyName.Size = new System.Drawing.Size(70, 25);
            this.cmdMyName.TabIndex = 12;
            this.cmdMyName.Text = "My Name";
            this.cmdMyName.UseVisualStyleBackColor = true;
            this.cmdMyName.Click += new System.EventHandler(this.cmdMyName_Click);
            // 
            // cmdMyZone
            // 
            this.cmdMyZone.Location = new System.Drawing.Point(634, 138);
            this.cmdMyZone.Name = "cmdMyZone";
            this.cmdMyZone.Size = new System.Drawing.Size(70, 25);
            this.cmdMyZone.TabIndex = 13;
            this.cmdMyZone.Text = "Zone";
            this.cmdMyZone.UseVisualStyleBackColor = true;
            this.cmdMyZone.Click += new System.EventHandler(this.cmdMyZone_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 437);
            this.Controls.Add(this.cmdMyZone);
            this.Controls.Add(this.cmdMyName);
            this.Controls.Add(this.cmdSmite);
            this.Controls.Add(this.cmdShoot);
            this.Controls.Add(this.cmdDance);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.LogTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Button cmdDance;
        private System.Windows.Forms.Button cmdShoot;
        private System.Windows.Forms.Button cmdSmite;
        private System.Windows.Forms.Button cmdMyName;
        private System.Windows.Forms.Button cmdMyZone;
    }
}

