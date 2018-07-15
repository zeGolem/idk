using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idk
{
    class Button : GuiElement
    {
        public string t;
        public Button(int posX, int posY, int sizeX, int sizeY, string text, Color color) : base(posX, posY, sizeX, sizeY, color)
        {
            t = text;
        }
        public Button(int posX, int posY, int sizeX, int sizeY, string text, Texture2D texture) : base(posX, posY, sizeX, sizeY, texture)
        {
            t = text;
        }
        public void Draw(SpriteBatch sb, int s, SpriteFont font)
        {
            Draw(sb, s);
            Vector2 tSize = font.MeasureString(t);
            sb.DrawString(font, t, new Vector2(X + ((sX - tSize.X) / 2), (Y + (sY - tSize.Y * 2))), Color.Black);
            
        }
    }
}
