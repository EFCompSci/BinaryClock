using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connect4
{
    public partial class FrmConnect4 : Form
    {
        Color[,] grid = new Color[6, 7]; // row, col
        Color goColor = Color.Red;

        public FrmConnect4()
        {
            InitializeComponent();
        }

        private void FrmConnect4_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    grid[row, col] = Color.Green;
                }
            }
            timer1.Enabled = true;
            timer1.Interval = 100;
        }

        private void btncol0_Click(object sender, EventArgs e)
        {
            DoGo(0);
            
        }
        private void btncol1_Click(object sender, EventArgs e)
        {
            DoGo(1);
            
        }

        private void btncol2_Click(object sender, EventArgs e)
        {
            DoGo(2);
            
        }

        private void btncol3_Click(object sender, EventArgs e)
        {
            DoGo(3);
            
        }

        private void btncol4_Click(object sender, EventArgs e)
        {
            DoGo(4);
            
        }

        private void btncol5_Click(object sender, EventArgs e)
        {
            DoGo(5);
            
        }

        private void btncol6_Click(object sender, EventArgs e)
        {
            DoGo(6);
            
        }
        private void DoGo(int col)
        {
            for (int row = 5; row >= 0; row--)  // work up the column
            {
                if (grid[row, col] == Color.Green)
                {
                    if (goColor == Color.Red)
                    {
                        grid[row, col] = Color.Red;
                        this.Controls["lbl" + row + col].BackColor = Color.Red;
                    }
                    else
                    {
                        grid[row, col] = Color.Yellow;
                        this.Controls["lbl" + row + col].BackColor = Color.Yellow;
                    }
                    // quit out of loop
                    break;
                }
            }
            CheckWinner();
            if (goColor == Color.Red)
            {
                goColor = Color.Yellow;
            }
            else
            {
                goColor = Color.Red;
            }
        }

       
            bool ValidCell(int row, int col)
            {
                if (row >= 0 && row <= 5 && col >= 0 && col <= 6)
                {
                    return true;
                }
                

                else
            {
                return false;
            }
            }

            bool CheckRight(int row, int col)
            {
                bool winner = true;
                for (int i = 0; i <= 3; i++)
                {
                if (ValidCell(row, col + i))
                {
                    if (grid[row, col + i] != goColor)
                    {
                        winner = false;
                        break;
                    }
                }
                
                else
                {
                winner = false;
                break;
                }
                }
                return winner;
            }
        bool CheckUp(int col, int row)
        {
            bool winner = true;
            for (int i = 0; i <= 3; i++)
            {
                if (ValidCell(row + i, col))
                {
                    if (grid[row + i, col] != goColor)
                    {
                        winner = false;
                        break;
                    }
                }

                else
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }
        bool CheckDiag(int col, int row)
        {
            bool winner = true;
            for (int i = 0; i <= 3; i++)
            {
                if (ValidCell(row + i, col + i))
                {
                    if (grid[row + i, col + i] != goColor)
                    {
                        winner = false;
                        break;
                    }
                }

                else
                {
                    winner = false;
                    break;
                }
            }
            return winner;
        }


        void CheckWinner()
            {
                string winnerColor = "Red";
                if (goColor == Color.Yellow)
                {
                    winnerColor = "Yellow";
                }

                for (int row = 0; row < 6; row++)
                {
                    for (int col = 0; col < 7; col++)
                    {
                        if (CheckRight(row, col) == true)
                        {
                            MessageBox.Show(winnerColor + " is the winner");
                        }
                        else if (CheckUp(col, row) == true)
                        {
                        MessageBox.Show(winnerColor + " is the winner");
                        }
                        else if (CheckDiag(col, row) == true)
                        {
                        MessageBox.Show(winnerColor + " is the winner");
                        }
                }
                }
            }
        
    }
}
