using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static idk.Data;

namespace idk
{
    class GuiElement
    {
        public int X, Y, sX, sY;
        public Texture2D texture;
        public Color c;

        public GuiElement(int posX, int posY, int sizeX, int sizeY, Color color)
        {

            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;
            c = color;
            texture = new Texture2D(graphics.GraphicsDevice, 1, 1);
            texture.SetData(new[] { Color.White });

        }

        public GuiElement(int posX, int posY, int sizeX, int sizeY, Texture2D texture2D)
        {

            X = posX;
            Y = posY;
            sX = sizeX;
            sY = sizeY;
            texture = texture2D;

        }


        public bool isMouseOvering(MouseState mState)
        {
            if (mState.X > this.X && mState.X <= this.X + this.sX && mState.Y > this.Y && mState.Y < this.Y + this.sY)
            {
                return true;
            }

            return false;
        }

        public void Draw(SpriteBatch sb, int s)
        {

            sb.Draw(texture, new Rectangle(X , Y , sX , sY ), c);

        }

        public event EventHandler ButtonClick;
        
        public void OnButtonCLick()
        {
            ButtonClick?.Invoke(this, new EventArgs());
        }

        public event EventHandler MouseOver;

        public void OnMouseOver()
        {
            MouseOver?.Invoke(this, new EventArgs());
        }


        public void Update()
        {
            if (isMouseOvering(mState))
            {
                OnMouseOver();
            }
            if(isMouseOvering(mState) && mState.LeftButton == ButtonState.Pressed)
            {
                OnButtonCLick();
            }
        }

    }
}
