using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Timber
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Entity background = new Entity();
        private Entity tree = new Entity();
        private Bee bee = new Bee();

        private Cloud cloud1 = new Cloud();
        private Cloud cloud2 = new Cloud();
        private Cloud cloud3 = new Cloud();

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

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            bee.Update(gameTime);
            cloud1.Update(gameTime);
            cloud2.Update(gameTime);
            cloud3.Update(gameTime);

            base.Update(gameTime);
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

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
