using System;
using System.Windows.Forms;

namespace Checkmate
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

    

        public bool box_checker()
        {
            if (box_legalMoves.Checked)
            {
                Settings1.Default.boxChecked = true;

                Settings1.Default.Save();

                return Settings1.Default.boxChecked;
            }
            else
            {
                Settings1.Default.boxChecked = false;

                Settings1.Default.Save();

                return Settings1.Default.boxChecked;
            }
        }
        
        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            // exits application on close
            Application.Exit();
        }


        private void btn_back_Click_1(object sender, EventArgs e)
        {
            HomePage home = new HomePage();

            // hides settings page
            Hide();

            // shows homepage
            home.ShowDialog();
            

            // closes settings page
            Close();
        }
    }

     

    }


