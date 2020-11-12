using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public class Controller
    {
        private const int STARTPACMANX = 200;
        private const int STARTPACMANY = 200;
        private const string STARTDIRECTION = "left";
        
        private const int STARTGHOSTX = 450;
        private const int STARTGHOSTY = 450;

        private Pacman pacman;
        private GhostsManager allghosts;
        private Maze maze;
        private int cherries;
        private int lives;
        private int score;

        public Controller(Maze maze, Random random)
        {
            this.maze = maze;
            lives = 2;
            pacman = new Pacman(maze);
            allghosts = new GhostsManager(maze, random);

        }

        public void PlayGame()
        {
            maze.Draw();
            pacman.MovePacman();
            pacman.Draw();
            CountingScore();
            allghosts.Move(maze);
            allghosts.Draw();

            bool checkcollision = false;
            
            //if (allghosts.CheckCollisionAllghosts(checkcollision))
            //{
            //    lives--;
            //}

        }

        //public int CountingScore()
        //{
        //    int currentscore = pacman.EatingKibble(score, maze);

        //    return currentscore;
        //}
        public void CountingScore()
        {
            score = pacman.EatingKibble(score, maze);
        }


        public bool WinGame()
        {
            bool wingame = false;

            if (maze.NKibbles <= 260)
            {
                wingame = true;
            }

            return wingame;
        }



        public bool LooseGame()
        {
            bool loosegame = false;

            if (lives == 0)
            {
                loosegame = true;
            }

            return loosegame;
        }

        public void ChangeDirections(Directions directions)
        {
            pacman.Direction = directions;
            
        }


        public int Score { get => score; set => score = value; }
        public int Lives { get => lives; set => lives = value; }
    }
}