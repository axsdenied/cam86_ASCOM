namespace ASCOM.cam86
{
    partial class FormAbout
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
            this.richTextBoxAbout = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxAbout
            // 
            this.richTextBoxAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxAbout.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxAbout.Name = "richTextBoxAbout";
            this.richTextBoxAbout.ReadOnly = true;
            this.richTextBoxAbout.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxAbout.Size = new System.Drawing.Size(593, 357);
            this.richTextBoxAbout.TabIndex = 2;
            this.richTextBoxAbout.Text = "";
            this.richTextBoxAbout.ContentsResized += new System.Windows.Forms.ContentsResizedEventHandler(this.richTextBoxAbout_ContentsResized);
            this.richTextBoxAbout.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBoxAbout_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.richTextBoxAbout);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(593, 357);
            this.panel1.TabIndex = 3;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(618, 379);
            this.Controls.Add(this.panel1);
            this.Name = "FormAbout";
            this.Text = "About";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxAbout;
        private System.Windows.Forms.Panel panel1;
    }
}