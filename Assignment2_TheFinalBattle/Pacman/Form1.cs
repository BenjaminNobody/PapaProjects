using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 990;     // number cells * size cells + number gaps * size gaps: (30 * 27) + (29 * 4)
        private const int FORMWIDTH = 920;      // 

        //declare the Maze object so it can be used throughout the form
        private Maze maze;
        private Random random;
        private Controller controller;
        private Label scorelabel;

        private int score;
        private int lives;

        public Form1()
        {
            InitializeComponent();

            // set the Properties of the form:
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            BackColor = Color.Black;
            KeyPreview = true;

            // create an instance of a Maze:
            maze = new Maze();

            random = new Random();

            scorelabel = new Label();
            scorelabel.Visible = true;
            scorelabel.Location = new Point(970, 850);
            scorelabel.BackColor = Color.Black;
            scorelabel.ForeColor = Color.Red;

            // important, need to add the maze object to the list of controls on the form
            Controls.Add(maze);
            controller = new Controller(maze,random);

            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;

            lives = 2;
            score = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.PlayGame();
            scorelabel.Text = controller.CountingScore(score).ToString();
            
            if (controller.WinGame(score))
            {
                MessageBox.Show($"Hell yeah mate you have done it. And I can tell you {score} points is one hell of a score");
            }

            if (controller.LooseGame(lives))
            {
                MessageBox.Show($"How unlucky was that! What a bummer...but still you should have seen yourself! You were so close and a " +
                    $"score of {score} points is still a damn good score");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.Left:
                    controller.ChangeDirections(Directions.left);
                    break;
                case Keys.Up:
                    controller.ChangeDirections(Directions.up);
                    break;
                case Keys.Right:
                    controller.ChangeDirections(Directions.right);
                    break;
                case Keys.Down:
                    controller.ChangeDirections(Directions.down);
                    break;
                case Keys.P:
                case Keys.Space:

                    timer1.Enabled = !timer1.Enabled;

                    //if (timer1.Enabled)
                    //{
                    //    timer1.Enabled = false;
                    //}
                    //else
                    //{
                    //    timer1.Enabled = true;
                    //}
                    break;

                case Keys.Q:
                    Application.Exit();
                    break;
                default:
                    break;
            }
        }
    }
}
