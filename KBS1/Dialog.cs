using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KBS1 {
    public partial class Dialog : Form {
        public Dialog() {
            InitializeComponent();

            this.Text = "Object speed dialog";

            // Set dialog size
            this.ClientSize = new Size(400, 200);

            this.label1.Text = "What is the desired speed?";
            this.label1.Size = new Size(150, 50);

            // Dialog text location
            int textX = ( this.ClientSize.Width / 2 ) - ( this.label1.Size.Width / 2 );
            int textY = this.ClientSize.Height / 4;

            this.label1.Location = new Point(textX, textY);

            // Overwrite button text/location and dialog result
            int buttonX = this.ClientSize.Width/2;
            int buttonY = this.ClientSize.Height - 50;
            this.button1.Text = "OK";
            this.button1.Location = new Point(buttonX-100, buttonY);
            this.button2.Text = "Cancel";
            this.button2.Location = new Point(buttonX+10, buttonY);
            this.button1.DialogResult = DialogResult.OK;
            this.button2.DialogResult = DialogResult.Cancel;

            // Overwrite textbox properties
            int boxX = ( this.ClientSize.Width / 2 ) - ( this.numericUpDown1.Size.Width / 2 );
            int boxY = textY+50;
            this.numericUpDown1.Location = new Point(boxX, boxY);

            // Disable resizing
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;

        }

        public int GetValue() {
            return (int) this.numericUpDown1.Value;
        }
    }
}
