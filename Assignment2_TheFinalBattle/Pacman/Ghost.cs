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
            this.random = random;
            
            // creating the List positions, so in runtime they only have to be changed not be deleted and created new
            images.Add(Properties.Resources.pinky_up);        //image that gets drawn
            images.Add(Properties.Resources.crazy_1);        //image when eaten a cherry
            images.Add(Properties.Resources.crazy_2);        //image when nearly down with cherry
            direction = Directions.up;
            currentdirection = direction;

            position.X = 13;
            position.Y = 13;
        }

        public override void Draw()
        {
            maze.Rows[position.Y].Cells[position.X].Value = images[0];
        }

        public void MoveGhost()
        {
            // so he is only changing the pictures when the direction gets changed
            if (currentdirection != direction)
            {
                SetPicturesDirections();
            }
            Move();
            currentdirection = direction;
        }

        private void SetPicturesDirections()
        {
                images[0] = (Bitmap)Properties.Resources.ResourceManager.GetObject($"{name}_{direction.ToString()}");
        }

        //public void GoingCrazy()
        //{
        //    images[0] = images[1];
        //}

        public void SetDirections(Maze maze)
        {
            int checkfrontY = position.Y;
            int checkfrontX = position.X;
            int checkleftY = position.Y;
            int checkleftX = position.X;
            int checkrightY = position.Y;
            int checkrightX = position.X;

            switch (direction)
            {
                case Directions.up:
                    checkfrontY--;
                    checkleftX--;
                    checkrightX++;
                    break;
                case Directions.left:
                    checkfrontX--;
                    checkleftY++;
                    checkrightY--;
                    break;
                case Directions.down:
                     checkfrontY++;
                    checkleftX++;
                    checkrightX--;
                    break;
                case Directions.right:
                    checkfrontX++;
                    checkleftY--;
                    checkrightY++;
                    break;
                default:
                    break;
            }

            int front = checkfrontY * 30 + checkfrontX;
            int left = checkleftY * 30 + checkleftX;
            int right = checkrightY * 30 + checkrightX;

            if (maze.CurrentMap.Substring(front, 1) != "w")
            {
                if (maze.CurrentMap.Substring(left, 1) != "w")
                {
                   if (maze.CurrentMap.Substring(right, 1) != "w")
                    {
                        int directionselector = random.Next(2);

                        switch (directionselector)
                        {
                            case 0:                     // go left
                                switch (direction)
                                {
                                    case Directions.up:
                                        direction = Directions.left;
                                        break;
                                    case Directions.left:
                                        direction = Directions.down;
                                        break;
                                    case Directions.down:
                                        direction = Directions.right;
                                        break;
                                    case Directions.right:
                                        direction = Directions.up;
                                        break;
                                    default:
                                        break;
                                }
                         
                                break;
                            case 1:                     // go right
                                switch (direction)
                                {
                                    case Directions.up:
                                        direction = Directions.right;
                                        break;
                                    case Directions.left:
                                        direction = Directions.up;
                                        break;
                                    case Directions.down:
                                        direction = Directions.left;
                                        break;
                                    case Directions.right:
                                        direction = Directions.down;
                                        break;
                                    default:
                                        break;
                                }
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        int directionselector = random.Next(2);

                        switch (directionselector)
                        {
                            case 0:                     // go left
                                switch (direction)
                                {
                                    case Directions.up:
                                        direction = Directions.left;
                                        break;
                                    case Directions.left:
                                        direction = Directions.down;
                                        break;
                                    case Directions.down:
                                        direction = Directions.right;
                                        break;
                                    case Directions.right:
                                        direction = Directions.up;
                                        break;
                                    default:
                                        break;
                                }

                                break;
                            
                            default:
                                break;
                        }
                    }
                }
            }


        //    do
        //    {
        //        int directionselector = random.Next(3);

        //        switch (directionselector)
        //        {
        //            case 0:
        //                direction = Directions.up;
        //                break;
        //            case 1:
        //                direction = Directions.left;
        //                break;
        //            case 2:
        //                direction = Directions.down;
        //                break;
        //            case 3:
        //                direction = Directions.right;
        //                break;

        //            default:
        //                break;
        //        }

        //    } while (((direction == Directions.left) && (currentdirection == Directions.right)) ||
        //            ((direction == Directions.right) && (currentdirection == Directions.left)) ||
        //            ((direction == Directions.up) && (currentdirection == Directions.down)) ||
        //            ((direction == Directions.down) && (currentdirection == Directions.up)));
        }
        public string Name { get => name; set => name = value; }
    }
}
