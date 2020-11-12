using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public class Pacman : Creature
    {
        private bool eatencherry;
        private bool mouthopen;
        public Pacman(Maze maze)
            : base(maze)
        {
            // creating the List positions, so in runtime they only have to be changed not be deleted and created new
            images.Add(Properties.Resources.pacman_right_1);        //image that gets drawn
            images.Add(Properties.Resources.pacman_right_1);        //image open mouth
            images.Add(Properties.Resources.pacman_right_2);        //image closed mouth
            direction = Directions.right;
            currentdirection = direction;
            position = new Point(15, 22);
            mouthopen = true;
        }

        public override void Draw()
        {
            maze.Rows[position.Y].Cells[position.X].Value = images[0];
        }

        public void MovePacman()
        {
            // so he is only changing the pictures when the direction gets changed
            if (currentdirection != direction)
            {
                SetPicturesDirections();
            }

            if (CheckNoWallHit())
            {
                Move();
            }
            
            currentdirection = direction;
            MouthMove();
        }

        private void SetPicturesDirections()
        {
            for (int i = 1; i < images.Count; i++)
            {
                images[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject($"pacman_{direction.ToString()}_{i.ToString()}");
            }
        }

        private void MouthMove()
        {
            if (mouthopen)
            {
                images[0] = images[2];
                mouthopen = false;
            }
            else
            {
                images[0] = images[1];
                mouthopen = true;
            }
        }

        //public bool EatingCherry(int score)
        //{

        //}

        private void SettingPacmanpositononMaze()
        {

        }

        public int EatingKibble(int score, Maze maze)
        {
            int pacpos = position.Y * 30 + position.X;

            if (maze.CurrentMap.Substring((pacpos), 1) == "k")
            {
                score = score + 10;
                //maze.CurrentMap.Substring((position.Y * 30 + position.X), 1).Replace("k", "b");
                maze.CurrentMap = $"{maze.CurrentMap.Substring(0,pacpos)}b{maze.CurrentMap.Substring(pacpos+1)}";
                //maze.Rows[position.Y].Cells[position.X].Value = maze.Blank;
                maze.NKibbles--;
            }
            return score;
        }
    }
}
