using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Horia_PacMan
{
    public partial class Map_PM : Form
    {
        int Score = 0;
        int Lives = 3;
        int Coins = 0;
        string Player_Name = null;
        
        private void Next_Level()
        {
            Coins = 0;
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Tag == "SuperCoin" || x.Tag == "Coin")
                    {
                        if (x.Visible == false)
                        {
                            x.Visible = true;
                        }
                    }
                }
            }

            Enter1 = 0;
            Enter2 = 4;
            Enter3 = 7;
            Contor_timer_Enter = -1;
            Contor_timer_seconds = -1;
            Contor_timer_EatGhosts = 100;

            PacMan.Start_Position(Mob_Type.pac_man, stream_read);
            RedGhost.Start_Position(Mob_Type.red_ghost, stream_read);
            PinkGhost.Start_Position(Mob_Type.pink_ghost, stream_read);
            BlueGhost.Start_Position(Mob_Type.blue_ghost, stream_read);
            YellowGhost.Start_Position(Mob_Type.yellow_ghost, stream_read);

            PacMan.can_do_stuff = true;
        }
        private void Game_is_Over()
        {
            timer_seconds.Enabled = false;
            principal_timer.Enabled = false;

            PacMan.Start_Position(Mob_Type.pac_man, stream_read);
            RedGhost.Start_Position(Mob_Type.red_ghost, stream_read);
            PinkGhost.Start_Position(Mob_Type.pink_ghost, stream_read);
            BlueGhost.Start_Position(Mob_Type.blue_ghost, stream_read);
            YellowGhost.Start_Position(Mob_Type.yellow_ghost, stream_read);

            Game_Over_label.Visible = true;

            Add_New_HighScore();
        }

        private void Add_New_HighScore()
        {
            if( (stream_HighScore.Score[0] == null ||
                 Int32.Parse(stream_HighScore.Score[0]) < Score) ||
                (stream_HighScore.Score[1] == null ||
                 Int32.Parse(stream_HighScore.Score[1]) < Score) ||
                (stream_HighScore.Score[2] == null ||
                 Int32.Parse(stream_HighScore.Score[2]) < Score) )
            {
                OK_button.Visible = true;
                PlayerName_label.Visible = true;
                PlayerName_textBox.Visible = true;
                PlayerName_pictureBox.Visible = true;

                PlayerName_textBox.Focus();
                PlayerName_textBox.Text = "";

                timer_HighScore.Enabled = true;
            }
        }
        private void timer_HighScore_Tick(object sender, EventArgs e)
        {
            if (Player_Name != null && Player_Name != "")
            {
                OK_button.Visible = false;
                PlayerName_label.Visible = false;
                PlayerName_textBox.Visible = false;
                PlayerName_pictureBox.Visible = false;

                /* Update the High Score stream */
                {

                    DateTime dateTime = DateTime.Now;
                    string Date_Game = dateTime.ToString("dd.MM.yyyy");

                    if (stream_HighScore.Score[0] == null ||
                         Int32.Parse(stream_HighScore.Score[0]) < Score)
                    {
                        stream_HighScore.Name[2] = stream_HighScore.Name[1];
                        stream_HighScore.Score[2] = stream_HighScore.Score[1];
                        stream_HighScore.Datetime[2] = stream_HighScore.Datetime[1];

                        stream_HighScore.Name[1] = stream_HighScore.Name[0];
                        stream_HighScore.Score[1] = stream_HighScore.Score[0];
                        stream_HighScore.Datetime[1] = stream_HighScore.Datetime[0];

                        stream_HighScore.Name[0] = Player_Name;
                        stream_HighScore.Score[0] = Score.ToString();
                        stream_HighScore.Datetime[0] = Date_Game;
                    }
                    else
                    {
                        if (stream_HighScore.Score[1] == null ||
                             Int32.Parse(stream_HighScore.Score[1]) < Score)
                        {
                            stream_HighScore.Name[2] = stream_HighScore.Name[1];
                            stream_HighScore.Score[2] = stream_HighScore.Score[1];
                            stream_HighScore.Datetime[2] = stream_HighScore.Datetime[1];

                            stream_HighScore.Name[1] = Player_Name;
                            stream_HighScore.Score[1] = Score.ToString();
                            stream_HighScore.Datetime[1] = Date_Game;
                        }
                        else
                        {
                            if (stream_HighScore.Score[2] == null ||
                                 Int32.Parse(stream_HighScore.Score[2]) < Score)
                            {
                                stream_HighScore.Name[1] = Player_Name;
                                stream_HighScore.Score[1] = Score.ToString();
                                stream_HighScore.Datetime[1] = Date_Game;
                            }
                        }
                    }

                    stream_HighScore.Add_informations_in_stream();
                }

                timer_HighScore.Enabled = false;
            }
        }
        private void OK_button_Click(object sender, EventArgs e)
        {
            if (PlayerName_textBox.Text != null && 
                PlayerName_textBox.Text != "")
            {
                Player_Name = PlayerName_textBox.Text;
            }
            else
            {
                PlayerName_label.Text = "New High Score !\nPlease add a name:";
            }
        }


        public partial class High_Score_Stream_Game
        {
            private string path = Environment.CurrentDirectory + "/" + "HighScore.txt";

            public string[] Name;
            public string[] Score;
            public string[] Datetime;

            public void Add_informations_in_stream()
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < 3; ++i)
                    {
                        if (Name[i] != null)
                        {
                            sw.WriteLine(Name[i]);
                            sw.WriteLine(Score[i]);
                            sw.WriteLine(Datetime[i]);
                        }
                    }
                }
            }
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
            }

            public High_Score_Stream_Game()
            {
                /* Allocate Dinamyc Memmory */
                {

                    Name = new string[3];
                    Score = new string[3];
                    Datetime = new string[3];
                }

                for (int i = 0; i < 3; ++i)
                {
                    Name[i] = Score[i] = Datetime[i] = null;
                }

                Get_information_from_stream();
            }
        }
        High_Score_Stream_Game stream_HighScore;

        public partial class Stream_Read
        {
            private string path = Environment.CurrentDirectory + "/" + "Controls.txt";
            public string text_pictureBox_img = null;
            public string text_pictureBox_Keys = null;

            public void Get_informations_from_stream()
            {
                if (!File.Exists(path))
                {
                    text_pictureBox_img = "1"; // PacMan = 1, Lady_PacMan = 0. 
                    text_pictureBox_Keys = "1"; // arrow_Keys = 1, wasd_Keys = 0.
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

            public Stream_Read()
            {
                Get_informations_from_stream();
            }
        }
        Stream_Read stream_read;


        public enum Mob_Type { pac_man, red_ghost, pink_ghost, blue_ghost, yellow_ghost };
        public enum direction { Up, Down, Right, Left, Null };
        public enum Attack { ON, OFF, SCARED };

        public partial class Matrix
        {
            public int[][] m;
            public void Initialization_of_matrix()
            {
                m[1][1] = -1;
                m[1][2] = -1;
                m[1][3] = -1;
                m[1][4] = -1;
                m[1][5] = -1;
                m[1][6] = -1;
                m[1][7] = -1;
                m[1][8] = -1;
                m[1][9] = -1;
                m[1][10] = -1;
                m[1][11] = -1;
                m[1][12] = -1;
                m[1][13] = -1;
                m[1][14] = -1;
                m[1][15] = -1;
                m[1][16] = -1;
                m[1][17] = -1;
                m[1][18] = -1;
                m[1][19] = -1;

                m[2][1] = -1;
                m[2][2] = 0;
                m[2][3] = 0;
                m[2][4] = 0;
                m[2][5] = 0;
                m[2][6] = 0;
                m[2][7] = 0;
                m[2][8] = 0;
                m[2][9] = 0;
                m[2][10] = -1;
                m[2][11] = 0;
                m[2][12] = 0;
                m[2][13] = 0;
                m[2][14] = 0;
                m[2][15] = 0;
                m[2][16] = 0;
                m[2][17] = 0;
                m[2][18] = 0;
                m[2][19] = -1;

                m[3][1] = -1;
                m[3][2] = 0;
                m[3][3] = -1;
                m[3][4] = -1;
                m[3][5] = 0;
                m[3][6] = -1;
                m[3][7] = -1;
                m[3][8] = -1;
                m[3][9] = 0;
                m[3][10] = -1;
                m[3][11] = 0;
                m[3][12] = -1;
                m[3][13] = -1;
                m[3][14] = -1;
                m[3][15] = 0;
                m[3][16] = -1;
                m[3][17] = -1;
                m[3][18] = 0;
                m[3][19] = -1;

                m[4][1] = -1;
                m[4][2] = 0;
                m[4][3] = 0;
                m[4][4] = 0;
                m[4][5] = 0;
                m[4][6] = 0;
                m[4][7] = 0;
                m[4][8] = 0;
                m[4][9] = 0;
                m[4][10] = 0;
                m[4][11] = 0;
                m[4][12] = 0;
                m[4][13] = 0;
                m[4][14] = 0;
                m[4][15] = 0;
                m[4][16] = 0;
                m[4][17] = 0;
                m[4][18] = 0;
                m[4][19] = -1;

                m[5][1] = -1;
                m[5][2] = 0;
                m[5][3] = -1;
                m[5][4] = -1;
                m[5][5] = 0;
                m[5][6] = -1;
                m[5][7] = 0;
                m[5][8] = -1;
                m[5][9] = -1;
                m[5][10] = -1;
                m[5][11] = -1;
                m[5][12] = -1;
                m[5][13] = 0;
                m[5][14] = -1;
                m[5][15] = 0;
                m[5][16] = -1;
                m[5][17] = -1;
                m[5][18] = 0;
                m[5][19] = -1;

                m[6][1] = -1;
                m[6][2] = 0;
                m[6][3] = 0;
                m[6][4] = 0;
                m[6][5] = 0;
                m[6][6] = -1;
                m[6][7] = 0;
                m[6][8] = 0;
                m[6][9] = 0;
                m[6][10] = -1;
                m[6][11] = 0;
                m[6][12] = 0;
                m[6][13] = 0;
                m[6][14] = -1;
                m[6][15] = 0;
                m[6][16] = 0;
                m[6][17] = 0;
                m[6][18] = 0;
                m[6][19] = -1;

                m[7][1] = -1;
                m[7][2] = -1;
                m[7][3] = -1;
                m[7][4] = -1;
                m[7][5] = 0;
                m[7][6] = -1;
                m[7][7] = -1;
                m[7][8] = -1;
                m[7][9] = 0;
                m[7][10] = -1;
                m[7][11] = 0;
                m[7][12] = -1;
                m[7][13] = -1;
                m[7][14] = -1;
                m[7][15] = 0;
                m[7][16] = -1;
                m[7][17] = -1;
                m[7][18] = -1;
                m[7][19] = -1;

                m[8][1] = 0;
                m[8][2] = 0;
                m[8][3] = 0;
                m[8][4] = -1;
                m[8][5] = 0;
                m[8][6] = -1;
                m[8][7] = 0;
                m[8][8] = 0;
                m[8][9] = 0;
                m[8][10] = 0;
                m[8][11] = 0;
                m[8][12] = 0;
                m[8][13] = 0;
                m[8][14] = -1;
                m[8][15] = 0;
                m[8][16] = -1;
                m[8][17] = 0;
                m[8][18] = 0;
                m[8][19] = 0;

                m[9][1] = -1;
                m[9][2] = -1;
                m[9][3] = -1;
                m[9][4] = -1;
                m[9][5] = 0;
                m[9][6] = -1;
                m[9][7] = 0;
                m[9][8] = -1;
                m[9][9] = -1;
                m[9][10] = -1;
                m[9][11] = -1;
                m[9][12] = -1;
                m[9][13] = 0;
                m[9][14] = -1;
                m[9][15] = 0;
                m[9][16] = -1;
                m[9][17] = -1;
                m[9][18] = -1;
                m[9][19] = -1;

                m[10][0] = 0;

                m[10][1] = 0;
                m[10][2] = 0;
                m[10][3] = 0;
                m[10][4] = 0;
                m[10][5] = 0;
                m[10][6] = 0;
                m[10][7] = 0;
                m[10][8] = -1;
                m[10][9] = 0;
                m[10][10] = 0;
                m[10][11] = 0;
                m[10][12] = -1;
                m[10][13] = 0;
                m[10][14] = 0;
                m[10][15] = 0;
                m[10][16] = 0;
                m[10][17] = 0;
                m[10][18] = 0;
                m[10][19] = 0;

                m[10][20] = 0;

                m[11][1] = -1;
                m[11][2] = -1;
                m[11][3] = -1;
                m[11][4] = -1;
                m[11][5] = 0;
                m[11][6] = -1;
                m[11][7] = 0;
                m[11][8] = -1;
                m[11][9] = -1;
                m[11][10] = -1;
                m[11][11] = -1;
                m[11][12] = -1;
                m[11][13] = 0;
                m[11][14] = -1;
                m[11][15] = 0;
                m[11][16] = -1;
                m[11][17] = -1;
                m[11][18] = -1;
                m[11][19] = -1;

                m[12][1] = 0;
                m[12][2] = 0;
                m[12][3] = 0;
                m[12][4] = -1;
                m[12][5] = 0;
                m[12][6] = -1;
                m[12][7] = 0;
                m[12][8] = 0;
                m[12][9] = 0;
                m[12][10] = 0;
                m[12][11] = 0;
                m[12][12] = 0;
                m[12][13] = 0;
                m[12][14] = -1;
                m[12][15] = 0;
                m[12][16] = -1;
                m[12][17] = 0;
                m[12][18] = 0;
                m[12][19] = 0;

                m[13][1] = -1;
                m[13][2] = -1;
                m[13][3] = -1;
                m[13][4] = -1;
                m[13][5] = 0;
                m[13][6] = -1;
                m[13][7] = 0;
                m[13][8] = -1;
                m[13][9] = -1;
                m[13][10] = -1;
                m[13][11] = -1;
                m[13][12] = -1;
                m[13][13] = 0;
                m[13][14] = -1;
                m[13][15] = 0;
                m[13][16] = -1;
                m[13][17] = -1;
                m[13][18] = -1;
                m[13][19] = -1;

                m[14][1] = -1;
                m[14][2] = 0;
                m[14][3] = 0;
                m[14][4] = 0;
                m[14][5] = 0;
                m[14][6] = 0;
                m[14][7] = 0;
                m[14][8] = 0;
                m[14][9] = 0;
                m[14][10] = -1;
                m[14][11] = 0;
                m[14][12] = 0;
                m[14][13] = 0;
                m[14][14] = 0;
                m[14][15] = 0;
                m[14][16] = 0;
                m[14][17] = 0;
                m[14][18] = 0;
                m[14][19] = -1;

                m[15][1] = -1;
                m[15][2] = 0;
                m[15][3] = -1;
                m[15][4] = -1;
                m[15][5] = 0;
                m[15][6] = -1;
                m[15][7] = -1;
                m[15][8] = -1;
                m[15][9] = 0;
                m[15][10] = -1;
                m[15][11] = 0;
                m[15][12] = -1;
                m[15][13] = -1;
                m[15][14] = -1;
                m[15][15] = 0;
                m[15][16] = -1;
                m[15][17] = -1;
                m[15][18] = 0;
                m[15][19] = -1;

                m[16][1] = -1;
                m[16][2] = 0;
                m[16][3] = 0;
                m[16][4] = -1;
                m[16][5] = 0;
                m[16][6] = 0;
                m[16][7] = 0;
                m[16][8] = 0;
                m[16][9] = 0;
                m[16][10] = 0;
                m[16][11] = 0;
                m[16][12] = 0;
                m[16][13] = 0;
                m[16][14] = 0;
                m[16][15] = 0;
                m[16][16] = -1;
                m[16][17] = 0;
                m[16][18] = 0;
                m[16][19] = -1;

                m[17][1] = -1;
                m[17][2] = -1;
                m[17][3] = 0;
                m[17][4] = -1;
                m[17][5] = 0;
                m[17][6] = -1;
                m[17][7] = 0;
                m[17][8] = -1;
                m[17][9] = -1;
                m[17][10] = -1;
                m[17][11] = -1;
                m[17][12] = -1;
                m[17][13] = 0;
                m[17][14] = -1;
                m[17][15] = 0;
                m[17][16] = -1;
                m[17][17] = 0;
                m[17][18] = -1;
                m[17][19] = -1;

                m[18][1] = -1;
                m[18][2] = 0;
                m[18][3] = 0;
                m[18][4] = 0;
                m[18][5] = 0;
                m[18][6] = -1;
                m[18][7] = 0;
                m[18][8] = 0;
                m[18][9] = 0;
                m[18][10] = -1;
                m[18][11] = 0;
                m[18][12] = 0;
                m[18][13] = 0;
                m[18][14] = -1;
                m[18][15] = 0;
                m[18][16] = 0;
                m[18][17] = 0;
                m[18][18] = 0;
                m[18][19] = -1;

                m[19][1] = -1;
                m[19][2] = 0;
                m[19][3] = -1;
                m[19][4] = -1;
                m[19][5] = -1;
                m[19][6] = -1;
                m[19][7] = -1;
                m[19][8] = -1;
                m[19][9] = 0;
                m[19][10] = -1;
                m[19][11] = 0;
                m[19][12] = -1;
                m[19][13] = -1;
                m[19][14] = -1;
                m[19][15] = -1;
                m[19][16] = -1;
                m[19][17] = -1;
                m[19][18] = 0;
                m[19][19] = -1;

                m[20][1] = -1;
                m[20][2] = 0;
                m[20][3] = 0;
                m[20][4] = 0;
                m[20][5] = 0;
                m[20][6] = 0;
                m[20][7] = 0;
                m[20][8] = 0;
                m[20][9] = 0;
                m[20][10] = 0;
                m[20][11] = 0;
                m[20][12] = 0;
                m[20][13] = 0;
                m[20][14] = 0;
                m[20][15] = 0;
                m[20][16] = 0;
                m[20][17] = 0;
                m[20][18] = 0;
                m[20][19] = -1;

                m[21][1] = -1;
                m[21][2] = -1;
                m[21][3] = -1;
                m[21][4] = -1;
                m[21][5] = -1;
                m[21][6] = -1;
                m[21][7] = -1;
                m[21][8] = -1;
                m[21][9] = -1;
                m[21][10] = -1;
                m[21][11] = -1;
                m[21][12] = -1;
                m[21][13] = -1;
                m[21][14] = -1;
                m[21][15] = -1;
                m[21][16] = -1;
                m[21][17] = -1;
                m[21][18] = -1;
                m[21][19] = -1;
            }
            public void Initialization_of_Random_matrix()
            {
                for (int i = 0; i < 21; ++i)
                    for (int j = 0; j < 21; ++j)
                        m[i][j] = 1;
                m[2][5] = 2;
                m[2][15] = 2;

                m[4][2] = 2;
                m[4][5] = 3;
                m[4][7] = 2;
                m[4][9] = 2;
                m[4][11] = 2;
                m[4][13] = 2;
                m[4][15] = 3;
                m[4][18] = 2;

                m[6][5] = 2;
                m[6][15] = 2;

                m[8][9] = 2;
                m[8][11] = 2;

                m[10][5] = 3;
                m[10][7] = 2;
                m[10][13] = 2;
                m[10][15] = 3;

                m[12][7] = 2;
                m[12][13] = 2;

                m[14][5] = 3;
                m[14][7] = 2;
                m[14][13] = 2;
                m[14][15] = 3;

                m[16][5] = 2;
                m[16][7] = 2;
                m[16][13] = 2;
                m[16][15] = 2;

                m[18][3] = 2;
                m[18][17] = 2;

                m[20][9] = 2;
                m[20][11] = 2;
            }
            public Matrix()
            {
                m = new int[24][];
                for (int i = 0; i < 24; ++i)
                    m[i] = new int[24];
            }
        }
        Matrix mat;

        public partial class Lee_Algorithm
        {
            private Matrix Lee_Matrix;
            private int[] Queue_y;
            private int[] Queue_x;
            private int p, u; // primul, ultimul

            public direction[] Path;
            public int[] Path_y;
            public int[] Path_x;
            public int k;

            public Lee_Algorithm()
            {
                Lee_Matrix = new Matrix();
                Queue_x = new int[500];
                Queue_y = new int[500];
                p = u = 0;

                Path = new direction[500];
                Path_x = new int[500];
                Path_y = new int[500];
                k = 0;
            }

            public void New_Path_Lee_old(int xo, int yo, int x1, int y1)
            {
                Lee_Matrix.Initialization_of_matrix();
                p = u = 1;
                Queue_x[p] = xo;
                Queue_y[p] = yo;
                Lee_Matrix.m[yo][xo] = 1;

                while (p <= u)
                {
                    xo = Queue_x[p];
                    yo = Queue_y[p];
                    p++;

                    if (xo == x1 && yo == y1)
                        break;

                    if (xo == 0 || xo == 20)
                        continue;

                    if (Lee_Matrix.m[yo + 1][xo] == 0)
                    {
                        Lee_Matrix.m[yo + 1][xo] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo;
                        Queue_y[u] = yo + 1;
                    }

                    if (Lee_Matrix.m[yo - 1][xo] == 0)
                    {
                        Lee_Matrix.m[yo - 1][xo] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo;
                        Queue_y[u] = yo - 1;
                    }

                    if (Lee_Matrix.m[yo][xo + 1] == 0)
                    {
                        Lee_Matrix.m[yo][xo + 1] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo + 1;
                        Queue_y[u] = yo;
                    }

                    if (Lee_Matrix.m[yo][xo - 1] == 0)
                    {
                        Lee_Matrix.m[yo][xo - 1] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo - 1;
                        Queue_y[u] = yo;
                    }
                }

                k = Lee_Matrix.m[y1][x1];

                Path[k] = direction.Null;
                while (k >= 1)
                {
                    Path_x[k] = (x1 - 1) * 30;
                    Path_y[k] = (y1 - 1) * 30;
                    k--;

                    if (x1 > 0 && Lee_Matrix.m[y1][x1 - 1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        Path[k] = direction.Right;
                        x1--;
                        continue;
                    }
                    if (Lee_Matrix.m[y1][x1 + 1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        Path[k] = direction.Left;
                        x1++;
                        continue;
                    }
                    if (Lee_Matrix.m[y1 - 1][x1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        Path[k] = direction.Down;
                        y1--;
                        continue;
                    }
                    if (Lee_Matrix.m[y1 + 1][x1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        Path[k] = direction.Up;
                        y1++;
                        continue;
                    }
                }
            }

            public void New_Path_Lee(int xo, int yo, int x1, int y1)
            {
                Lee_Matrix.Initialization_of_matrix();
                p = u = 1;
                Queue_x[p] = xo;
                Queue_y[p] = yo;
                Lee_Matrix.m[yo][xo] = 1;

                direction[] vd = new direction[8];
                int[] vx = new int[8];
                int[] vy = new int[8];
                int n, j = 0;
                Random rnd = new Random();


                while (p <= u)
                {
                    xo = Queue_x[p];
                    yo = Queue_y[p];
                    p++;

                    if (xo == x1 && yo == y1)
                        break;

                    if (xo == 0 && Lee_Matrix.m[yo][20] == 0)
                    {
                        Lee_Matrix.m[yo][20] = Lee_Matrix.m[yo][xo] + 1;
                        //Lee_Matrix.m[yo][20] = Lee_Matrix.m[yo][xo] + 4;
                        u++;
                        Queue_x[u] = 20;
                        Queue_y[u] = yo;
                    }

                    if (xo == 0 && Lee_Matrix.m[yo][1] == 0)
                    {
                        Lee_Matrix.m[yo][1] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = 1;
                        Queue_y[u] = yo;
                    }

                    if (xo == 20 && Lee_Matrix.m[yo][0] == 0)
                    {
                        Lee_Matrix.m[yo][0] = Lee_Matrix.m[yo][xo] + 1;
                        //Lee_Matrix.m[yo][0] = Lee_Matrix.m[yo][xo] + 4;
                        u++;
                        Queue_x[u] = 0;
                        Queue_y[u] = yo;
                    }

                    if (xo == 20 && Lee_Matrix.m[yo][19] == 0)
                    {
                        Lee_Matrix.m[yo][19] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = 19;
                        Queue_y[u] = yo;
                    }

                    if (xo == 0 || xo == 20)
                        continue;

                    if (Lee_Matrix.m[yo + 1][xo] == 0)
                    {
                        Lee_Matrix.m[yo + 1][xo] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo;
                        Queue_y[u] = yo + 1;
                    }

                    if (Lee_Matrix.m[yo - 1][xo] == 0)
                    {
                        Lee_Matrix.m[yo - 1][xo] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo;
                        Queue_y[u] = yo - 1;
                    }

                    if (Lee_Matrix.m[yo][xo + 1] == 0)
                    {
                        Lee_Matrix.m[yo][xo + 1] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo + 1;
                        Queue_y[u] = yo;
                    }

                    if (Lee_Matrix.m[yo][xo - 1] == 0)
                    {
                        Lee_Matrix.m[yo][xo - 1] = Lee_Matrix.m[yo][xo] + 1;
                        u++;
                        Queue_x[u] = xo - 1;
                        Queue_y[u] = yo;
                    }
                }

                k = Lee_Matrix.m[y1][x1];

                Path[k] = direction.Null;
                while (k >= 1)
                {
                    Path_x[k] = (x1 - 1) * 30;
                    Path_y[k] = (y1 - 1) * 30;
                    k--;
                    n = 0;
                    
                    if (x1 == 0 && Lee_Matrix.m[y1][20] == Lee_Matrix.m[y1][0] - 1)
                    {
                        vd[n] = direction.Right;
                        vx[n] = 20;
                        vy[n] = y1;
                        n++;
                    }

                    if (x1 == 0 && Lee_Matrix.m[y1][1] == Lee_Matrix.m[y1][0] - 1)
                    {
                        vd[n] = direction.Left;
                        vx[n] = 1;
                        vy[n] = y1;
                        n++;
                    }

                    if (x1 == 20 && Lee_Matrix.m[y1][20] == Lee_Matrix.m[y1][19] - 1)
                    {
                        vd[n] = direction.Right;
                        vx[n] = 19;
                        vy[n] = y1;
                        n++;
                    }

                    if (x1 == 20 && Lee_Matrix.m[y1][20] == Lee_Matrix.m[y1][0] - 1)
                    {
                        vd[n] = direction.Left;
                        vx[n] = 0;
                        vy[n] = y1;
                        n++;
                    }

                    if (x1 > 0 && Lee_Matrix.m[y1][x1 - 1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        vd[n] = direction.Right;
                        vx[n] = x1 - 1;
                        vy[n] = y1;
                        n++;
                    }
                    if (Lee_Matrix.m[y1][x1 + 1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        vd[n] = direction.Left;
                        vx[n] = x1 + 1;
                        vy[n] = y1;
                        n++;
                    }
                    if (y1 > 0 && Lee_Matrix.m[y1 - 1][x1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        vd[n] = direction.Down;
                        vx[n] = x1;
                        vy[n] = y1 - 1;
                        n++;
                    }
                    if (Lee_Matrix.m[y1 + 1][x1] == Lee_Matrix.m[y1][x1] - 1)
                    {
                        vd[n] = direction.Up;
                        vx[n] = x1;
                        vy[n] = y1 + 1;
                        n++;
                    }

                    if( n != 0 )
                        j = rnd.Next() % n;
                    Path[k] = vd[j];
                    x1 = vx[j];
                    y1 = vy[j];
                }
            }
        }

        public partial class Mob
        {
            public int step;
            public bool can_do_stuff;
            public Attack Attack_Mod;
            public PictureBox img;
            public direction Command_Go, Go;
            public Lee_Algorithm mob_Lee;

            public void Start_Position(Mob_Type mt, Stream_Read sr)
            {
                Go_Null();
                can_do_stuff = false;
                Attack_Mod = Attack.OFF;

                if (mt == Mob_Type.pac_man)
                {
                    if (sr.text_pictureBox_img == "1")
                        img.Image = Properties.Resources.right;
                    else
                        img.Image = Properties.Resources.lady_right;

                    img.Top = 330; //Y
                    img.Left = 270; //X
                }
                if (mt == Mob_Type.red_ghost)
                {
                    img.Image = Properties.Resources.red_guy;
                    img.Top = 270; //Y
                    img.Left = 240; //X
                }
                if (mt == Mob_Type.pink_ghost)
                {
                    img.Image = Properties.Resources.pink_guy;
                    img.Top = 270; //Y
                    img.Left = 270; //X
                }
                if (mt == Mob_Type.blue_ghost)
                {
                    img.Image = Properties.Resources.blue_guy;
                    img.Top = 270; //Y
                    img.Left = 300; //X
                }
                if (mt == Mob_Type.yellow_ghost)
                {
                    img.Image = Properties.Resources.yellow_guy;
                    img.Top = 270; //Y
                    img.Left = 240; //X
                }
            }

            public void Random_direction(Matrix mat)
            {
                int x, y, n;
                Random rnd = new Random();
                direction[] dir = new direction[4];

                n = 0;
                x = img.Left / 30 + 1;
                y = img.Top / 30 + 1;

                if ((x == 0 || x == 20) && y == 10)
                    return;

                if (mat.m[y - 1][x] == 0 && Go != direction.Down)
                {
                    dir[n] = direction.Up;
                    n++;
                }
                if (mat.m[y + 1][x] == 0 && Go != direction.Up)
                {
                    dir[n] = direction.Down;
                    n++;
                }
                if (mat.m[y][x + 1] == 0 && Go != direction.Left)
                {
                    dir[n] = direction.Right;
                    n++;
                }
                if (mat.m[y][x - 1] == 0 && Go != direction.Right)
                {
                    dir[n] = direction.Left;
                    n++;
                }

                if ( n != 0 )
                Command_Go = dir[(rnd.Next() % n)];
            }

            public void Go_Null()
            {
                Command_Go = Go = direction.Null;
            }

            public Mob(Mob_Type mt, Stream_Read sr)
            {
                step = 5;
                can_do_stuff = false;
                Attack_Mod = Attack.OFF;
                Go_Null();

                if (mt != Mob_Type.pac_man)
                    mob_Lee = new Lee_Algorithm();

                img = new PictureBox();
                img.Width = 30;
                img.Height = 30;
                img.SizeMode = PictureBoxSizeMode.StretchImage;

                if (mt == Mob_Type.pac_man)
                {
                    if (sr.text_pictureBox_img == "1")
                        img.Image = Properties.Resources.right;
                    else
                        img.Image = Properties.Resources.lady_right;

                    img.Top = 330; //Y
                    img.Left = 270; //X
                }
                if (mt == Mob_Type.red_ghost)
                {
                    img.Image = Properties.Resources.red_guy;
                    img.Top = 210; //Y
                    img.Left = 270; //X
                }
                if (mt == Mob_Type.pink_ghost)
                {
                    img.Image = Properties.Resources.pink_guy;
                    img.Top = 270; //Y
                    img.Left = 270; //X
                }
                if (mt == Mob_Type.blue_ghost)
                {
                    img.Image = Properties.Resources.blue_guy;
                    img.Top = 270; //Y
                    img.Left = 300; //X
                }
                if (mt == Mob_Type.yellow_ghost)
                {
                    img.Image = Properties.Resources.yellow_guy;
                    img.Top = 270; //Y
                    img.Left = 240; //X
                }
            }
        }
        Mob PacMan, RedGhost, PinkGhost, BlueGhost, YellowGhost;

        private PictureBox[] PictureBox_Coin;
        private void Initialize_PictureBox_Coins()
        {
            PictureBox_Coin = new PictureBox[147];

            for (int i = 0; i < 147; ++i)
            {
                PictureBox_Coin[i] = new PictureBox();
                PictureBox_Coin[i].Image = global::Horia_PacMan.Properties.Resources.pacdot_static;
                PictureBox_Coin[i].Size = new System.Drawing.Size(30, 30);
                PictureBox_Coin[i].SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                PictureBox_Coin[i].TabStop = false;
                PictureBox_Coin[i].Tag = "Coin";
            }

            PictureBox_Coin[0].Location = new System.Drawing.Point(30, 30);
            PictureBox_Coin[1].Location = new System.Drawing.Point(60, 30);
            PictureBox_Coin[2].Location = new System.Drawing.Point(90, 30);
            PictureBox_Coin[3].Location = new System.Drawing.Point(120, 30);
            PictureBox_Coin[4].Location = new System.Drawing.Point(150, 30);
            PictureBox_Coin[5].Location = new System.Drawing.Point(180, 30);
            PictureBox_Coin[6].Location = new System.Drawing.Point(210, 30);
            PictureBox_Coin[7].Location = new System.Drawing.Point(240, 30);
            PictureBox_Coin[8].Location = new System.Drawing.Point(300, 30);
            PictureBox_Coin[9].Location = new System.Drawing.Point(330, 30);
            PictureBox_Coin[10].Location = new System.Drawing.Point(360, 30);
            PictureBox_Coin[11].Location = new System.Drawing.Point(390, 30);
            PictureBox_Coin[12].Location = new System.Drawing.Point(420, 30);
            PictureBox_Coin[13].Location = new System.Drawing.Point(450, 30);
            PictureBox_Coin[14].Location = new System.Drawing.Point(480, 30);
            PictureBox_Coin[15].Location = new System.Drawing.Point(510, 30);

            PictureBox_Coin[16].Location = new System.Drawing.Point(120, 60);
            PictureBox_Coin[17].Location = new System.Drawing.Point(240, 60);
            PictureBox_Coin[18].Location = new System.Drawing.Point(300, 60);
            PictureBox_Coin[19].Location = new System.Drawing.Point(420, 60);

            PictureBox_Coin[20].Location = new System.Drawing.Point(30, 90);
            PictureBox_Coin[21].Location = new System.Drawing.Point(60, 90);
            PictureBox_Coin[22].Location = new System.Drawing.Point(90, 90);
            PictureBox_Coin[23].Location = new System.Drawing.Point(120, 90);
            PictureBox_Coin[24].Location = new System.Drawing.Point(150, 90);
            PictureBox_Coin[25].Location = new System.Drawing.Point(180, 90);
            PictureBox_Coin[26].Location = new System.Drawing.Point(210, 90);
            PictureBox_Coin[27].Location = new System.Drawing.Point(240, 90);
            PictureBox_Coin[28].Location = new System.Drawing.Point(270, 90);
            PictureBox_Coin[29].Location = new System.Drawing.Point(300, 90);
            PictureBox_Coin[30].Location = new System.Drawing.Point(330, 90);
            PictureBox_Coin[31].Location = new System.Drawing.Point(360, 90);
            PictureBox_Coin[32].Location = new System.Drawing.Point(390, 90);
            PictureBox_Coin[33].Location = new System.Drawing.Point(420, 90);
            PictureBox_Coin[34].Location = new System.Drawing.Point(450, 90);
            PictureBox_Coin[35].Location = new System.Drawing.Point(480, 90);
            PictureBox_Coin[36].Location = new System.Drawing.Point(510, 90);

            PictureBox_Coin[37].Location = new System.Drawing.Point(30, 120);
            PictureBox_Coin[38].Location = new System.Drawing.Point(120, 120);
            PictureBox_Coin[39].Location = new System.Drawing.Point(180, 120);
            PictureBox_Coin[40].Location = new System.Drawing.Point(360, 120);
            PictureBox_Coin[41].Location = new System.Drawing.Point(420, 120);
            PictureBox_Coin[42].Location = new System.Drawing.Point(510, 120);

            PictureBox_Coin[43].Location = new System.Drawing.Point(30, 150);
            PictureBox_Coin[44].Location = new System.Drawing.Point(60, 150);
            PictureBox_Coin[45].Location = new System.Drawing.Point(90, 150);
            PictureBox_Coin[46].Location = new System.Drawing.Point(120, 150);
            PictureBox_Coin[47].Location = new System.Drawing.Point(180, 150);
            PictureBox_Coin[48].Location = new System.Drawing.Point(210, 150);
            PictureBox_Coin[49].Location = new System.Drawing.Point(240, 150);
            PictureBox_Coin[50].Location = new System.Drawing.Point(300, 150);
            PictureBox_Coin[51].Location = new System.Drawing.Point(330, 150);
            PictureBox_Coin[52].Location = new System.Drawing.Point(360, 150);
            PictureBox_Coin[53].Location = new System.Drawing.Point(420, 150);
            PictureBox_Coin[54].Location = new System.Drawing.Point(450, 150);
            PictureBox_Coin[55].Location = new System.Drawing.Point(480, 150);
            PictureBox_Coin[56].Location = new System.Drawing.Point(510, 150);

            PictureBox_Coin[57].Location = new System.Drawing.Point(120, 180);
            PictureBox_Coin[58].Location = new System.Drawing.Point(420, 180);

            PictureBox_Coin[59].Location = new System.Drawing.Point(120, 210);
            PictureBox_Coin[60].Location = new System.Drawing.Point(420, 210);

            PictureBox_Coin[61].Location = new System.Drawing.Point(120, 240);
            PictureBox_Coin[62].Location = new System.Drawing.Point(420, 240);

            PictureBox_Coin[63].Location = new System.Drawing.Point(120, 270);
            PictureBox_Coin[64].Location = new System.Drawing.Point(420, 270);

            PictureBox_Coin[65].Location = new System.Drawing.Point(120, 300);
            PictureBox_Coin[66].Location = new System.Drawing.Point(420, 300);

            PictureBox_Coin[67].Location = new System.Drawing.Point(120, 330);
            PictureBox_Coin[68].Location = new System.Drawing.Point(420, 330);

            PictureBox_Coin[69].Location = new System.Drawing.Point(120, 360);
            PictureBox_Coin[70].Location = new System.Drawing.Point(420, 360);

            PictureBox_Coin[71].Location = new System.Drawing.Point(30, 390);
            PictureBox_Coin[72].Location = new System.Drawing.Point(60, 390);
            PictureBox_Coin[73].Location = new System.Drawing.Point(90, 390);
            PictureBox_Coin[74].Location = new System.Drawing.Point(120, 390);
            PictureBox_Coin[75].Location = new System.Drawing.Point(150, 390);
            PictureBox_Coin[76].Location = new System.Drawing.Point(180, 390);
            PictureBox_Coin[77].Location = new System.Drawing.Point(210, 390);
            PictureBox_Coin[78].Location = new System.Drawing.Point(240, 390);
            PictureBox_Coin[79].Location = new System.Drawing.Point(300, 390);
            PictureBox_Coin[80].Location = new System.Drawing.Point(330, 390);
            PictureBox_Coin[81].Location = new System.Drawing.Point(360, 390);
            PictureBox_Coin[82].Location = new System.Drawing.Point(390, 390);
            PictureBox_Coin[83].Location = new System.Drawing.Point(420, 390);
            PictureBox_Coin[84].Location = new System.Drawing.Point(450, 390);
            PictureBox_Coin[85].Location = new System.Drawing.Point(480, 390);
            PictureBox_Coin[86].Location = new System.Drawing.Point(510, 390);

            PictureBox_Coin[87].Location = new System.Drawing.Point(30, 420);
            PictureBox_Coin[88].Location = new System.Drawing.Point(120, 420);
            PictureBox_Coin[89].Location = new System.Drawing.Point(240, 420);
            PictureBox_Coin[90].Location = new System.Drawing.Point(300, 420);
            PictureBox_Coin[91].Location = new System.Drawing.Point(420, 420);
            PictureBox_Coin[92].Location = new System.Drawing.Point(510, 420);

            PictureBox_Coin[93].Location = new System.Drawing.Point(60, 450);
            PictureBox_Coin[94].Location = new System.Drawing.Point(120, 450);
            PictureBox_Coin[95].Location = new System.Drawing.Point(150, 450);
            PictureBox_Coin[96].Location = new System.Drawing.Point(180, 450);
            PictureBox_Coin[97].Location = new System.Drawing.Point(210, 450);
            PictureBox_Coin[98].Location = new System.Drawing.Point(240, 450);
            PictureBox_Coin[99].Location = new System.Drawing.Point(270, 450);
            PictureBox_Coin[100].Location = new System.Drawing.Point(300, 450);
            PictureBox_Coin[101].Location = new System.Drawing.Point(330, 450);
            PictureBox_Coin[102].Location = new System.Drawing.Point(360, 450);
            PictureBox_Coin[103].Location = new System.Drawing.Point(390, 450);
            PictureBox_Coin[104].Location = new System.Drawing.Point(420, 450);
            PictureBox_Coin[105].Location = new System.Drawing.Point(480, 450);

            PictureBox_Coin[106].Location = new System.Drawing.Point(60, 480);
            PictureBox_Coin[107].Location = new System.Drawing.Point(120, 480);
            PictureBox_Coin[108].Location = new System.Drawing.Point(180, 480);
            PictureBox_Coin[109].Location = new System.Drawing.Point(360, 480);
            PictureBox_Coin[110].Location = new System.Drawing.Point(420, 480);
            PictureBox_Coin[111].Location = new System.Drawing.Point(480, 480);

            PictureBox_Coin[112].Location = new System.Drawing.Point(30, 510);
            PictureBox_Coin[113].Location = new System.Drawing.Point(60, 510);
            PictureBox_Coin[114].Location = new System.Drawing.Point(90, 510);
            PictureBox_Coin[115].Location = new System.Drawing.Point(120, 510);
            PictureBox_Coin[116].Location = new System.Drawing.Point(180, 510);
            PictureBox_Coin[117].Location = new System.Drawing.Point(210, 510);
            PictureBox_Coin[118].Location = new System.Drawing.Point(240, 510);
            PictureBox_Coin[119].Location = new System.Drawing.Point(300, 510);
            PictureBox_Coin[120].Location = new System.Drawing.Point(330, 510);
            PictureBox_Coin[121].Location = new System.Drawing.Point(360, 510);
            PictureBox_Coin[122].Location = new System.Drawing.Point(420, 510);
            PictureBox_Coin[123].Location = new System.Drawing.Point(450, 510);
            PictureBox_Coin[124].Location = new System.Drawing.Point(480, 510);
            PictureBox_Coin[125].Location = new System.Drawing.Point(510, 510);

            PictureBox_Coin[126].Location = new System.Drawing.Point(30, 540);
            PictureBox_Coin[127].Location = new System.Drawing.Point(240, 540);
            PictureBox_Coin[128].Location = new System.Drawing.Point(300, 540);
            PictureBox_Coin[129].Location = new System.Drawing.Point(510, 540);

            PictureBox_Coin[130].Location = new System.Drawing.Point(30, 570);
            PictureBox_Coin[131].Location = new System.Drawing.Point(60, 570);
            PictureBox_Coin[132].Location = new System.Drawing.Point(90, 570);
            PictureBox_Coin[133].Location = new System.Drawing.Point(120, 570);
            PictureBox_Coin[134].Location = new System.Drawing.Point(150, 570);
            PictureBox_Coin[135].Location = new System.Drawing.Point(180, 570);
            PictureBox_Coin[136].Location = new System.Drawing.Point(210, 570);
            PictureBox_Coin[137].Location = new System.Drawing.Point(240, 570);
            PictureBox_Coin[138].Location = new System.Drawing.Point(270, 570);
            PictureBox_Coin[139].Location = new System.Drawing.Point(300, 570);
            PictureBox_Coin[140].Location = new System.Drawing.Point(330, 570);
            PictureBox_Coin[141].Location = new System.Drawing.Point(360, 570);
            PictureBox_Coin[142].Location = new System.Drawing.Point(390, 570);
            PictureBox_Coin[143].Location = new System.Drawing.Point(420, 570);
            PictureBox_Coin[144].Location = new System.Drawing.Point(450, 570);
            PictureBox_Coin[145].Location = new System.Drawing.Point(480, 570);
            PictureBox_Coin[146].Location = new System.Drawing.Point(510, 570);
        }


        public Map_PM()
        {
            InitializeComponent();
        }
        private void Map_PM_Load(object sender, EventArgs e)
        {
            stream_HighScore = new High_Score_Stream_Game();
            stream_read = new Stream_Read();

            mat = new Matrix();
            mat.Initialization_of_matrix();

            RedGhost = new Mob(Mob_Type.red_ghost, stream_read);
            this.Controls.Add(RedGhost.img);

            PinkGhost = new Mob(Mob_Type.pink_ghost, stream_read);
            this.Controls.Add(PinkGhost.img);

            BlueGhost = new Mob(Mob_Type.blue_ghost, stream_read);
            this.Controls.Add(BlueGhost.img);

            YellowGhost = new Mob(Mob_Type.yellow_ghost, stream_read);
            this.Controls.Add(YellowGhost.img);

            PacMan = new Mob(Mob_Type.pac_man, stream_read);
            this.Controls.Add(PacMan.img);

            Initialize_PictureBox_Coins();
            for(int i = 0; i < 147; ++i)
                this.Controls.Add(PictureBox_Coin[i]);

            PacMan.can_do_stuff = true;
        }


        int Enter1 = 0, Enter2 = 4, Enter3 = 7;
        private long Contor_timer_Enter = -1;
        private long Contor_timer_seconds = -1;
        private long Contor_timer_EatGhosts = 100;
        int k = -1;       
        private void Swap_Attack_Mods(Attack at)
        {
            if( RedGhost.Attack_Mod != Attack.SCARED )
                RedGhost.Attack_Mod = at;
            if (PinkGhost.Attack_Mod != Attack.SCARED)
                PinkGhost.Attack_Mod = at;
            if (BlueGhost.Attack_Mod != Attack.SCARED)
                BlueGhost.Attack_Mod = at;
            if (YellowGhost.Attack_Mod != Attack.SCARED)
                YellowGhost.Attack_Mod = at;
        }
        private void timer_seconds_Tick(object sender, EventArgs e)
        {
            /* iterate Contors */
            {

                if (Contor_timer_Enter <= 1000)
                    Contor_timer_Enter++;
                if (Contor_timer_seconds <= 1000)
                    Contor_timer_seconds++;
                if (Contor_timer_EatGhosts <= 1000)
                    Contor_timer_EatGhosts++;
            }

            if (Contor_timer_Enter >= Enter1)
            {
                RedGhost.can_do_stuff = true;
                PinkGhost.can_do_stuff = true;
                Enter1 = 0;
            }
            if (Contor_timer_Enter >= Enter2)
            {
                BlueGhost.can_do_stuff = true;
                Enter2 = 1;
            }
            if (Contor_timer_Enter >= Enter3)
            {
                YellowGhost.can_do_stuff = true;
                Enter3 = 2;
            }

            //--------------------------------------------------------------------------------

            if (10 <= Contor_timer_seconds && Contor_timer_seconds < 17)
            {
                Swap_Attack_Mods(Attack.OFF);
                return;
            }
            if (17 <= Contor_timer_seconds && Contor_timer_seconds < 37)
            {
                Swap_Attack_Mods(Attack.ON);
                return;
            }

            if (37 <= Contor_timer_seconds && Contor_timer_seconds < 44)
            {
                Swap_Attack_Mods(Attack.OFF);
                return;
            }
            if (44 <= Contor_timer_seconds && Contor_timer_seconds < 64)
            {
                Swap_Attack_Mods(Attack.ON);
                return;
            }

            if (64 <= Contor_timer_seconds && Contor_timer_seconds < 69)
            {
                Swap_Attack_Mods(Attack.OFF);
                return;
            }
            if (69 <= Contor_timer_seconds && Contor_timer_seconds < 89)
            {
                Swap_Attack_Mods(Attack.ON);
                return;
            }

            if (89 <= Contor_timer_seconds && Contor_timer_seconds < 94)
            {
                Swap_Attack_Mods(Attack.OFF);
                return;
            }
            if (94 <= Contor_timer_seconds)
            {
                Swap_Attack_Mods(Attack.ON);
                return;
            }
        }



        private void Do_Lee(Mob mob, Mob_Type mt)
        {
            if (mt == Mob_Type.pac_man)
                return;

            int xo, yo, x1, y1;
            x1 = PacMan.img.Left / 30 + 1;
            y1 = PacMan.img.Top / 30 + 1;

            xo = mob.img.Left / 30 + 1;
            yo = mob.img.Top / 30 + 1;

            // ghost house
            if ((yo == 10 && 9 <= xo && xo <= 11) || (yo == 9 && xo == 10))
                return;

            if (((xo == 2 || xo == 3 || xo == 17 || xo == 18) && yo == 10) &&
               (((x1 == 7 || x1 == 13) && y1 == 10) ||
                (x1 == 2 && y1 == 6) ||
                (x1 == 2 && y1 == 14) ||
                (x1 == 18 && y1 == 6) ||
                (x1 == 18 && y1 == 14)))
                return;

            if ( mt == Mob_Type.red_ghost || mt == Mob_Type.blue_ghost )
                mob.mob_Lee.New_Path_Lee(xo, yo, x1, y1);
            else
                mob.mob_Lee.New_Path_Lee_old(xo, yo, x1, y1);
        }
        private void Command_ghost(Mob mob, Mob_Type mt)
        {
            if (mt == Mob_Type.pac_man)
                return;

/*          if(mob is in The Ghost House)  */{

                int i, j; // i-y j-x
                i = mob.img.Left / 30 + 1; j = mob.img.Top / 30 + 1;

                if (mob.img.Top % 30 == 0 && mob.img.Left % 30 == 0)
                {
                    if (j == 10 && i == 10)
                    {
                        mob.Go_Null();
                        mob.Go = direction.Up;
                        return;
                    }
                    if (j == 10 && i == 9)
                    {
                        mob.Go_Null();
                        mob.Go = direction.Right;
                        return;
                    }
                    if (j == 10 && i == 11)
                    {
                        mob.Go_Null();
                        mob.Go = direction.Left;
                        return;
                    }
                }
                else
                {
                    if ((j == 10 && 9 <= i && i <= 11) || (j == 9 && i == 10))
                        return;
                }
            }

            if (mob.Attack_Mod == Attack.SCARED)
            {
                mob.Random_direction(mat);
                return;
            }

            if (mob.Attack_Mod == Attack.OFF)
            {
                mob.Random_direction(mat);
                return;
            }

            if (mob.Attack_Mod == Attack.ON)
            {
                int K = mob.mob_Lee.k;
                if (mob.img.Left != mob.mob_Lee.Path_x[K] || mob.img.Top != mob.mob_Lee.Path_y[K])
                    mob.mob_Lee.k++;
                if( mob.mob_Lee.k < 500 )
                    mob.Command_Go = mob.mob_Lee.Path[mob.mob_Lee.k];
            }
        }

        private void Move_mob(Mob mob)
        {
            int i, j;
            i = mob.img.Top / 30 + 1; j = mob.img.Left / 30 + 1;

            if ((j <= 0 || j >= 20) && i == 10)
                principal_timer.Interval = 10;
            else
                principal_timer.Interval = 18;

            if (mob.Go == direction.Up)
                mob.img.Top -= mob.step;
            if (mob.Go == direction.Down)
                mob.img.Top += mob.step;
            if (mob.Go == direction.Right)
                mob.img.Left += mob.step;
            if (mob.Go == direction.Left)
                mob.img.Left -= mob.step;
        }
        private void Teleportation(Mob mob)
        {
            if (mob.img.Left <= -30 && mob.img.Top == 270)
                mob.img.Left = 570;
            else
            if (mob.img.Left >= 570 && mob.img.Top == 270)
                mob.img.Left = -30;
        }
        private void Change_Direction(Mob mob, Mob_Type mt)
        {
            if (mob.img.Top % 30 == 0 && mob.img.Left % 30 == 0)
            {
                int i, j;
                i = mob.img.Top / 30 + 1; j = mob.img.Left / 30 + 1;

                if ((j <= 0 || j >= 20) && i == 10)
                    return;

                if (mob.Command_Go == direction.Up && mat.m[i - 1][j] == 0)
                {
                    mob.Go_Null();
                    mob.Go = direction.Up;
                    if (mt == Mob_Type.pac_man)
                        if (stream_read.text_pictureBox_img == "1")
                            mob.img.Image = Properties.Resources.up;
                        else
                            mob.img.Image = Properties.Resources.lady_up;
                }
                if (mob.Command_Go == direction.Down && mat.m[i + 1][j] == 0)
                {
                    mob.Go_Null();
                    mob.Go = direction.Down;
                    if (mt == Mob_Type.pac_man)
                        if (stream_read.text_pictureBox_img == "1")
                            mob.img.Image = Properties.Resources.down;
                        else
                            mob.img.Image = Properties.Resources.lady_down;
                }
                if (mob.Command_Go == direction.Right && mat.m[i][j + 1] == 0)
                {
                    mob.Go_Null();
                    mob.Go = direction.Right;
                    if (mt == Mob_Type.pac_man)
                        if (stream_read.text_pictureBox_img == "1")
                            mob.img.Image = Properties.Resources.right;
                        else
                            mob.img.Image = Properties.Resources.lady_right;
                }
                if (mob.Command_Go == direction.Left && mat.m[i][j - 1] == 0)
                {
                    mob.Go_Null();
                    mob.Go = direction.Left;
                    if (mt == Mob_Type.pac_man)
                        if (stream_read.text_pictureBox_img == "1")
                            mob.img.Image = Properties.Resources.left;
                        else
                            mob.img.Image = Properties.Resources.lady_left;
                }
            }
        }
        private void Stop_Direction(Mob mob, Mob_Type mt)
        {
            if (mob.img.Top % 30 == 0 && mob.img.Left % 30 == 0)
            {
                int i, j;
                i = mob.img.Top / 30 + 1; j = mob.img.Left / 30 + 1;

                if ((j <= 0 || j >= 20) && i == 10)
                    return;

                if (mob.Go == direction.Up && mat.m[i - 1][j] == -1)
                    mob.Go_Null();
                if (mob.Go == direction.Down && mat.m[i + 1][j] == -1)
                    mob.Go_Null();
                if (mob.Go == direction.Right && mat.m[i][j + 1] == -1)
                    mob.Go_Null();
                if (mob.Go == direction.Left && mat.m[i][j - 1] == -1)
                    mob.Go_Null();
            }
        }
        private void Stuff_to_do_for_mob(Mob mob, Mob_Type mt)
        {
            if (mob.can_do_stuff == false)
                return;

            Stop_Direction(mob, mt);
            Do_Lee(mob, mt);
            Command_ghost(mob, mt);
            Move_mob(mob);
            Teleportation(mob);
            Change_Direction(mob,mt);
            Stop_Direction(mob,mt);
        }

        private void Intersects_with_Ghost(Mob mob, Mob_Type mt)
        {
            int xo, yo, x1, y1;
            x1 = PacMan.img.Left / 30 + 1;
            y1 = PacMan.img.Top / 30 + 1;

            xo = mob.img.Left / 30 + 1;
            yo = mob.img.Top / 30 + 1;

            if((x1 == xo && y1 == yo ) ||
               (x1 + 1 == xo && y1 == yo && Math.Abs(PacMan.img.Left - mob.img.Left)<20) ||
               (x1 - 1 == xo && y1 == yo && Math.Abs(PacMan.img.Left - mob.img.Left)<20) ||
               (x1 == xo && y1 + 1 == yo && Math.Abs(PacMan.img.Top - mob.img.Top) < 20) ||
               (x1 == xo && y1 - 1 == yo && Math.Abs(PacMan.img.Top - mob.img.Top) < 20) )
            {
                if (mob.Attack_Mod == Attack.SCARED)
                {
                    mob.Start_Position(mt, stream_read);
                    Score += 400;
                }
                else // Attack.ON , Attack.OFF
                {
                    Lives--;
                    if (Lives == 2)
                        Live1.Visible = false;
                    if (Lives == 1)
                        Live2.Visible = false;
                    if (Lives == 0)
                        Live3.Visible = false;

                    Contor_timer_Enter = -1;

                    PacMan.Start_Position(Mob_Type.pac_man, stream_read);
                    RedGhost.Start_Position(Mob_Type.red_ghost, stream_read);
                    PinkGhost.Start_Position(Mob_Type.pink_ghost, stream_read);
                    BlueGhost.Start_Position(Mob_Type.blue_ghost, stream_read);
                    YellowGhost.Start_Position(Mob_Type.yellow_ghost, stream_read);

                    PacMan.can_do_stuff = true;
                }
            }
        }
        private void Time_to_EatGhost_SuperCoin(Mob mob, long time_to_eat)
        {
            if (time_to_eat == 0)
            {
                if (mob.Attack_Mod == Attack.SCARED)
                {
                    if (mob.img.Image != Properties.Resources.dark_guy)
                    {
                        mob.img.Image  = Properties.Resources.dark_guy;

                        if (mob.Go == direction.Up)
                        {
                            mob.Go = direction.Down;
                            return;
                        }
                        if (mob.Go == direction.Down)
                        {
                            mob.Go = direction.Up;
                            return;
                        }
                        if (mob.Go == direction.Right)
                        {
                            mob.Go = direction.Left;
                            return;
                        }
                        if (mob.Go == direction.Left)
                        {
                            mob.Go = direction.Right;
                            return;
                        }
                    }
                }
                return;
            }
            if (time_to_eat == 4)
            {
                if (mob.Attack_Mod == Attack.SCARED)
                {
                    if (mob.img.Image != Properties.Resources.darkwhite_guy)
                    {
                        mob.img.Image  = Properties.Resources.darkwhite_guy;
                    }
                }
                return;
            }
            if (time_to_eat == 7)
            {
                RedGhost.img.Image = Properties.Resources.red_guy;
                PinkGhost.img.Image = Properties.Resources.pink_guy;
                BlueGhost.img.Image = Properties.Resources.blue_guy;
                YellowGhost.img.Image = Properties.Resources.yellow_guy;

                RedGhost.Attack_Mod = Attack.OFF;
                PinkGhost.Attack_Mod = Attack.OFF;
                BlueGhost.Attack_Mod = Attack.OFF;
                YellowGhost.Attack_Mod = Attack.OFF;
            }
        }

        private void principal_timer_Tick(object sender, EventArgs e)
        {
            Score_label.Text = "Score: " + Score.ToString();

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    if (x.Tag == "SuperCoin" && x.Visible == true)
                    {
                        if (PacMan.img.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                            Score += 50;
                            Coins++;
                            Contor_timer_EatGhosts = 0;
                            RedGhost.Attack_Mod = Attack.SCARED;
                            PinkGhost.Attack_Mod = Attack.SCARED;
                            BlueGhost.Attack_Mod = Attack.SCARED;
                            YellowGhost.Attack_Mod = Attack.SCARED;
                        }
                    }
                    if (x.Tag == "Coin" && x.Visible == true)
                    {
                        if (PacMan.img.Bounds.IntersectsWith(x.Bounds))
                        {
                            x.Visible = false;
                            Score += 10;
                            Coins++;
                        }
                    }
                }
            }
           

            Intersects_with_Ghost(RedGhost, Mob_Type.red_ghost);
            Intersects_with_Ghost(PinkGhost, Mob_Type.pink_ghost);
            Intersects_with_Ghost(BlueGhost, Mob_Type.blue_ghost);
            Intersects_with_Ghost(YellowGhost, Mob_Type.yellow_ghost);

            Time_to_EatGhost_SuperCoin(RedGhost, Contor_timer_EatGhosts);
            Time_to_EatGhost_SuperCoin(PinkGhost, Contor_timer_EatGhosts);
            Time_to_EatGhost_SuperCoin(BlueGhost, Contor_timer_EatGhosts);
            Time_to_EatGhost_SuperCoin(YellowGhost, Contor_timer_EatGhosts);
            if (Contor_timer_EatGhosts == 0)
                Contor_timer_EatGhosts = 1; 

            Stuff_to_do_for_mob(RedGhost, Mob_Type.red_ghost);
            Stuff_to_do_for_mob(PinkGhost, Mob_Type.pink_ghost);
            Stuff_to_do_for_mob(BlueGhost, Mob_Type.blue_ghost);
            Stuff_to_do_for_mob(YellowGhost, Mob_Type.yellow_ghost);
            Stuff_to_do_for_mob(PacMan, Mob_Type.pac_man);

            if (Coins == 147+4)
                Next_Level();
            if (Lives == 0)
                Game_is_Over();
        }


        private void OpenNewForm()
        {
            Menu_PM f = new Menu_PM();
            f.Location = this.Location;
            Application.Run(f);
        }
        private async void Return_button_Click(object sender, EventArgs e)
        {
            if (PlayerName_pictureBox.Visible == true)
            {
                PlayerName_label.Text = "New High Score !\nPlease add a name:";
                return;
            }

            Thread th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            await Task.Delay(600);
            this.Close();
        }

        private void Return_button_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer_seconds.Enabled == false)
                return;

            if (e.KeyCode == Keys.P)
            {
                if (principal_timer.Enabled == true)
                    principal_timer.Enabled = false;
                else
                    principal_timer.Enabled = true;
            }

            if (principal_timer.Enabled == false)
                return;

            if (stream_read.text_pictureBox_Keys == "1")
            {
                if (e.KeyCode == Keys.Up)
                {
                    PacMan.Command_Go = direction.Up;
                }
                if (e.KeyCode == Keys.Down)
                {
                    PacMan.Command_Go = direction.Down;
                }
                if (e.KeyCode == Keys.Left)
                {
                    PacMan.Command_Go = direction.Left;
                }
                if (e.KeyCode == Keys.Right)
                {
                    PacMan.Command_Go = direction.Right;
                }
            }
            else
            {
                if (e.KeyCode == Keys.W)
                {
                    PacMan.Command_Go = direction.Up;
                }
                if (e.KeyCode == Keys.S)
                {
                    PacMan.Command_Go = direction.Down;
                }
                if (e.KeyCode == Keys.A)
                {
                    PacMan.Command_Go = direction.Left;
                }
                if (e.KeyCode == Keys.D)
                {
                    PacMan.Command_Go = direction.Right;
                }
            }
        }

        private void Return_button_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Right:
                case Keys.Left:
                case Keys.S:
                case Keys.W:
                case Keys.D:
                case Keys.A:
                case Keys.P:
                case Keys.Enter:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void Map_PM_KeyDown(object sender, KeyEventArgs e)
        {
            if (timer_seconds.Enabled == false)
                return;

            if (e.KeyCode == Keys.P)
            {
                if (principal_timer.Enabled == true)
                    principal_timer.Enabled = false;
                else
                    principal_timer.Enabled = true;
            }

            if (principal_timer.Enabled == false)
                return;

            if (stream_read.text_pictureBox_Keys == "1")
            {
                if (e.KeyCode == Keys.Up)
                {
                    PacMan.Command_Go = direction.Up;
                }
                if (e.KeyCode == Keys.Down)
                {
                    PacMan.Command_Go = direction.Down;
                }
                if (e.KeyCode == Keys.Left)
                {
                    PacMan.Command_Go = direction.Left;
                }
                if (e.KeyCode == Keys.Right)
                {
                    PacMan.Command_Go = direction.Right;
                }
            }
            else
            {
                if (e.KeyCode == Keys.W)
                {
                    PacMan.Command_Go = direction.Up;
                }
                if (e.KeyCode == Keys.S)
                {
                    PacMan.Command_Go = direction.Down;
                }
                if (e.KeyCode == Keys.A)
                {
                    PacMan.Command_Go = direction.Left;
                }
                if (e.KeyCode == Keys.D)
                {
                    PacMan.Command_Go = direction.Right;
                }
            }
        }
    }
}
