using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idk
{
    class Gui
    {
        public int X, Y, sX, sY;

        public Gui(int posX, int posY, int sizeX, int sizeY)
        {

            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;

        }

        public bool isMouseOvering(MouseState mState)
        {
            if (mState.X > this.X && mState.X <= this.X + this.sX && mState.Y > this.Y && mState.Y < this.Y + this.sY)
            {
                return true;
            }

            return false;
        }
    }
}
