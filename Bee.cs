using Microsoft.Xna.Framework;

namespace Timber
{
    class Bee : ScrollableEntity
    {
        public Bee()
        {
            randomDelay = false;
        }

        protected override void MoveEntity(GameTime gameTime)
        {
            base.MoveEntity(gameTime);

            if(position.X < -100)
            {
                isActive = false;
            }
        }

        protected override void ResetEntity()
        {
            speed = random.Next(75, 200);
            float height = random.Next(501);

            position = new Vector2(2000, height);

            base.ResetEntity();
        }
    }
}
