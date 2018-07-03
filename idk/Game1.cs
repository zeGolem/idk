using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static idk.Data;

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
        Rect player;
        Rect[] rects = new Rect[2048];


        public Game1()
        {
            Data.graphics = new GraphicsDeviceManager(this);
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
            Data.currColor = Color.White;
            
            font = Content.Load<SpriteFont>("Font");
            Data.graphics.PreferredBackBufferHeight = 720;
            Data.graphics.PreferredBackBufferWidth = 1280;
            Data.graphics.ApplyChanges();

            Data.rect = new Texture2D(Data.graphics.GraphicsDevice, 1, 1);
            Data.rect.SetData(new[] { Color.White });
            player = new Rect(width / 2, height / 2, Color.Beige, spriteBatch, 10, 20);


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

            Data.mousePointer = new Texture2D(GraphicsDevice, 1, 1);
            Data.mousePointer.SetData(new[] { Color.White });

            

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
            Data.timer++;
            
            Data.timeSinceLastKeyStroke--;
            Data.mState = Mouse.GetState();

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            var kstate = Keyboard.GetState();

            if(Data.mState.LeftButton == ButtonState.Pressed || kstate.IsKeyDown(Keys.A))
            {

                rects[Data.rectID] = new Rect(Data.mState.X, Data.mState.Y, Data.currColor, spriteBatch);
                Data.rectID++;
                //Console.WriteLine("Rectangle count is now : " + Data.rectID);

            }

            if (kstate.IsKeyDown(Keys.LeftControl) && kstate.IsKeyDown(Keys.S)&& Data.timeSinceLastKeyStroke <= 0)
            {

                SaveWindow = new SaveMGR(Data.rectsPos, Data.rectID, Data.rectColor);
                SaveWindow.ShowDialog();
                Data.timeSinceLastKeyStroke = 50;

            }
            
            //if (kstate.IsKeyDown(Keys.D) && Data.timeSinceLastKeyStroke <= 0)
            //{
            //    Console.WriteLine(Data.timeSinceLastKeyStroke);
            //    Data.timeSinceLastKeyStroke = 50;
            //}
                

            if (kstate.IsKeyDown(Keys.LeftControl) && kstate.IsKeyDown(Keys.L) && Data.timeSinceLastKeyStroke <= 0)
            {

                LoadMGR loadMGR = new LoadMGR();
                loadMGR.ShowDialog();
                Data.timeSinceLastKeyStroke = 50;

            }
            if(kstate.IsKeyDown(Keys.Left) && Data.timeSinceLastKeyStroke <= 0)
            {
                Data.timeSinceLastKeyStroke = 25;
                Data.colorID--;
            }
            if (kstate.IsKeyDown(Keys.Right) && Data.timeSinceLastKeyStroke <= 0)
            {
                Data.timeSinceLastKeyStroke = 25;
                Data.colorID++;
            }

            if (kstate.IsKeyDown(Keys.F11) && Data.timeSinceLastKeyStroke <= 0)
            {
                Data.timeSinceLastKeyStroke = 25;
                Data.graphics.ToggleFullScreen();
            }
            if (kstate.IsKeyDown(Keys.C))
            {

                Data.rectsPos = new Vector2[4096];
                Data.rectID = 0;

            }
            if (kstate.IsKeyDown(Keys.Q))
            {
                player.X--;
                foreach (Rect o in rects)
                    if (player.isCollliding(o))
                        player.X++;
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

            // TODO: Add your update logic here

            switch (Data.colorID)
            {
                case 0:
                    Data.currColor = Color.White;
                    break;

                case -1:
                    Data.currColor = Color.Blue;
                    break;

                case 1:
                    Data.currColor = Color.Red;
                    break;

                default:
                    Data.currColor = Color.Transparent;
                    break;
            }

            Data.FPS = (int)(1/gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
            Console.WriteLine("Player pos : X={0} Y={1}", player.X, player.Y);
            Console.WriteLine("RecID = {0}", rectID);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Data.height = Data.graphics.PreferredBackBufferHeight;
            Data.width = Data.graphics.PreferredBackBufferWidth;
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            if (Data.rectID != 0)
            {
                //for(int i = 0; i< Data.rectID; i++)
                //{

                //    spriteBatch.Draw(Data.rect, new Rectangle((int)Data.rectsPos[i].X, (int)Data.rectsPos[i].Y, 10, 10), Data.rectColor[i]);

                //}
                /*for (int i = 0; i < lRectId; i++)
                {

                    spriteBatch.Draw(lRects[i], new Rectangle((int)lRectsPos[i].X, (int)lRectsPos[i].Y, 10, 10), Color.Wheat);

                }*/
                foreach(Rect r in rects)
                {
                    if(r!=null)
                        r.Draw(spriteBatch);
                }
            }
            if(player!=null)
                player.Draw(spriteBatch);
                

            spriteBatch.Draw(Data.mousePointer, new Rectangle(Data.mState.X, Data.mState.Y, 10, 10), Color.Chocolate);
            //COLOR SELECTOR

            //SQUARE ARROUND DA COLOR
            spriteBatch.Draw(Data.mousePointer, new Rectangle(Data.width / 2 - 60 / 2 + (Data.colorID * 50), Data.height - 55, 60, 60), Color.Black);
            //DA COLOR THEMSELVES
            spriteBatch.Draw(Data.mousePointer, new Rectangle(Data.width / 2 - 50 / 2, Data.height - 50, 50, 50), Color.White);
            spriteBatch.Draw(Data.mousePointer, new Rectangle(Data.width / 2 - 50 / 2 - 50, Data.height - 50, 50, 50), Color.Blue);
            spriteBatch.Draw(Data.mousePointer, new Rectangle(Data.width / 2 - 50 / 2 + 50, Data.height - 50, 50, 50), Color.Red);


            //WRITING DA STUFF

            spriteBatch.DrawString(font, "Stuff counter : " + Data.rectID, new Vector2(0, 0), Color.Black);
            spriteBatch.End();
            

            base.Draw(gameTime);
        }
        
    }
}
