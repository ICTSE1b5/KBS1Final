namespace KBS1.view
{
    partial class OptionsMenu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox_Statistics = new System.Windows.Forms.CheckBox();
            this.checkBox_Music = new System.Windows.Forms.CheckBox();
            this.button_Return = new System.Windows.Forms.Button();
            this.soundeffects = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox_Statistics
            // 
            this.checkBox_Statistics.AutoSize = true;
            this.checkBox_Statistics.Location = new System.Drawing.Point(36, 35);
            this.checkBox_Statistics.Name = "checkBox_Statistics";
            this.checkBox_Statistics.Size = new System.Drawing.Size(107, 17);
            this.checkBox_Statistics.TabIndex = 0;
            this.checkBox_Statistics.Text = "In game statistics";
            this.checkBox_Statistics.UseVisualStyleBackColor = true;
            this.checkBox_Statistics.CheckedChanged += new System.EventHandler(this.CheckBox_Statistics_CheckedChanged);
            // 
            // checkBox_Music
            // 
            this.checkBox_Music.AutoSize = true;
            this.checkBox_Music.Location = new System.Drawing.Point(36, 59);
            this.checkBox_Music.Name = "checkBox_Music";
            this.checkBox_Music.Size = new System.Drawing.Size(54, 17);
            this.checkBox_Music.TabIndex = 1;
            this.checkBox_Music.Text = "Music";
            this.checkBox_Music.UseVisualStyleBackColor = true;
            this.checkBox_Music.CheckedChanged += new System.EventHandler(this.CheckBox_Music_CheckedChanged);
            // 
            // button_Return
            // 
            this.button_Return.Location = new System.Drawing.Point(36, 188);
            this.button_Return.Name = "button_Return";
            this.button_Return.Size = new System.Drawing.Size(77, 26);
            this.button_Return.TabIndex = 2;
            this.button_Return.Text = "Return";
            this.button_Return.UseVisualStyleBackColor = true;
            this.button_Return.Click += new System.EventHandler(this.button_Return_Click);
            // 
            // soundeffects
            // 
            this.soundeffects.AutoSize = true;
            this.soundeffects.Location = new System.Drawing.Point(36, 83);
            this.soundeffects.Name = "soundeffects";
            this.soundeffects.Size = new System.Drawing.Size(89, 17);
            this.soundeffects.TabIndex = 3;
            this.soundeffects.Text = "Soundeffects";
            this.soundeffects.UseVisualStyleBackColor = true;
            // 
            // OptionsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.soundeffects);
            this.Controls.Add(this.button_Return);
            this.Controls.Add(this.checkBox_Music);
            this.Controls.Add(this.checkBox_Statistics);
            this.Name = "OptionsMenu";
            this.Size = new System.Drawing.Size(457, 239);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Statistics;
        private System.Windows.Forms.CheckBox checkBox_Music;
        private System.Windows.Forms.Button button_Return;
        private System.Windows.Forms.CheckBox soundeffects;
    }
}
