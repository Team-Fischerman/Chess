using System;
using System.Windows.Forms;

namespace Checkmate
{
    public partial class HomePage : Form
    {


        private Chess chess;
        
        
        public HomePage()
        {
            InitializeComponent();
        }

        private void btn_settings_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();

            // hides homepage
            Hide();

            // shows chess game
            settings.ShowDialog();

            // closes homepage
            Close();
        }

        private void btn_chessGame_Click(object sender, EventArgs e)
        {
            chess = new Chess();
            Hide();
            chess.ShowDialog();
            Close();
            
        }
        
        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            // exits application on close
            Application.Exit();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}