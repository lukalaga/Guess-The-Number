using System;
using System.Drawing;
using System.Windows.Forms;

namespace Number4
{
    public partial class Form1 : Form
    {
        private int guess = 0;
        private static int number = 0;
        private static string msg;
        private static int difference = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void startGame()
        {
            var rand = new Random();
            number = rand.Next(1, 1001); //1001 is the exclusive upper bound number
            txtguess.Clear();
            txtguess.Focus();
            txtguess.Enabled = true;
            txtguess.BackColor = Color.White;
            label3.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            startGame();
            _ = txtguess.Focus();
        }

        private void Txtguess_TextChanged(object sender, EventArgs e)
        {
            try
            {
                guess = Convert.ToInt32(txtguess.Text);

                BackColor = Math.Abs(number - guess) < difference ? Color.Red : Color.Blue;

                if (guess > number)
                {
                    msg = "Too High";
                    txtguess.Focus();
                }
                else if (guess < number)
                {
                    msg = "Too Low";
                    txtguess.Focus();
                }
                else
                {
                    msg = "Correct!";
                    MessageBox.Show("Correct!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BackColor = Color.Green;
                    txtguess.Enabled = false;
                }
                label3.Text = msg;
                //Ater each click assign difference
                difference = Math.Abs(number - guess);
                //math.abs is to avoid negative numbers
            }
            catch (Exception)
            {
            }
        }
    }
}