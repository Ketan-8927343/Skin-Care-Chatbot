using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Guessing_Word
{
    public partial class GameFrm : Form
    {
        int attempt = 3;
        bool game = true;
        string[] words;
        string secretword, guessword;
        Random rnd;

        public GameFrm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void startGame()
        {
            attempt = 3;
            game = true;
            words = new string[] { "apple", "banana", "orange", "mango", "cherry", "grape", "pineapple", "watermelon", "kiwi", "papaya", "strawberry", "lemon", "pear", "guava", "dragonfruit", "date", "coconut", "lychee" };
            rnd = new Random();
            int index = rnd.Next(0, words.Length);
            secretword = words[index].ToUpper();
            guessword = "";
            for (int i = 0; i < secretword.Length; i++)
            {
                guessword += "*";
            }
            lblword.Text = guessword;
        }

        private void GameFrm_Load(object sender, EventArgs e)
        {
            startGame();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            guess('A');
        }

        private void guess(char ch)
        {
            if (game)
            {
                if (attempt > 0)
                {
                    if (secretword.Contains(ch))
                    {
                        for (int i = 0; i < secretword.Length; i++)
                        {
                            if (secretword.ToCharArray()[i] == ch)
                            {
                                guessword = guessword.Remove(i, 1);
                                guessword = guessword.Insert(i, "" + ch);
                            }
                        }
                        lblword.Text = guessword;
                        attempt = 3;
                        if (!guessword.Contains("*"))
                        {
                            game = false;
                            MessageBox.Show("You Won!");
                            listBox1.Items.Add("You Won!");
                        }
                    }
                    else
                    {
                        attempt--;
                        MessageBox.Show("Wrong Guess! No of Attempt Left: " + attempt);
                        if (attempt == 0)
                        {
                            game = false;
                            MessageBox.Show("You Lost!");
                            listBox1.Items.Add("You Lost!");
                        }
                    }

                }
                else
                {
                    game = false;
                    MessageBox.Show("You Lost!");
                    listBox1.Items.Add("You Lost!");
                }
            }
            else
            {
                MessageBox.Show("Game is Over");
            }
        }
        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            MessageBox.Show("History Cleared!");
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            guess('B');
        }

        private void label5_Click(object sender, EventArgs e)
        {
            guess('C');
        }

        private void label6_Click(object sender, EventArgs e)
        {
            guess('D');
        }

        private void label7_Click(object sender, EventArgs e)
        {
            guess('E');
        }

        private void label8_Click(object sender, EventArgs e)
        {
            guess('F');
        }

        private void label9_Click(object sender, EventArgs e)
        {
            guess('G');
        }

        private void label10_Click(object sender, EventArgs e)
        {
            guess('H');
        }

        private void label11_Click(object sender, EventArgs e)
        {
            guess('I');
        }

        private void label12_Click(object sender, EventArgs e)
        {
            guess('J');
        }

        private void label13_Click(object sender, EventArgs e)
        {
            guess('K');
        }

        private void label14_Click(object sender, EventArgs e)
        {
            guess('L');
        }

        private void label15_Click(object sender, EventArgs e)
        {
            guess('M');
        }

        private void label16_Click(object sender, EventArgs e)
        {
            guess('N');
        }

        private void label17_Click(object sender, EventArgs e)
        {
            guess('O');
        }

        private void label18_Click(object sender, EventArgs e)
        {
            guess('P');
        }

        private void label19_Click(object sender, EventArgs e)
        {
            guess('Q');
        }

        private void label20_Click(object sender, EventArgs e)
        {
            guess('R');
        }

        private void label21_Click(object sender, EventArgs e)
        {
            guess('S');
        }

        private void label22_Click(object sender, EventArgs e)
        {
            guess('T');
        }

        private void label23_Click(object sender, EventArgs e)
        {
            guess('U');
        }

        private void label24_Click(object sender, EventArgs e)
        {
            guess('V');
        }

        private void label25_Click(object sender, EventArgs e)
        {
            guess('W');
        }

        private void label26_Click(object sender, EventArgs e)
        {
            guess('X');
        }

        private void label27_Click(object sender, EventArgs e)
        {
            guess('Y');
        }

        private void label28_Click(object sender, EventArgs e)
        {
            guess('Z');
        }
    }
}
