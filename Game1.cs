﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Timber
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool isPaused = false;
        private bool hasStarted = false;
        private int score = 0;
        private int time = 0;

        private Entity background = new Entity();
        private Entity tree = new Entity();
        private Bee bee = new Bee();

        private Cloud[] clouds = new Cloud[3];

        private Text scoreText = new Text();
        private Text startText = new Text();
        private Text timeText = new Text();

        private KeyboardState currentState;
        private KeyboardState previousState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Set default window size.
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
        }

        protected override void Initialize()
        { 
            background.position = new Vector2(0, 0);
            tree.position = new Vector2(800, 0);
            bee.position = new Vector2(2000, 0);

            for(int i = 0; i < clouds.Length; i++)
            {
                clouds[i] = new Cloud();
                clouds[i].position = new Vector2(-2000, 0);
            }

            scoreText.position = new Vector2(100, 15);
            scoreText.textValue = "Score: 0";

            startText.textValue = "Press Enter to Start!";

            timeText.position = new Vector2(graphics.PreferredBackBufferWidth / 2 - 85, graphics.PreferredBackBufferHeight - 100);
            timeText.textValue = "120";

            // Needs a way of acquring the length of the string to offset the top left coord system.
            startText.position = new Vector2(graphics.PreferredBackBufferWidth / 2 - 380, graphics.PreferredBackBufferHeight / 2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background.texture = Content.Load<Texture2D>("background");
            tree.texture = Content.Load<Texture2D>("tree");
            bee.texture = Content.Load<Texture2D>("bee");

            Texture2D cloudTexture = Content.Load<Texture2D>("cloud");
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].texture = cloudTexture;
            }

            SpriteFont arial = Content.Load<SpriteFont>("Arial");
            scoreText.font = arial;
            startText.font = arial;
            timeText.font = arial;
        }

        protected override void Update(GameTime gameTime)
        {
            ProcessInput();

            if (isPaused) return;

            bee.Update(gameTime);

            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].Update(gameTime);
            }

            if(time > 0)
            {
                int delta = (int)gameTime.ElapsedGameTime.TotalSeconds;
                time -= delta;

                timeText.textValue = time.ToString();
            }

            base.Update(gameTime);
        }

        private void ProcessInput()
        {
            previousState = currentState;
            currentState = Keyboard.GetState();

            if (currentState.IsKeyDown(Keys.Escape)) Exit();

            if(!currentState.IsKeyDown(Keys.P) && previousState.IsKeyDown(Keys.P))
            {
                isPaused = !isPaused;
            }
            if(!currentState.IsKeyDown(Keys.Enter) && previousState.IsKeyDown(Keys.Enter))
            {
                score = 0;
                time = 60;
                hasStarted = true;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            background.Draw(spriteBatch);

            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].Draw(spriteBatch);
            }

            tree.Draw(spriteBatch);
            bee.Draw(spriteBatch);

            scoreText.Draw(spriteBatch, Color.White);
            timeText.Draw(spriteBatch, Color.White);

            if(!hasStarted)
            {
                startText.Draw(spriteBatch, Color.White);
            }    

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
