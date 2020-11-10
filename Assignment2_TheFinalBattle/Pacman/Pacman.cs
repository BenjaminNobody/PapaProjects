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
            position = new Point(15, 22);
            mouthopen = true;
        }

        public override void Draw()
        {
            maze.Rows[position.Y].Cells[position.X].Value = images[0];
        }

        public override void Move()
        {
            if (CheckNoWallHit())
            { 
                SetPicturesDirections();
                switch (direction)
                {
                    case Directions.up:
                        position.Y = position.Y - 1;
                        break;

                    case Directions.down:
                        position.Y = position.Y + 1;
                        break;

                    case Directions.left:
                        position.X = position.X - 1;
                        break;

                    case Directions.right:
                        position.X = position.X + 1;
                        break;

                    default:
                        break;
                }
            }
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



        public int EatingKibble(int score, Pacman pacman)
        {
            if (maze.Rows[pacman.position.X].Cells[pacman.position.Y].Value == maze.Kibble)
            {
                score = score + 10;
            }

            return score;
        }
    }
}
