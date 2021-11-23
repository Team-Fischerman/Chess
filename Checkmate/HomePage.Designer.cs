using System.ComponentModel;

namespace Checkmate
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.btn_chessGame = new System.Windows.Forms.Button();
            this.btn_settings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_chessGame
            // 
            this.btn_chessGame.BackColor = System.Drawing.Color.Transparent;
            this.btn_chessGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chessGame.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_chessGame.ForeColor = System.Drawing.Color.SandyBrown;
            this.btn_chessGame.Location = new System.Drawing.Point(314, 239);
            this.btn_chessGame.Name = "btn_chessGame";
            this.btn_chessGame.Size = new System.Drawing.Size(170, 45);
            this.btn_chessGame.TabIndex = 2;
            this.btn_chessGame.Text = "Chess Game";
            this.btn_chessGame.UseVisualStyleBackColor = false;
            this.btn_chessGame.Click += new System.EventHandler(this.btn_chessGame_Click);
            // 
            // btn_settings
            // 
            this.btn_settings.BackColor = System.Drawing.Color.Transparent;
            this.btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_settings.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_settings.ForeColor = System.Drawing.Color.SandyBrown;
            this.btn_settings.Location = new System.Drawing.Point(314, 304);
            this.btn_settings.Name = "btn_settings";
            this.btn_settings.Size = new System.Drawing.Size(170, 45);
            this.btn_settings.TabIndex = 3;
            this.btn_settings.Text = "Settings";
            this.btn_settings.UseVisualStyleBackColor = false;
            this.btn_settings.Click += new System.EventHandler(this.btn_settings_Click);
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::Checkmate.Properties.Resources.Dogs_Playing_Chess;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_settings);
            this.Controls.Add(this.btn_chessGame);
            this.MinimizeBox = false;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.TransparencyKey = System.Drawing.SystemColors.Window;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_chessGame;

        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.Button button1;

        #endregion
    }
}