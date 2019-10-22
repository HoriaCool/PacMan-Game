using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace Horia_PacMan
{
    public partial class Menu_PM : Form
    {
        public partial class High_Score_stream
        {
            private string path = Environment.CurrentDirectory + "/" + "HighScore.txt";

            public string[] Name;
            public string[] Index;
            public string[] Score;
            public string[] Datetime;
            public Label[] Rank_label;
            public Label[] Score_label;
            public Label[] DateT_label;
            public Label[] Name_label;

            private void Get_information_from_stream()
            {
                if (!File.Exists(path))
                    return;

                using (StreamReader sr = new StreamReader(path))
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        Name[i] = sr.ReadLine();
                        Score[i] = sr.ReadLine();
                        Datetime[i] = sr.ReadLine();
                    }
                }

                if (Name[0] != null)
                    Index[0] = "1ST";
                if (Name[1] != null)
                    Index[1] = "2ND";
                if (Name[2] != null)
                    Index[2] = "3RD";
            }

            private static void Label_set(Label l, Color c, int x, int y, int w, int h)
            {
                System.ComponentModel.TypeConverter converter =
                System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
                Font f = (Font)converter.ConvertFromString("Cambria, 18pt, style=Bold, Italic");
                l.Font = f;
                l.BackColor = Color.Black;
                l.Visible = false;

                l.ForeColor = c;
                l.Top = x;
                l.Left = y;

                l.Width = w;
                l.Height = h;
            }

            public High_Score_stream()
            {
                /* Allocate Dinamyc Memmory */{

                    Name = new string[3];
                    Index = new string[3];
                    Score = new string[3];
                    Datetime = new string[3];

                    Rank_label = new Label[3];
                    Score_label = new Label[3];
                    DateT_label = new Label[3];
                    Name_label = new Label[3];
                }

                for (int i = 0; i < 3; ++i)
                {
                    Index[i] = Name[i] = Score[i] = Datetime[i] = null;
                    Rank_label[i] = new Label();
                    Name_label[i] = new Label();
                    Score_label[i] = new Label();
                    DateT_label[i] = new Label();
                }

                /* Set Labels*/{

                    Label_set(Rank_label[0], Color.Yellow, 460, 22, 58, 28);
                    Label_set(Name_label[0], Color.Yellow, 460, 87, 205, 28);
                    Label_set(Score_label[0], Color.Yellow, 460, 297, 124, 28);
                    Label_set(DateT_label[0], Color.Yellow, 460, 424, 134, 28);

                    Label_set(Rank_label[1], Color.WhiteSmoke, 535, 22, 58, 28);
                    Label_set(Name_label[1], Color.WhiteSmoke, 535, 87, 205, 28);
                    Label_set(Score_label[1], Color.WhiteSmoke, 535, 297, 124, 28);
                    Label_set(DateT_label[1], Color.WhiteSmoke, 535, 424, 134, 28);

                    Label_set(Rank_label[2], Color.SandyBrown, 610, 22, 58, 28);
                    Label_set(Name_label[2], Color.SandyBrown, 610, 87, 205, 28);
                    Label_set(Score_label[2], Color.SandyBrown, 610, 297, 124, 28);
                    Label_set(DateT_label[2], Color.SandyBrown, 610, 424, 134, 28);
                }

                Get_information_from_stream();

                for (int i = 0; i < 3; ++i)
                {
                    Rank_label[i].Text = Index[i];
                    Name_label[i].Text = Name[i];
                    Score_label[i].Text = Score[i];
                    DateT_label[i].Text = Datetime[i];
                }
            }
        }
        High_Score_stream hs;

        public partial class Controls_stream
        {
            private string path = Environment.CurrentDirectory + "/" + "Controls.txt";
            public string text_pictureBox_img = null;
            public string text_pictureBox_Keys = null;

            public void Add_informations_in_stream()
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(text_pictureBox_img);
                    sw.WriteLine(text_pictureBox_Keys);
                }
            }
            public void Get_informations_from_stream()
            {
                if (!File.Exists(path))
                {
                    text_pictureBox_img = "1"; // PacMan = 1, Lady_PacMan = 0. 
                    text_pictureBox_Keys = "1"; // arrow_Keys = 1, wasd_Keys = 0.
                    Add_informations_in_stream();
                }

                string text;
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadLine();
                    text_pictureBox_img = text;

                    text = sr.ReadLine();
                    text_pictureBox_Keys = text;
                }
            }
            public void Use_informations_from_stream(PictureBox P1, PictureBox P1_Keys,
            PictureBox P2, PictureBox P2_Keys)
            {
                if (text_pictureBox_img == "1")
                {
                    P1.Image = Properties.Resources.left;
                    P2.Image = Properties.Resources.lady_left;
                }
                else
                {
                    P1.Image = Properties.Resources.lady_left;
                    P2.Image = Properties.Resources.left;
                }

                if (text_pictureBox_Keys == "1")
                {
                    P1_Keys.Image = Properties.Resources.arrow_Keys;
                    P2_Keys.Image = Properties.Resources.wasd_Keys;
                }
                else
                {
                    P1_Keys.Image = Properties.Resources.wasd_Keys;
                    P2_Keys.Image = Properties.Resources.arrow_Keys;
                }
            }

            public Controls_stream(PictureBox P1, PictureBox P1_Keys,
            PictureBox P2, PictureBox P2_Keys)
            {
                Get_informations_from_stream();
                Use_informations_from_stream(P1, P1_Keys, P2, P2_Keys);
            }
        }
        Controls_stream cs;

        public Menu_PM()
        {
            InitializeComponent();
        }

        private void Menu_PM_Load(object sender, EventArgs e)
        {
            hs = new High_Score_stream();
            for (int i = 0; i < 3; ++i)
            {
                this.Controls.Add(hs.Rank_label[i]);
                this.Controls.Add(hs.Name_label[i]);
                this.Controls.Add(hs.Score_label[i]);
                this.Controls.Add(hs.DateT_label[i]);
            }

            cs = new Controls_stream(Player1_pictureBox, Player1_pictureBox_Keys,
                                     Player2_pictureBox, Player2_pictureBox_Keys);
            Pause_pictureBox.Image = Properties.Resources.p_Keys;
        }

        private void OpenNewForm()
        {
            Map_PM f = new Map_PM();
            f.Location = this.Location;
            Application.Run(f);
        }
        private async void New_Game_button_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            await Task.Delay(1400);
            this.Close();
        }

        private void High_Score_button_Click(object sender, EventArgs e)
        {
            New_Game_button.Visible = false;
            High_Score_button.Visible = false;
            Controls_button.Visible = false;

            Return_button.Visible = true;

            Name_label.Visible = true;
            Score_label.Visible = true;
            Date_label.Visible = true;
            for (int i = 0; i < 3; ++i)
            {
                hs.Rank_label[i].Visible = true;
                hs.Name_label[i].Visible = true;
                hs.Score_label[i].Visible = true;
                hs.DateT_label[i].Visible = true;
            }
        }

        private void Controls_button_Click(object sender, EventArgs e)
        {
            New_Game_button.Visible = false;
            High_Score_button.Visible = false;
            Controls_button.Visible = false;

            button1.Visible = true;
            button2.Visible = true;
            Return_button.Visible = true;
            Text_label.Visible = true;
            Pause_pictureBox.Visible = true;
            Pause_label.Visible = true;

            Player1_label.Visible = true;
            Player1_pictureBox.Visible = true;
            Player1_pictureBox_Keys.Visible = true;

            Player2_label.Visible = true;
            Player2_pictureBox.Visible = true;
            Player2_pictureBox_Keys.Visible = true;
        }

        private void Return_button_Click(object sender, EventArgs e)
        {
            New_Game_button.Visible = true;
            High_Score_button.Visible = true;
            Controls_button.Visible = true;

            Return_button.Visible = false;

            // High Score
            Name_label.Visible = false;
            Score_label.Visible = false;
            Date_label.Visible = false;
            for (int i = 0; i < 3; ++i)
            {
                hs.Rank_label[i].Visible = false;
                hs.Name_label[i].Visible = false;
                hs.Score_label[i].Visible = false;
                hs.DateT_label[i].Visible = false;
            }

            // Controls
            button1.Visible = false;
            button2.Visible = false;

            Text_label.Visible = false;
            Pause_pictureBox.Visible = false;
            Pause_label.Visible = false;

            Player1_label.Visible = false;
            Player1_pictureBox.Visible = false;
            Player1_pictureBox_Keys.Visible = false;

            Player2_label.Visible = false;
            Player2_pictureBox.Visible = false;
            Player2_pictureBox_Keys.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cs.text_pictureBox_img == "1")
                cs.text_pictureBox_img = "0";
            else
                cs.text_pictureBox_img = "1";
            cs.Add_informations_in_stream();
            cs.Use_informations_from_stream(Player1_pictureBox, Player1_pictureBox_Keys,
                                            Player2_pictureBox, Player2_pictureBox_Keys);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (cs.text_pictureBox_Keys == "1")
                cs.text_pictureBox_Keys = "0";
            else
                cs.text_pictureBox_Keys = "1";
            cs.Add_informations_in_stream();
            cs.Use_informations_from_stream(Player1_pictureBox, Player1_pictureBox_Keys,
                                            Player2_pictureBox, Player2_pictureBox_Keys);
        }
    }
}
