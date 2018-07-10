using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static idk.Data;

namespace idk
{
    public class Player : Rect
    {
        public new int X, Y, sX, sY;
        public new Color c;
        public new Texture2D rectangleTexture;
        int s;

        public Player(int posX, int posY, Color color, int sizeX = 10, int sizeY = 10) : base(posX, posY, color, sizeX, sizeY)
        {
            rectangleTexture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new[] { Color.White });
            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;
            c = color;
        }
        public void Update(int scl)
        {
            s = scl;
        }
        new public void Draw(SpriteBatch sb)
        {
            sb.Draw(rectangleTexture, new Rectangle(X, Y, sX * s, sY * s), c);
        }
        new public bool isCollliding(Rect o)
        {
            if (o != null && this.X + this.sX * this.s >= o.X * o.s && this.X <= o.X * o.s + o.sX * o.s && this.Y + this.sY * this.s >= o.Y * o.s && this.Y <= o.Y * o.s + o.sY * o.s)
            {
                Console.WriteLine("called by {0} with arg : {1} and returning true", this.ToString(), o.ToString());
                return true;
            }
            return false;

        }
    }
}
