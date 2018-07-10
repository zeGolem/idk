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
    public class Rect
    {
        public int X, Y, sX, sY;
        public Color c;
        public Texture2D rectangleTexture;
        public int rX, rY;
        public int s;
        public Rect(int posX, int posY, Color color, int sizeX = 10, int sizeY = 10)
        {

            rectangleTexture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new[] { Color.White });
            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;
            c = color;
            rX = X * s;
            rY = Y * s;

        }

        public void Draw(SpriteBatch sb)
        {

            sb.Draw(rectangleTexture, new Rectangle(rX, rY, sX * s, sY * s), c);

        } 
        
        public bool isCollliding(Rect o)
        {
            //Console.WriteLine("called by {0} with arg : {1}", this.ToString(), o.ToString());
            if(o != null && this.rX + this.sX >= o.rX && this.rX <= o.rX + o.sX && this.rY + this.sY >= o.rY && this.rY <= o.rY + o.sY)
            {
                Console.WriteLine("called by {0} with arg : {1} and returning true", this.ToString(), o.ToString());
                return true;
            }
            return false;
            
        }
        public void Update(int scl, bool invertSXSYXY = false)
        {
            if (!invertSXSYXY)
            {
                rX = X * scl;
                rY = Y * scl;
            }
            else
            {
                if (scl != 0)
                {
                    Y = rY / scl;
                    X = rX / scl;
                }
            }
            s = scl;
        }
    }
    
}