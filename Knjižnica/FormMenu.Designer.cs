namespace Knjižnica
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.knjigaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.knjiznicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.članKnjižniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposlenikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.posudbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.knjigaToolStripMenuItem,
            this.knjiznicaToolStripMenuItem,
            this.članKnjižniceToolStripMenuItem,
            this.zaposlenikToolStripMenuItem,
            this.posudbeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(837, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // knjigaToolStripMenuItem
            // 
            this.knjigaToolStripMenuItem.Name = "knjigaToolStripMenuItem";
            this.knjigaToolStripMenuItem.Size = new System.Drawing.Size(72, 29);
            this.knjigaToolStripMenuItem.Text = "Knjiga";
            this.knjigaToolStripMenuItem.Click += new System.EventHandler(this.knjigaToolStripMenuItem_Click);
            // 
            // knjiznicaToolStripMenuItem
            // 
            this.knjiznicaToolStripMenuItem.Name = "knjiznicaToolStripMenuItem";
            this.knjiznicaToolStripMenuItem.Size = new System.Drawing.Size(91, 29);
            this.knjiznicaToolStripMenuItem.Text = "Knjižnica";
            this.knjiznicaToolStripMenuItem.Click += new System.EventHandler(this.knjiznicaToolStripMenuItem_Click);
            // 
            // članKnjižniceToolStripMenuItem
            // 
            this.članKnjižniceToolStripMenuItem.Name = "članKnjižniceToolStripMenuItem";
            this.članKnjižniceToolStripMenuItem.Size = new System.Drawing.Size(130, 29);
            this.članKnjižniceToolStripMenuItem.Text = "Član Knjižnice";
            this.članKnjižniceToolStripMenuItem.Click += new System.EventHandler(this.članKnjižniceToolStripMenuItem_Click);
            // 
            // zaposlenikToolStripMenuItem
            // 
            this.zaposlenikToolStripMenuItem.Name = "zaposlenikToolStripMenuItem";
            this.zaposlenikToolStripMenuItem.Size = new System.Drawing.Size(109, 29);
            this.zaposlenikToolStripMenuItem.Text = "Zaposlenik";
            this.zaposlenikToolStripMenuItem.Click += new System.EventHandler(this.zaposlenikToolStripMenuItem_Click);
            // 
            // posudbeToolStripMenuItem
            // 
            this.posudbeToolStripMenuItem.Name = "posudbeToolStripMenuItem";
            this.posudbeToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.posudbeToolStripMenuItem.Text = "Posudbe";
            this.posudbeToolStripMenuItem.Click += new System.EventHandler(this.posudbeToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 449);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormMenu";
            this.Text = "Knjižnica";
            this.Shown += new System.EventHandler(this.FormMenu_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem knjigaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem knjiznicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem članKnjižniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zaposlenikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem posudbeToolStripMenuItem;
    }
}