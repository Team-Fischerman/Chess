using System;
using System.Windows.Forms;

namespace Checkmate
{
    public partial class Settings : Form
    {
        public static bool Highlight;
        
        public Settings()
        {
            InitializeComponent();
            box_legalMoves.Checked = Highlight;
        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            TransitionToHomePage();
        }

        private void TransitionToHomePage()
        {
            HomePage home = new HomePage();

            // hides settings page
            Hide();

            // shows homepage
            home.ShowDialog();

            // closes settings page
            Close();
        }


        private void box_legalMoves_CheckedChanged(object sender, EventArgs e)
        {
            Highlight = box_legalMoves.Checked;
        }
        
        
        
    }
}