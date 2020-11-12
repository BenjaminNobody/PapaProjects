using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Pacman
{
    public class GhostsManager
    {
        private List<Ghost> ghosts;

        public GhostsManager(Maze maze, Random random)
        {

            ghosts = new List<Ghost>();
            for (int i = 0; i < 4; i++)
            {
                ghosts.Add(new Ghost(maze, random));
            }
            AddValues();
        }

        public void Draw()
        {
            foreach (Ghost ghost in ghosts)
            {
                ghost.Draw();
            }
        }

        private void AddValues()
        {
            ghosts[0].Images[0] = Properties.Resources.blinky_up;
            ghosts[0].Position = new Point(12,13);
            ghosts[0].Name = "blinky";
            ghosts[1].Images[0] = Properties.Resources.pinky_up;
            ghosts[1].Position = new Point(14, 12);
            ghosts[1].Name = "pinky";
            ghosts[2].Images[0] = Properties.Resources.inky_up;
            ghosts[2].Position = new Point(15, 12);
            ghosts[2].Name = "inky";
            ghosts[3].Images[0] = Properties.Resources.clyde_up;
            ghosts[3].Position = new Point(17, 13);
            ghosts[3].Name = "clyde";
        }

        public void Move(Maze maze)
        {
            foreach (Ghost ghost in ghosts)
            {
                ghost.SetDirections(maze);
                ghost.MoveGhost();
            }
        }

        public bool CheckCollisionAllghosts(bool collision)
        {
            foreach (Ghost ghost in ghosts)
            {
                ghost.CheckCollisionPacman(collision);
            }

            return collision;
        }
    }
}
