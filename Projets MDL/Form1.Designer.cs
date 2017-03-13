namespace Projets_MDL
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MDL = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clubsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adherentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evènementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MDL
            // 
            this.MDL.AutoSize = true;
            this.MDL.Font = new System.Drawing.Font("Corbel", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDL.Location = new System.Drawing.Point(166, 52);
            this.MDL.Name = "MDL";
            this.MDL.Size = new System.Drawing.Size(248, 23);
            this.MDL.TabIndex = 2;
            this.MDL.Text = "La Maison de ligue de lorarine";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Projets_MDL.Properties.Resources.Letter_L_icon1;
            this.pictureBox3.Location = new System.Drawing.Point(412, 137);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(129, 129);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Projets_MDL.Properties.Resources.Letter_D_icon;
            this.pictureBox2.Location = new System.Drawing.Point(216, 137);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(132, 129);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Projets_MDL.Properties.Resources.Letter_M_icon1;
            this.pictureBox1.Location = new System.Drawing.Point(26, 137);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 129);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clubsToolStripMenuItem,
            this.adherentsToolStripMenuItem,
            this.evènementsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(571, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clubsToolStripMenuItem
            // 
            this.clubsToolStripMenuItem.Name = "clubsToolStripMenuItem";
            this.clubsToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.clubsToolStripMenuItem.Text = "Clubs";
            this.clubsToolStripMenuItem.Click += new System.EventHandler(this.clubsToolStripMenuItem_Click);
            // 
            // adherentsToolStripMenuItem
            // 
            this.adherentsToolStripMenuItem.Name = "adherentsToolStripMenuItem";
            this.adherentsToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.adherentsToolStripMenuItem.Text = "Adhérents";
            this.adherentsToolStripMenuItem.Click += new System.EventHandler(this.adherentsToolStripMenuItem_Click);
            // 
            // evènementsToolStripMenuItem
            // 
            this.evènementsToolStripMenuItem.Name = "evènementsToolStripMenuItem";
            this.evènementsToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.evènementsToolStripMenuItem.Text = "Evènements";
            this.evènementsToolStripMenuItem.Click += new System.EventHandler(this.evènementsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 363);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MDL);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label MDL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clubsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adherentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evènementsToolStripMenuItem;
    }
}

