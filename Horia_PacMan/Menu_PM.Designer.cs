namespace Horia_PacMan
{
    partial class Menu_PM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_PM));
            this.New_Game_button = new System.Windows.Forms.Button();
            this.Controls_button = new System.Windows.Forms.Button();
            this.Text_label = new System.Windows.Forms.Label();
            this.Player1_pictureBox_Keys = new System.Windows.Forms.PictureBox();
            this.Player2_pictureBox_Keys = new System.Windows.Forms.PictureBox();
            this.Pause_pictureBox = new System.Windows.Forms.PictureBox();
            this.Player1_label = new System.Windows.Forms.Label();
            this.Player2_label = new System.Windows.Forms.Label();
            this.Pause_label = new System.Windows.Forms.Label();
            this.Return_button = new System.Windows.Forms.Button();
            this.Player1_pictureBox = new System.Windows.Forms.PictureBox();
            this.Player2_pictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.High_Score_button = new System.Windows.Forms.Button();
            this.Name_label = new System.Windows.Forms.Label();
            this.Score_label = new System.Windows.Forms.Label();
            this.Date_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Player1_pictureBox_Keys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2_pictureBox_Keys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pause_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // New_Game_button
            // 
            this.New_Game_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.New_Game_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.New_Game_button.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.New_Game_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.New_Game_button.Location = new System.Drawing.Point(150, 360);
            this.New_Game_button.Name = "New_Game_button";
            this.New_Game_button.Size = new System.Drawing.Size(270, 60);
            this.New_Game_button.TabIndex = 3;
            this.New_Game_button.Text = "New Game";
            this.New_Game_button.UseVisualStyleBackColor = false;
            this.New_Game_button.Click += new System.EventHandler(this.New_Game_button_Click);
            // 
            // Controls_button
            // 
            this.Controls_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Controls_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Controls_button.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Controls_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Controls_button.Location = new System.Drawing.Point(150, 580);
            this.Controls_button.Name = "Controls_button";
            this.Controls_button.Size = new System.Drawing.Size(270, 60);
            this.Controls_button.TabIndex = 5;
            this.Controls_button.Text = "Controls";
            this.Controls_button.UseVisualStyleBackColor = false;
            this.Controls_button.Click += new System.EventHandler(this.Controls_button_Click);
            // 
            // Text_label
            // 
            this.Text_label.AutoSize = true;
            this.Text_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Text_label.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Text_label.Location = new System.Drawing.Point(26, 378);
            this.Text_label.Name = "Text_label";
            this.Text_label.Size = new System.Drawing.Size(516, 66);
            this.Text_label.TabIndex = 6;
            this.Text_label.Text = "PacMan\r\nThere are two players, PacMan and Lady PacMan. The main\r\ncontrols can be " +
    "edited below by selecting the botton.";
            this.Text_label.Visible = false;
            // 
            // Player1_pictureBox_Keys
            // 
            this.Player1_pictureBox_Keys.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player1_pictureBox_Keys.Location = new System.Drawing.Point(30, 555);
            this.Player1_pictureBox_Keys.Name = "Player1_pictureBox_Keys";
            this.Player1_pictureBox_Keys.Size = new System.Drawing.Size(134, 113);
            this.Player1_pictureBox_Keys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player1_pictureBox_Keys.TabIndex = 7;
            this.Player1_pictureBox_Keys.TabStop = false;
            this.Player1_pictureBox_Keys.Visible = false;
            // 
            // Player2_pictureBox_Keys
            // 
            this.Player2_pictureBox_Keys.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player2_pictureBox_Keys.Location = new System.Drawing.Point(408, 555);
            this.Player2_pictureBox_Keys.Name = "Player2_pictureBox_Keys";
            this.Player2_pictureBox_Keys.Size = new System.Drawing.Size(134, 113);
            this.Player2_pictureBox_Keys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player2_pictureBox_Keys.TabIndex = 8;
            this.Player2_pictureBox_Keys.TabStop = false;
            this.Player2_pictureBox_Keys.Visible = false;
            // 
            // Pause_pictureBox
            // 
            this.Pause_pictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.Pause_pictureBox.Location = new System.Drawing.Point(30, 454);
            this.Pause_pictureBox.Name = "Pause_pictureBox";
            this.Pause_pictureBox.Size = new System.Drawing.Size(44, 47);
            this.Pause_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pause_pictureBox.TabIndex = 9;
            this.Pause_pictureBox.TabStop = false;
            this.Pause_pictureBox.Visible = false;
            // 
            // Player1_label
            // 
            this.Player1_label.AutoSize = true;
            this.Player1_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player1_label.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Player1_label.Location = new System.Drawing.Point(26, 517);
            this.Player1_label.Name = "Player1_label";
            this.Player1_label.Size = new System.Drawing.Size(81, 22);
            this.Player1_label.TabIndex = 10;
            this.Player1_label.Text = "Player 1";
            this.Player1_label.Visible = false;
            // 
            // Player2_label
            // 
            this.Player2_label.AutoSize = true;
            this.Player2_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player2_label.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Player2_label.Location = new System.Drawing.Point(404, 517);
            this.Player2_label.Name = "Player2_label";
            this.Player2_label.Size = new System.Drawing.Size(81, 22);
            this.Player2_label.TabIndex = 11;
            this.Player2_label.Text = "Player 2";
            this.Player2_label.Visible = false;
            // 
            // Pause_label
            // 
            this.Pause_label.AutoSize = true;
            this.Pause_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Pause_label.Font = new System.Drawing.Font("Cambria", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Pause_label.Location = new System.Drawing.Point(91, 466);
            this.Pause_label.Name = "Pause_label";
            this.Pause_label.Size = new System.Drawing.Size(121, 22);
            this.Pause_label.TabIndex = 12;
            this.Pause_label.Text = "Pause button";
            this.Pause_label.Visible = false;
            // 
            // Return_button
            // 
            this.Return_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Return_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Return_button.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Return_button.Location = new System.Drawing.Point(30, 333);
            this.Return_button.Name = "Return_button";
            this.Return_button.Size = new System.Drawing.Size(147, 32);
            this.Return_button.TabIndex = 13;
            this.Return_button.Text = "Return";
            this.Return_button.UseVisualStyleBackColor = false;
            this.Return_button.Visible = false;
            this.Return_button.Click += new System.EventHandler(this.Return_button_Click);
            // 
            // Player1_pictureBox
            // 
            this.Player1_pictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player1_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player1_pictureBox.Location = new System.Drawing.Point(132, 515);
            this.Player1_pictureBox.Name = "Player1_pictureBox";
            this.Player1_pictureBox.Size = new System.Drawing.Size(30, 30);
            this.Player1_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player1_pictureBox.TabIndex = 14;
            this.Player1_pictureBox.TabStop = false;
            this.Player1_pictureBox.Visible = false;
            // 
            // Player2_pictureBox
            // 
            this.Player2_pictureBox.BackColor = System.Drawing.SystemColors.ControlText;
            this.Player2_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Player2_pictureBox.Location = new System.Drawing.Point(512, 515);
            this.Player2_pictureBox.Name = "Player2_pictureBox";
            this.Player2_pictureBox.Size = new System.Drawing.Size(30, 30);
            this.Player2_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player2_pictureBox.TabIndex = 15;
            this.Player2_pictureBox.TabStop = false;
            this.Player2_pictureBox.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(267, 506);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(45, 45);
            this.button1.TabIndex = 16;
            this.button1.Text = "< >";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Wide Latin", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(267, 590);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(45, 45);
            this.button2.TabIndex = 17;
            this.button2.Text = "< >";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // High_Score_button
            // 
            this.High_Score_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.High_Score_button.Cursor = System.Windows.Forms.Cursors.Default;
            this.High_Score_button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.High_Score_button.Font = new System.Drawing.Font("Wide Latin", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.High_Score_button.ForeColor = System.Drawing.SystemColors.ControlText;
            this.High_Score_button.Location = new System.Drawing.Point(150, 470);
            this.High_Score_button.Name = "High_Score_button";
            this.High_Score_button.Size = new System.Drawing.Size(270, 60);
            this.High_Score_button.TabIndex = 4;
            this.High_Score_button.Text = "High Score";
            this.High_Score_button.UseVisualStyleBackColor = false;
            this.High_Score_button.Click += new System.EventHandler(this.High_Score_button_Click);
            // 
            // Name_label
            // 
            this.Name_label.AutoSize = true;
            this.Name_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Name_label.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name_label.Location = new System.Drawing.Point(87, 385);
            this.Name_label.Name = "Name_label";
            this.Name_label.Size = new System.Drawing.Size(82, 28);
            this.Name_label.TabIndex = 19;
            this.Name_label.Text = "Name:";
            this.Name_label.Visible = false;
            // 
            // Score_label
            // 
            this.Score_label.AutoSize = true;
            this.Score_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Score_label.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Score_label.Location = new System.Drawing.Point(297, 385);
            this.Score_label.Name = "Score_label";
            this.Score_label.Size = new System.Drawing.Size(78, 28);
            this.Score_label.TabIndex = 20;
            this.Score_label.Text = "Score:";
            this.Score_label.Visible = false;
            // 
            // Date_label
            // 
            this.Date_label.AutoSize = true;
            this.Date_label.BackColor = System.Drawing.SystemColors.ControlText;
            this.Date_label.Font = new System.Drawing.Font("Cambria", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Date_label.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Date_label.Location = new System.Drawing.Point(424, 385);
            this.Date_label.Name = "Date_label";
            this.Date_label.Size = new System.Drawing.Size(70, 28);
            this.Date_label.TabIndex = 21;
            this.Date_label.Text = "Date:";
            this.Date_label.Visible = false;
            // 
            // Menu_PM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Horia_PacMan.Properties.Resources.BackGround_PC1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(570, 693);
            this.Controls.Add(this.Date_label);
            this.Controls.Add(this.Score_label);
            this.Controls.Add(this.Name_label);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Player2_pictureBox);
            this.Controls.Add(this.Player1_pictureBox);
            this.Controls.Add(this.Return_button);
            this.Controls.Add(this.Pause_label);
            this.Controls.Add(this.Player2_label);
            this.Controls.Add(this.Player1_label);
            this.Controls.Add(this.Pause_pictureBox);
            this.Controls.Add(this.Player2_pictureBox_Keys);
            this.Controls.Add(this.Player1_pictureBox_Keys);
            this.Controls.Add(this.Text_label);
            this.Controls.Add(this.Controls_button);
            this.Controls.Add(this.High_Score_button);
            this.Controls.Add(this.New_Game_button);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Menu_PM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Menu_PM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Player1_pictureBox_Keys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2_pictureBox_Keys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pause_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player1_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Player2_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button New_Game_button;
        private System.Windows.Forms.Button Controls_button;
        private System.Windows.Forms.Label Text_label;
        private System.Windows.Forms.PictureBox Player1_pictureBox_Keys;
        private System.Windows.Forms.PictureBox Player2_pictureBox_Keys;
        private System.Windows.Forms.PictureBox Pause_pictureBox;
        private System.Windows.Forms.Label Player1_label;
        private System.Windows.Forms.Label Player2_label;
        private System.Windows.Forms.Label Pause_label;
        private System.Windows.Forms.Button Return_button;
        private System.Windows.Forms.PictureBox Player1_pictureBox;
        private System.Windows.Forms.PictureBox Player2_pictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button High_Score_button;
        private System.Windows.Forms.Label Name_label;
        private System.Windows.Forms.Label Score_label;
        private System.Windows.Forms.Label Date_label;
    }
}