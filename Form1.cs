﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form1 : Form
    {
        bool turn = true; // true  = x , false = o
        int turn_count = 0;
        static string player1,player2;


        public Form1()
        {
            InitializeComponent();
        }

        public static void setplayerName(string n1, string n2)
        {
            player1 = n1;
            player2 = n2;
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By M M M", " TIC TAC TOE ");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            CheckForWinner();
        }
        private void CheckForWinner()
        {
           
            bool there_is_winner = false;
            // horzintol

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                there_is_winner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                there_is_winner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                there_is_winner = true;
            //VERICAL

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                there_is_winner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                there_is_winner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                there_is_winner = true;
            // DIAGONAL
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                there_is_winner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                there_is_winner = true;

            
            if (there_is_winner)
            {
                DisableButtons();

                String Winner = "";
                if (turn)
                {
                    Winner = player2;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    Winner = player1;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                }
                MessageBox.Show(Winner + "Wins!", "Yay");
            }
            else
            {
                if (turn_count == 9)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("DRAW!");
                }
                    
            }
        }
        private void DisableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }//endtry 
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;
           
                foreach (Control c in Controls)
                {
                try
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }//endtry 
                catch { }

            }//end foreach
       

        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";

                else
                    b.Text = "O";
            }//endif
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = ""; 
            }//endif
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void resetWinCountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            o_win_count.Text = "0";
            x_win_count.Text = "0";
            draw_count.Text = "0";

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;
        }
        
    }
}
