using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Timber
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private bool isPaused = false;
        private int score = 0;

        private Entity background = new Entity();
        private Entity tree = new Entity();
        private Bee bee = new Bee();

        private Cloud cloud1 = new Cloud();
        private Cloud cloud2 = new Cloud();
        private Cloud cloud3 = new Cloud();

        private Text scoreText = new Text();
        private Text startText = new Text();

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

            cloud1.position = new Vector2(-2000, 0);
            cloud2.position = new Vector2(-2000, 0);
            cloud3.position = new Vector2(-2000, 0);

            scoreText.position = new Vector2(100, 15);
            scoreText.textValue = "Score: 0";

            startText.textValue = "Press Enter to Start!";

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
            cloud1.texture = cloudTexture;
            cloud2.texture = cloudTexture;
            cloud3.texture = cloudTexture;

            SpriteFont arial = Content.Load<SpriteFont>("Arial");
            scoreText.font = arial;
            startText.font = arial;
        }

        protected override void Update(GameTime gameTime)
        {
            ProcessInput();

            if (isPaused) return;

            bee.Update(gameTime);
            cloud1.Update(gameTime);
            cloud2.Update(gameTime);
            cloud3.Update(gameTime);

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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            background.Draw(spriteBatch);

            cloud1.Draw(spriteBatch);
            cloud2.Draw(spriteBatch);
            cloud3.Draw(spriteBatch);

            tree.Draw(spriteBatch);
            bee.Draw(spriteBatch);

            scoreText.Draw(spriteBatch, Color.White);
            startText.Draw(spriteBatch, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
