namespace VoiceCommandV2
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
            this.mute_chkbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // mute_chkbox
            // 
            this.mute_chkbox.AutoSize = true;
            this.mute_chkbox.Location = new System.Drawing.Point(12, 12);
            this.mute_chkbox.Name = "mute_chkbox";
            this.mute_chkbox.Size = new System.Drawing.Size(195, 21);
            this.mute_chkbox.TabIndex = 0;
            this.mute_chkbox.Text = "Disable Voice Recognition";
            this.mute_chkbox.UseVisualStyleBackColor = true;
            this.mute_chkbox.CheckedChanged += new System.EventHandler(this.mute_chkbox_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 45);
            this.Controls.Add(this.mute_chkbox);
            this.Name = "Form1";
            this.Text = " Voice Command";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox mute_chkbox;
    }
}

