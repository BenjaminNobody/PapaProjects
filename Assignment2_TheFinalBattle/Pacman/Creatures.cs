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
        protected bool freetogo;

        public Creature(Maze maze)
        {
            images = new List<Bitmap>();
            this.maze = maze;
        }

        public abstract void Draw();

        public abstract void Move();

        public bool CheckNoWallHit()
        {
            int CheckX = position.X;
            int CheckY = position.Y;

            switch (direction)
            {
                case Directions.up:
                    CheckY++;
                    break;
                case Directions.left:
                    CheckX++;
                    break;
                case Directions.down:
                    CheckY--;
                    break;
                case Directions.right:
                    CheckX--;
                    break;
                default:
                    break;
            }

            freetogo = true;

            if (maze.Rows[CheckX].Cells[CheckY].Value == maze.Wall)
            {
                freetogo = false;
            }

            return freetogo;
        }

        public Directions Direction
        {
            get => direction;
            set
            {
                if (freetogo)
                {
                    direction = value;
                }
            }
        }

        public List<Bitmap> Images { get => images; set => images = value; }
        public Point Position { get => position; set => position = value; }
    }
}
