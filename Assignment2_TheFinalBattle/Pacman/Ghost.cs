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

        public bool CheckCollisionPacman(bool collision)
        {
            if (true)
            {

            }
            return collision;
        }

        public void SetDirections(Maze maze)
        {
            int checkfrontY = position.Y;
            int checkfrontX = position.X;
            int checkleftY = position.Y;
            int checkleftX = position.X;
            int checkrightY = position.Y;
            int checkrightX = position.X;

            switch (direction)                                                     // set the positions that should be checked
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

            int directionselector = random.Next(3);

            if (maze.CurrentMap.Substring(front, 1) != "w")                     // when straight way is free
            {
                if (maze.CurrentMap.Substring(left, 1) != "w")                  // when left is free as well
                {
                    if (maze.CurrentMap.Substring(right, 1) != "w")             // when there is 3 options for going (straigt/left/right)
                    {
                        switch (directionselector)
                        {
                            case 0:                                             // go left
                                SetDirectionLeft();

                                break;
                            case 1:                                             // go right
                                SetDirectionsRight();
                                break;

                            default:                                            // default is always straight
                                break;
                        }
                    }
                    else                                                        // when there is two options (straights/left)
                    {
                        directionselector = random.Next(2);                     // overriding cause we only need two options now

                        switch (directionselector)
                        {
                            case 0:                                             // go left
                                SetDirectionLeft();

                                break;

                            default:                                            // default is always straight
                                break;
                        }
                    }
                }
                                                                                // 1 option (straight) => dont change anything
            }
            else                                                                // straight is blocked from a wall
            {
                if (maze.CurrentMap.Substring(left, 1) != "w")                  // when left is free
                {
                    if (maze.CurrentMap.Substring(right, 1) != "w")             // when right is free as well -> 2 options (left/right)
                    {
                        directionselector = random.Next(2);                     // overriding cause we only need two options now

                        switch (directionselector)
                        {
                            case 0:                                             // go left
                                SetDirectionLeft();

                                break;
                            case 1:                                             // go right
                                SetDirectionsRight();
                                break;                                          // no default cause straight is not an option
                        }
                    }
                    else                                                        // when only left is an option -> 1 option (left)
                    {
                        SetDirectionLeft();                                     // go left
                    }

                }
                else                                                            // now only right is left -> 1 option (right)
                {
                    SetDirectionsRight();
                }
            }
        }

        private void SetDirectionLeft()                                         // go left
        {
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
        }

        private void SetDirectionsRight()                                       // go right
        {
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
        }
        public string Name { get => name; set => name = value; }
    }
}
