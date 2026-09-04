using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tic_Tac_Toe.Properties;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        enPlayer PlayerTurn = enPlayer.Player1;
        stGameStatus gameStatus;
        enum enPlayer
        {
            Player1, Player2
        }
        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }
        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }
        public Form1()
        {
            InitializeComponent();
           
          
        }
        public void ResetButton() { }
        public void GameFinished() {

            lblTurn.Text = "Game Over";
            switch (gameStatus.Winner)
            {

                case enWinner.Player1:

                    lblWinner.Text = "Player1";
                    break;

                case enWinner.Player2:

                    lblWinner.Text = "Player2";
                    break;

                default:

                    lblWinner.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public bool CheckValues(Button b1,Button b2, Button b3) {

            if (b1.Tag.ToString() != "?" && b1.Tag == b2.Tag && b1.Tag == b3.Tag) {
                b1.BackColor = Color.GreenYellow;
                b2.BackColor = Color.GreenYellow;
                b3.BackColor = Color.GreenYellow;

                if (b1.Tag.ToString() == "X")
                {
                    gameStatus.Winner = enWinner.Player1;
                    gameStatus.GameOver = true;
                    GameFinished();
                    return true;
                }
                else
                {
                    gameStatus.Winner = enWinner.Player2;
                    gameStatus.GameOver = true;
                    GameFinished();
                    return true;
                }
            }
            gameStatus.GameOver = false;
            return false;

        }
        public void CheckWinner() {
           
            if (CheckValues(button1, button5, button8))
            {
                return;
            }
            else if (CheckValues(button1, button3, button9))
            {
                return;
            }
            else if (CheckValues(button4, button5, button3))
            {
                return;
            }
            else if (CheckValues(button3, button2, button8))
            {
                return;
            }
            else if (CheckValues(button7, button8, button9))
            {
                return;
            }
            else if (CheckValues(button6, button5, button9))
            {
                return;

            }
            else if (CheckValues(button4, button1, button7))
            {
                return;

            }
            else if (CheckValues(button6, button1, button2))
            {
                return;

            }
           


        }




        // حمل الصورة مرة واحدة (فوق في الـ class أو في الـ constructor)
        Image questionMarkImg = Image.FromFile(@"D:\projects\istockphoto-1334419989-612x612.jpg");

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color Black = Color.FromArgb(255, 255, 255, 255);

            Pen whitePen = new Pen(Black);
            whitePen.Width = 15;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            // whitePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawLine(whitePen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(whitePen, 400, 460, 1050, 460);

            e.Graphics.DrawLine(whitePen, 610, 140, 610, 620);
            e.Graphics.DrawLine(whitePen, 840, 140, 840, 620);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }
        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }
        private void RestartGame()
        {

            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            gameStatus.PlayCount = 0;
            gameStatus.GameOver = false;
            gameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";



        }
        public void ChangeImage(Button btn) {

            if (btn.Tag.ToString()=="?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        {
                            btn.Image = Resources.X;
                            PlayerTurn = enPlayer.Player2;
                            lblTurn.Text = PlayerTurn.ToString();
                            btn.Tag = "X";
                            gameStatus.PlayCount++;
                            CheckWinner();
                            break;
                        }
                    case enPlayer.Player2:
                        {
                            btn.Image = Resources.O;
                            PlayerTurn = enPlayer.Player1;
                            lblTurn.Text = PlayerTurn.ToString();
                            btn.Tag = "Y";
                            gameStatus.PlayCount++;
                            CheckWinner();
                            break;
                        }



                }


            }
            else

            {
                MessageBox.Show("Wrong Choice", "Worng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                if (!gameStatus.GameOver && gameStatus.PlayCount == 9)
                {
                gameStatus.GameOver = true;
                gameStatus.Winner = enWinner.Draw;
                GameFinished();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ChangeImage(button5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChangeImage(button4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeImage(button3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeImage(button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeImage(button1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ChangeImage(button6);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ChangeImage(button8);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChangeImage(button7);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ChangeImage(button9);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
