using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static idk.Data;
using Microsoft.Xna.Framework.Input;

namespace idk
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        SaveMGR SaveWindow;
        SpriteFont font;
        SpriteBatch spriteBatch;
        int posXscl, posYscl;
        Rect mousePtr;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

        }
        
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currColor = Color.White;
            
            font = Content.Load<SpriteFont>("Font");
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();

            player = new Player(width / 2, height / 2, Color.Beige, 1, 2);

            this.IsMouseVisible = false;
            this.Window.Title = "idk (a random shit by zegolem)";

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Cross;

            Console.WriteLine("the scale is : {0}", scale);

            mousePtr = new Rect(0, 0, Color.White, 5, 5);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            mousePointer = new Texture2D(GraphicsDevice, 1, 1);
            mousePointer.SetData(new[] { Color.White });

            

            // TODO: use this.Content to load your game content here
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is ] place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            timer++;
            timeSinceLastKeyStroke--;

            mState = Mouse.GetState();

            

            //calculate the scale based on the window height
            scale = (int)Math.Floor((decimal)(height / 50));
            //calculates the position scale
            if (scale != 0)
            {
                posXscl = (int)Math.Floor((decimal)(mState.X / scale));
                posYscl = (int)Math.Floor((decimal)(mState.Y / scale));
            }

            mousePtr.X = mState.X;
            mousePtr.Y = mState.Y;


            var kstate = Keyboard.GetState();

            //default exit thing
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //draw
            if (mState.LeftButton == ButtonState.Pressed || kstate.IsKeyDown(Keys.A))
            {

                //test if there is already a rect drawn here
                bool shouldDraw = true;
                for (int i = 0; i < rectID; i++)
                    if (rects[i].X == posXscl && rects[i].Y == posYscl)
                        shouldDraw = false;
                if (shouldDraw)
                {
                    rects[rectID] = new Rect(posXscl, posYscl, currColor, 1, 1);
                    rectID++;
                }

            }

            //save & load
            if (kstate.IsKeyDown(Keys.LeftControl) && kstate.IsKeyDown(Keys.S)&& timeSinceLastKeyStroke <= 0)
            {

                SaveWindow = new SaveMGR(rectsPos, rectID, rectColor);
                SaveWindow.ShowDialog();
                timeSinceLastKeyStroke = 50;

            }
            if (kstate.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl) && kstate.IsKeyDown(Keys.L) && timeSinceLastKeyStroke <= 0)
            {

                LoadMGR loadMGR = new LoadMGR();
                loadMGR.ShowDialog();
                timeSinceLastKeyStroke = 50;

            }

            //changes the color with the arrow keys
            if(kstate.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Left) && Data.timeSinceLastKeyStroke <= 0)
            {
                timeSinceLastKeyStroke = 25;
                colorID--;
            }
            if (kstate.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Right) && Data.timeSinceLastKeyStroke <= 0)
            {
                timeSinceLastKeyStroke = 25;
                colorID++;
            }


            //fullscreen
            if (kstate.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F11) && Data.timeSinceLastKeyStroke <= 0)
            {
                timeSinceLastKeyStroke = 25;
                graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                graphics.PreferredBackBufferWidth  = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                graphics.ToggleFullScreen();
                
            }

            //clear
            if (kstate.IsKeyDown(Keys.C))
            {

                rects = new Rect[4096];
                rectID = 0;

            }

            //movements
            if (kstate.IsKeyDown(Keys.Q))
            {
                player.X-=1;
                foreach (Rect o in rects)
                    if (player.isCollliding(o))
                        player.X+=scale;
            }
            if (kstate.IsKeyDown(Keys.D))
            {
                player.X++;
                foreach (Rect o in rects)
                    if (player.isCollliding(o))
                        player.X--;
            }
            if (kstate.IsKeyDown(Keys.Z))
            {
                player.Y--;
                foreach (Rect o in rects)
                    if (player.isCollliding(o))
                        player.Y++;
            }
            if (kstate.IsKeyDown(Keys.S))
            {
                player.Y++;
                foreach (Rect o in rects)
                    if (player.isCollliding(o))
                        player.Y--;
            }


            //update the rects
            foreach (Rect r in rects)
                if(r!=null)
                    r.Update(scale);
            if(player!=null)
                player.Update(scale);
            if(mousePtr!=null)
                mousePtr.Update(1);

            //color mgr
            switch (colorID)
            {
                case 0:
                    currColor = Color.White;
                    break;

                case -1:
                    currColor = Color.Blue;
                    break;

                case 1:
                    currColor = Color.Red;
                    break;

                default:
                    currColor = Color.Transparent;
                    break;
            }
            
            //That should give me the framerate of the game, but it doesn't seem to work...
            FPS = (int)(1/gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            height = graphics.PreferredBackBufferHeight;
            width = graphics.PreferredBackBufferWidth;
            GraphicsDevice.Clear(Color.Indigo);



            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (rectID != 0)
            {
                
                foreach(Rect r in rects)
                {
                    if(r!=null)
                        r.Draw(spriteBatch);
                }
            }
            if(player!=null)
                player.Draw(spriteBatch);
            
                

            spriteBatch.Draw(mousePointer, new Rectangle(posXscl * scale, posYscl * scale, scale, scale), Color.Chocolate);

            if (mousePtr != null)
                mousePtr.Draw(spriteBatch);
            //COLOR SELECTOR

            //SQUARE ARROUND DA COLOR
            spriteBatch.Draw(mousePointer, new Rectangle(width / 2 - 60 / 2 + (colorID * 50), height - 55, 60, 60), Color.Black);
            //DA COLOR THEMSELVES
            spriteBatch.Draw(mousePointer, new Rectangle(width / 2 - 50 / 2, height - 50, 50, 50), Color.White);
            spriteBatch.Draw(mousePointer, new Rectangle(width / 2 - 50 / 2 - 50, height - 50, 50, 50), Color.Blue);
            spriteBatch.Draw(mousePointer, new Rectangle(width / 2 - 50 / 2 + 50, height - 50, 50, 50), Color.Red);


            //WRITING DA STUFF

            spriteBatch.DrawString(font, "Things counter : " + rectID, new Vector2(0, 0), Color.Black);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
        
    }
}
