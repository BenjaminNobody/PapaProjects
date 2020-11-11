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

        public Controller(Maze maze, Random random)
        {
            this.maze = maze;
            pacman = new Pacman(maze);
            allghosts = new GhostsManager(maze, random);

        }

        public void PlayGame()
        {
            maze.Draw();
            pacman.MovePacman();
            pacman.Draw();
            allghosts.Move(maze);
            allghosts.Draw();
                //pacman.Move(score);
                //foreach (Ghost ghost in ghosts)
                //{
                //    ghost.Move();
                //}
        }

        public int CountingScore(int score)
        {
            score = pacman.EatingKibble(score, maze);

            return score;
        }

        public bool WinGame(int score)
        {
            bool wingame = false;

            if (maze.NKibbles == score)
            {
                wingame = true;
            }

            return wingame;
        }



        public bool LooseGame(int lives)
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
    }
}