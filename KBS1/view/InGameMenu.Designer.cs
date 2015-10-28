namespace KBS1.view
{
    partial class InGameMenu
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
            this.button_Main_Menu = new System.Windows.Forms.Button();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Resume = new System.Windows.Forms.Button();
            this.button_Options = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Main_Menu
            // 
            this.button_Main_Menu.BackColor = System.Drawing.SystemColors.Control;
            this.button_Main_Menu.Location = new System.Drawing.Point(34, 33);
            this.button_Main_Menu.Name = "button_Main_Menu";
            this.button_Main_Menu.Size = new System.Drawing.Size(135, 39);
            this.button_Main_Menu.TabIndex = 0;
            this.button_Main_Menu.Text = "Main menu";
            this.button_Main_Menu.UseVisualStyleBackColor = false;
            this.button_Main_Menu.Click += new System.EventHandler(this.Button_Main_Menu_Click);
            // 
            // button_Close
            // 
            this.button_Close.BackColor = System.Drawing.SystemColors.Control;
            this.button_Close.Location = new System.Drawing.Point(34, 168);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(135, 39);
            this.button_Close.TabIndex = 3;
            this.button_Close.Text = "Close";
            this.button_Close.UseVisualStyleBackColor = false;
            this.button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // button_Resume
            // 
            this.button_Resume.BackColor = System.Drawing.SystemColors.Control;
            this.button_Resume.Location = new System.Drawing.Point(34, 78);
            this.button_Resume.Name = "button_Resume";
            this.button_Resume.Size = new System.Drawing.Size(135, 39);
            this.button_Resume.TabIndex = 4;
            this.button_Resume.Text = "Resume";
            this.button_Resume.UseVisualStyleBackColor = false;
            this.button_Resume.Click += new System.EventHandler(this.button_Resume_Click);
            // 
            // button_Options
            // 
            this.button_Options.BackColor = System.Drawing.SystemColors.Control;
            this.button_Options.Location = new System.Drawing.Point(34, 123);
            this.button_Options.Name = "button_Options";
            this.button_Options.Size = new System.Drawing.Size(135, 39);
            this.button_Options.TabIndex = 5;
            this.button_Options.Text = "Options";
            this.button_Options.UseVisualStyleBackColor = false;
            this.button_Options.Click += new System.EventHandler(this.Button_Options_Click);
            // 
            // InGameMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.button_Options);
            this.Controls.Add(this.button_Resume);
            this.Controls.Add(this.button_Close);
            this.Controls.Add(this.button_Main_Menu);
            this.Name = "InGameMenu";
            this.Size = new System.Drawing.Size(200, 250);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Main_Menu;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Resume;
        private System.Windows.Forms.Button button_Options;
    }
}
