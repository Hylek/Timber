using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Timber
{
    /// <summary>
    /// Base class that contains data for all game elements.
    /// </summary>
    class Entity
    {
        public Texture2D texture { get; set; }
        public Vector2 position { get; set; }

        public virtual void Init()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
