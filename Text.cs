using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Timber
{
    class Text
    {
        public SpriteFont font { get; set; }
        public string textValue { get; set; }
        public Vector2 position { get; set; }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.DrawString(font, textValue, position, color);
        }
    }
}
