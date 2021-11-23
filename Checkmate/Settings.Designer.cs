using System.ComponentModel;

namespace Checkmate
{
    partial class Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.box_legalMoves = new System.Windows.Forms.CheckBox();
            this.btn_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.SandyBrown;
            this.label1.Location = new System.Drawing.Point(297, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings";
            // 
            // box_legalMoves
            // 
            this.box_legalMoves.BackColor = System.Drawing.Color.Transparent;
            this.box_legalMoves.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.box_legalMoves.ForeColor = System.Drawing.Color.SandyBrown;
            this.box_legalMoves.Location = new System.Drawing.Point(317, 136);
            this.box_legalMoves.Name = "box_legalMoves";
            this.box_legalMoves.Size = new System.Drawing.Size(117, 23);
            this.box_legalMoves.TabIndex = 1;
            this.box_legalMoves.Text = "Legal Moves";
            this.box_legalMoves.UseVisualStyleBackColor = false;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_back.ForeColor = System.Drawing.Color.SandyBrown;
            this.btn_back.Location = new System.Drawing.Point(613, 393);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(175, 45);
            this.btn_back.TabIndex = 2;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Checkmate.Properties.Resources.Cookies_Background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.box_legalMoves);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btn_back;

        private System.Windows.Forms.CheckBox box_legalMoves;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.CheckBox checkBox1;

        private System.Windows.Forms.Label label1;

        #endregion
    }
}