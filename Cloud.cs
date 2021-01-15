using Microsoft.Xna.Framework;

namespace Timber
{
    class Cloud : ScrollableEntity
    {
        public Cloud()
        {
            randomDelay = true;
        }

        protected override void MoveEntity(GameTime gameTime)
        {
            base.MoveEntity(gameTime);

            if(position.X > 1920)
            {
                isActive = false;
            }
        }

        protected override void ResetEntity()
        {
            speed = random.Next(50, 125);
            float height = random.Next(0, 300);

            position = new Vector2(random.Next(-1000, -500), height);

            base.ResetEntity();
        }
    }
}
