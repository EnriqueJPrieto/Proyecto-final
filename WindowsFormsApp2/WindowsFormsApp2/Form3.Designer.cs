namespace WindowsFormsApp2
{
    partial class Form3
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.J3 = new System.Windows.Forms.PictureBox();
            this.J4 = new System.Windows.Forms.PictureBox();
            this.J1 = new System.Windows.Forms.PictureBox();
            this.J2 = new System.Windows.Forms.PictureBox();
            this.BALL = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PENEMY = new System.Windows.Forms.Label();
            this.PALLY = new System.Windows.Forms.Label();
            this.RELOJ = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.J3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.J2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BALL)).BeginInit();
            this.SuspendLayout();
            // 
            // J3
            // 
            this.J3.BackColor = System.Drawing.Color.Red;
            this.J3.Location = new System.Drawing.Point(670, 231);
            this.J3.Name = "J3";
            this.J3.Size = new System.Drawing.Size(23, 96);
            this.J3.TabIndex = 0;
            this.J3.TabStop = false;
            this.J3.Tag = "object";
            // 
            // J4
            // 
            this.J4.BackColor = System.Drawing.Color.Red;
            this.J4.Location = new System.Drawing.Point(699, 315);
            this.J4.Name = "J4";
            this.J4.Size = new System.Drawing.Size(23, 96);
            this.J4.TabIndex = 1;
            this.J4.TabStop = false;
            this.J4.Tag = "object";
            // 
            // J1
            // 
            this.J1.BackColor = System.Drawing.Color.Blue;
            this.J1.Location = new System.Drawing.Point(49, 231);
            this.J1.Name = "J1";
            this.J1.Size = new System.Drawing.Size(23, 96);
            this.J1.TabIndex = 2;
            this.J1.TabStop = false;
            this.J1.Tag = "object";
            // 
            // J2
            // 
            this.J2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.J2.Location = new System.Drawing.Point(78, 315);
            this.J2.Name = "J2";
            this.J2.Size = new System.Drawing.Size(23, 96);
            this.J2.TabIndex = 3;
            this.J2.TabStop = false;
            this.J2.Tag = "object";
            // 
            // BALL
            // 
            this.BALL.BackColor = System.Drawing.SystemColors.Desktop;
            this.BALL.Location = new System.Drawing.Point(387, 231);
            this.BALL.Name = "BALL";
            this.BALL.Size = new System.Drawing.Size(20, 20);
            this.BALL.TabIndex = 4;
            this.BALL.TabStop = false;
            this.BALL.Tag = "";
            this.BALL.Click += new System.EventHandler(this.BALL_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PENEMY
            // 
            this.PENEMY.AutoSize = true;
            this.PENEMY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PENEMY.ForeColor = System.Drawing.Color.Red;
            this.PENEMY.Location = new System.Drawing.Point(744, 9);
            this.PENEMY.Name = "PENEMY";
            this.PENEMY.Size = new System.Drawing.Size(44, 31);
            this.PENEMY.TabIndex = 5;
            this.PENEMY.Text = "00";
            // 
            // PALLY
            // 
            this.PALLY.AutoSize = true;
            this.PALLY.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PALLY.ForeColor = System.Drawing.Color.Lime;
            this.PALLY.Location = new System.Drawing.Point(12, 9);
            this.PALLY.Name = "PALLY";
            this.PALLY.Size = new System.Drawing.Size(44, 31);
            this.PALLY.TabIndex = 6;
            this.PALLY.Text = "00";
            // 
            // RELOJ
            // 
            this.RELOJ.AutoSize = true;
            this.RELOJ.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RELOJ.Location = new System.Drawing.Point(363, 14);
            this.RELOJ.Name = "RELOJ";
            this.RELOJ.Size = new System.Drawing.Size(66, 26);
            this.RELOJ.TabIndex = 7;
            this.RELOJ.Text = "14:25";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RELOJ);
            this.Controls.Add(this.PALLY);
            this.Controls.Add(this.PENEMY);
            this.Controls.Add(this.BALL);
            this.Controls.Add(this.J2);
            this.Controls.Add(this.J1);
            this.Controls.Add(this.J4);
            this.Controls.Add(this.J3);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form3";
            this.Tag = "object";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyisDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.J3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.J2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BALL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox J3;
        private System.Windows.Forms.PictureBox J4;
        private System.Windows.Forms.PictureBox J1;
        private System.Windows.Forms.PictureBox J2;
        private System.Windows.Forms.PictureBox BALL;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label PENEMY;
        private System.Windows.Forms.Label PALLY;
        private System.Windows.Forms.Label RELOJ;
    }
}