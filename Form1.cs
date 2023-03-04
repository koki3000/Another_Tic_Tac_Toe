using System;
using System.Reflection;
using System.Xml.Linq;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        int playerWinsCount = 0;
        int CPUWinsCount = 0;
        List<Button> buttons;
        List<string> board;

        public Form1()
        {
            InitializeComponent();
            RestartGame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CPUmove(object sender, EventArgs e)
        {
            currentPlayer = Player.O;
            BestMove();
            CheckGame(currentPlayer.ToString());
            CPUtimer.Stop();

        }

        private void PlayerClickButon(object sender, EventArgs e)
        {
            var button = (Button)sender;
            for (int index = 0; index < 9; index++)
            {
                if (buttons[index] == button)
                {
                    board[index] = "X";
                }
            }
            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Green;

            CheckGame(currentPlayer.ToString());

            CPUtimer.Start();

        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame(string currentPlayer)
        {
            if (CheckWin(currentPlayer))
            {
                CPUtimer.Stop();
                if (currentPlayer == "X")
                {
                    MessageBox.Show("Player Wins");
                    playerWinsCount++;
                    label1.Text = "Player Wins: " + playerWinsCount;
                    RestartGame();
                }
                else if (currentPlayer == "O")
                {
                    CPUtimer.Stop();
                    MessageBox.Show("CPU Wins");
                    CPUWinsCount++;
                    label2.Text = "CPU Wins: " + CPUWinsCount;
                    RestartGame();
                }
            }
            else if (IsDraw())
            {
                CPUtimer.Stop();
                MessageBox.Show("Draw");
                RestartGame();
            }
        }

        private bool CheckWin(string currentPlayer)
        {
            if (board[0] == currentPlayer && board[1] == currentPlayer && board[2] == currentPlayer
                || board[3] == currentPlayer && board[4] == currentPlayer && board[5] == currentPlayer
                || board[6] == currentPlayer && board[7] == currentPlayer && board[8] == currentPlayer
                || board[0] == currentPlayer && board[3] == currentPlayer && board[6] == currentPlayer
                || board[1] == currentPlayer && board[4] == currentPlayer && board[7] == currentPlayer
                || board[2] == currentPlayer && board[5] == currentPlayer && board[8] == currentPlayer
                || board[0] == currentPlayer && board[4] == currentPlayer && board[8] == currentPlayer
                || board[2] == currentPlayer && board[4] == currentPlayer && board[6] == currentPlayer)
                {
                    return true;
                }
                else { return false; }
        }

        private bool IsDraw()
        {
            for (int index = 0; index < 9; index++)
            {
                if (board[index] == "")
                {
                    return false;
                }
            }
            return true;
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };
            board = new List<string> { "", "", "", "", "", "", "", "", "" };
            foreach (Button x in buttons)
            { 
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
            CPUtimer.Start();
        }

        private void BestMove()
        {
            int bestScore = -100;
            int bestMove = 0;
            for (int index = 0; index < 9; index++)
            {

                if (board[index] == "")
                {
                    board[index] = currentPlayer.ToString();
                    int score = MiniMax(0, false);
                    if (score > bestScore)
                    {
                        bestScore = score;
                        bestMove = index;
                    }
                    board[index] = "";
                }
            }

            buttons[bestMove].Text = currentPlayer.ToString();
            board[bestMove] = currentPlayer.ToString();
            buttons[bestMove].Enabled = false;
            buttons[bestMove].BackColor = Color.Red;
        }

        private int MiniMax(int depth, bool isMaximizing)
        {
            int result;
            if (CheckWin("X"))
            {
                result = -1;
                return result;
            }
            else if (CheckWin("O"))
            {
                result = 1;
                return result;
            }
            else if (IsDraw())
            {
                result = 0;
                return result;
            }

            if (isMaximizing)
            {
                int bestScore = -100;
                for (int index = 0; index < 9; index++)
                {
                    if (board[index] == "")
                    {
                        board[index] = "O";
                        int score = MiniMax(depth + 1, false);
                        if (score > bestScore)
                        {
                            bestScore = score;
                        }
                        board[index] = "";
                    }
                }
                return bestScore;
            }
            else
            {
                int bestScore = 100;
                for (int index = 0; index < 9; index++)
                {
                    if (board[index] == "")
                    {
                        board[index] = "X";
                        int score = MiniMax(depth + 1, true);
                        if (score < bestScore)
                        {
                            bestScore = score;
                        }
                        board[index] = "";
                    }
                }
                return bestScore;
            }
        }
    }
}