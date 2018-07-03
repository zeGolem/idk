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
    class Rect
    {
        SpriteBatch spriteBatch;
        public int X, Y, sX, sY;
        Color c;
        Texture2D rectangleTexture;
        public Rect(int posX, int posY, Color color, SpriteBatch sb, int sizeX = 10, int sizeY = 10)
        {

            rectangleTexture = new Texture2D(Data.graphics.GraphicsDevice, 1, 1);
            rectangleTexture.SetData(new[] { Color.White });
            spriteBatch = sb;
            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;
            c = color;

        }

        public void Draw(SpriteBatch sb)
        {

            sb.Draw(rectangleTexture, new Rectangle(X, Y, sX, sY), c);

        } 
        
        public bool isCollliding(Rect o)
        {
            
            if(o != null && this.X + this.sX >= o.X && this.X <= o.X + o.sX && this.Y + this.sY >= o.Y && this.Y <= o.Y + o.sY)
            {
                return true;
            }
            return false;
            
        }
    }
    
}