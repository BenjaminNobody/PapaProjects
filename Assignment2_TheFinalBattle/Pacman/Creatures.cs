using System;
using System.Collections.Generic;
using System.Drawing;
namespace Pacman
{
    public abstract class Creature
    {
        protected Point position;
        protected Directions direction;
        protected List<Bitmap> images;
        protected Maze maze;
        protected Directions currentdirection;

        public Creature(Maze maze)
        {
            images = new List<Bitmap>();
            this.maze = maze;
        }

        public abstract void Draw();

        public void Move()
        {
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

        public bool CheckNoWallHit()
        {
            int CheckY = position.Y;
            int CheckX = position.X;

            (CheckY, CheckX) = CheckFieldInfront(CheckY, CheckX);

            //switch (direction)
            //{
            //    case Directions.up:
            //        CheckY--;
            //        break;
            //    case Directions.left:
            //        CheckX--;
            //        break;
            //    case Directions.down:
            //        CheckY++;
            //        break;
            //    case Directions.right:
            //        CheckX++;
            //        break;
            //    default:
            //        break;
            //}

            bool freetogo = true;

            int i = CheckY * 30 + CheckX;

            if (maze.CurrentMap.Substring(i, 1) == "w")
            {
                freetogo = false;
            }

            return freetogo;
        }

        public (int checky, int checkx) CheckFieldInfront(int CheckY, int CheckX)               // using tuple types
        {
            switch (direction)
            {
                case Directions.up:
                    CheckY--;
                    break;
                case Directions.left:
                    CheckX--;
                    break;
                case Directions.down:
                    CheckY++;
                    break;
                case Directions.right:
                    CheckX++;
                    break;
                default:
                    break;
            }
            return (CheckY, CheckX);
        }

        public Directions Direction
        {
            get => direction;
            set => direction = value;
        }

        public List<Bitmap> Images { get => images; set => images = value; }
        public Point Position { get => position; set => position = value; }
    }
}
