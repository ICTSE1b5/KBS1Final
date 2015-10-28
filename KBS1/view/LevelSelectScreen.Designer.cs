namespace KBS1.view
{
    partial class LevelSelectScreen
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button_Main_Menu
            // 
            this.button_Main_Menu.BackColor = System.Drawing.Color.White;
            this.button_Main_Menu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.button_Main_Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Main_Menu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button_Main_Menu.Location = new System.Drawing.Point(44, 604);
            this.button_Main_Menu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_Main_Menu.Name = "button_Main_Menu";
            this.button_Main_Menu.Size = new System.Drawing.Size(153, 48);
            this.button_Main_Menu.TabIndex = 0;
            this.button_Main_Menu.Text = "Main Menu";
            this.button_Main_Menu.UseVisualStyleBackColor = false;
            this.button_Main_Menu.Click += new System.EventHandler(this.Button_Main_Menu_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(237, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 377);
            this.panel1.TabIndex = 1;
            // 
            // LevelSelectScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KBS1.Properties.Resources.selectlevel;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_Main_Menu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LevelSelectScreen";
            this.Size = new System.Drawing.Size(1067, 689);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Main_Menu;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.Panel panel1;
    }
}
