namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        public enum Player
        {
            X, O
        }

        Player currentPlayer;
        Random random = new Random();
        int playerWinsCount = 0;
        int CPUWinsCount = 0;
        List<Button> buttons;

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
            if (buttons.Count > 0) 
            { 
                int index = random.Next(buttons.Count);
                currentPlayer = Player.O;
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].Enabled= false;
                buttons[index].BackColor = Color.Red;
                buttons.RemoveAt(index);
                CheckGame();
                CPUtimer.Stop();
            }
        }

        private void PlayerClickButon(object sender, EventArgs e)
        {
            var button = (Button)sender;

            currentPlayer = Player.X;
            button.Text = currentPlayer.ToString();
            button.Enabled = false;
            button.BackColor = Color.Green;
            buttons.Remove(button);
            CheckGame();
            CPUtimer.Start();

        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" 
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                CPUtimer.Stop();
                MessageBox.Show("Player Wins");
                playerWinsCount++;
                label1.Text = "Player Wins: " + playerWinsCount;
                RestartGame();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                     || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                     || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                     || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                     || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                     || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                     || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                     || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                CPUtimer.Stop();
                MessageBox.Show("CPU Wins");
                CPUWinsCount++;
                label2.Text = "CPU Wins: " + CPUWinsCount;
                RestartGame();
            }
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4, button5, button6, button7, button8, button9 };

            foreach (Button x in buttons)
            { 
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            }
        }
    }
}