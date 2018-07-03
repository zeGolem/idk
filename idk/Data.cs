using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace idk
{
    public class Data
    {

        public static Texture2D rect;
        public static int height;
        public static int width;
        public static MouseState mState;
        public static Texture2D mousePointer;
        public static Vector2[] rectsPos = new Vector2[4096];
        public static Color[] rectColor = new Color[4096];
        public static Color currColor = new Color();
        public static int colorID = 0;
        public static int rectID = 0;
        public static int timer;
        public static int timeSinceLastKeyStroke = 0;
        public static int FPS;
        public static GraphicsDeviceManager graphics;
        public static Rect[] rects = new Rect[2048];


        public enum Dirrections { LEFT, RIGHT, UP, DOWN, NONE};
    }
}
