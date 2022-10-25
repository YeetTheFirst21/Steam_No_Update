using System;
using System.Windows.Forms;

namespace Steam_no_update
{
    public partial class Form2 : Form
    {
        private bool manualClosing = false;
        public Form2()
        {
            InitializeComponent();
            button1.Text = Program.LanguagePack(10);
            button2.Text = Program.LanguagePack(11);
            label1.Text = Program.LanguagePack(12);
            toolTip1.SetToolTip(button3, Program.LanguagePack(4));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manualClosing = true;
            this.Close();
            manualClosing = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.changeLanguagePack();
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingAction(manualClosing))
            {
                //if(e.CloseReason == CloseReason.FormOwnerClosing)
                e.Cancel = true;
            }
        }

        private bool closingAction(bool manual)
        {
            if (manual)
            {
                if (Program.BadForceYesNo("Try to automatically add games? This will search through all uninstallers of the games and add them", false) == DialogResult.Yes)
                {
                    Program.SearchForGamesAutomatically();
                }
                Properties.Settings.Default.initializationOver = true;
                return false;
            }
            else if (Program.quitTheAppAsAWhole() == DialogResult.Yes)
            {
                //Application.Exit();
                try { Environment.Exit(1); }//This sometimes gives error so i gave up //https://stackoverflow.com/questions/51608991/c-sharp-error-creating-window-handle-on-environment-exit-call
                catch
                {
                    Application.ExitThread();
                }
                return false;//does not matter as Environemnt has already exited but wont compile since an outcome does not return.
            }
            else return true;
        }
    }
}
