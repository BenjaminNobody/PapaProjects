using System;
using System.Collections.Generic;
using System.Drawing;
namespace Pacman
{
    public class Ghost : Creature
    {
        private const int ODS = 5;
        
        private string name;
        private Random random;
        public Ghost(Maze maze, Random random)
            : base(maze)
        {
            // creating the List positions, so in runtime they only have to be changed not be deleted and created new
            images.Add(Properties.Resources.pinky_up);        //image that gets drawn
            images.Add(Properties.Resources.crazy_1);        //image when eaten a cherry
            images.Add(Properties.Resources.crazy_2);        //image when nearly down with cherry
            direction = Directions.up;
            position.X = random.Next(30);
            position.Y = random.Next(30);
        }

        public override void Draw()
        {
            maze.Rows[position.Y].Cells[position.X].Value = images[0];
        }

        public override void Move()
        {
            //if (CheckWallHit(pacman))
            //{
            //    SetPicturesDirections();
            //    switch (direction)
            //    {
            //        case Directions.up:
            //            position.Y = position.Y + 27;
            //            break;

            //        case Directions.down:
            //            position.Y = position.Y + 27;
            //            break;

            //        case Directions.left:
            //            position.X = position.X + 27;
            //            break;

            //        case Directions.right:
            //            position.X = position.X + 27;
            //            break;

            //        default:
            //            break;
            //    }
            //}
        }

        private void SetPicturesDirections()
        {
                images[0] = (Bitmap)Properties.Resources.ResourceManager.GetObject($"{name}_{direction.ToString()}");
        }

        //public void GoingCrazy()
        //{
        //    images[0] = images[1];
        //}

        private Directions SetDirections()
        {
            if (random.Next(10)> ODS)
            {

            }

            return direction;
        }
    }
}
