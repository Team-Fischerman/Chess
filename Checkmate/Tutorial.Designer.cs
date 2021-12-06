using System.ComponentModel;

namespace Checkmate
{
    partial class Tutorial
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
            this.btn_resign = new System.Windows.Forms.Button();
            this.btn_back = new System.Windows.Forms.Button();
            this.label_winner = new System.Windows.Forms.Label();
            this.label_turn = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_resign
            // 
            this.btn_resign.BackColor = System.Drawing.Color.Transparent;
            this.btn_resign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_resign.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_resign.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.btn_resign.Location = new System.Drawing.Point(478, 197);
            this.btn_resign.Name = "btn_resign";
            this.btn_resign.Size = new System.Drawing.Size(158, 58);
            this.btn_resign.TabIndex = 4;
            this.btn_resign.Text = "Resign";
            this.btn_resign.UseVisualStyleBackColor = false;
            // 
            // btn_back
            // 
            this.btn_back.BackColor = System.Drawing.Color.Transparent;
            this.btn_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_back.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.btn_back.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.btn_back.Location = new System.Drawing.Point(478, 272);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(158, 58);
            this.btn_back.TabIndex = 5;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = false;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click_1);
            // 
            // label_winner
            // 
            this.label_winner.BackColor = System.Drawing.Color.Transparent;
            this.label_winner.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label_winner.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.label_winner.Location = new System.Drawing.Point(55, 56);
            this.label_winner.Name = "label_winner";
            this.label_winner.Size = new System.Drawing.Size(404, 28);
            this.label_winner.TabIndex = 6;
            // 
            // label_turn
            // 
            this.label_turn.BackColor = System.Drawing.Color.Transparent;
            this.label_turn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label_turn.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.label_turn.Location = new System.Drawing.Point(207, 56);
            this.label_turn.Name = "label_turn";
            this.label_turn.Size = new System.Drawing.Size(91, 28);
            this.label_turn.TabIndex = 7;
            this.label_turn.Text = "White Turn";
            this.label_turn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.panel1.Location = new System.Drawing.Point(59, 107);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 400);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int) (((byte) (255)))), ((int) (((byte) (255)))), ((int) (((byte) (128)))));
            this.label1.Location = new System.Drawing.Point(478, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 58);
            this.label1.TabIndex = 9;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Tutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_turn);
            this.Controls.Add(this.label_winner);
            this.Controls.Add(this.btn_back);
            this.Controls.Add(this.btn_resign);
            this.Name = "Tutorial";
            this.Text = "Tutorial";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Label label_turn;

        private System.Windows.Forms.Label label_winner;

        private System.Windows.Forms.Button btn_back;

        private System.Windows.Forms.Button btn_resign;

        private System.Windows.Forms.Panel panel1;

        #endregion
    }
}