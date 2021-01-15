using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

namespace Timber
{
    /// <summary>
    /// Similar to the basic entity, except it moves across the background.
    /// </summary>
    class ScrollableEntity : Entity
    {
        protected int speed = 0;
        protected bool randomDelay = false;
        protected Random random = new Random();
        protected bool isActive = false;

        public override void Update(GameTime gameTime)
        {
            if(isActive)
            {
                MoveEntity(gameTime);
            }
            else
            {
                int delayTime = randomDelay ? random.Next(2000, 6000) : 3000;
                Task.Delay(delayTime).ContinueWith(t => ResetEntity());
            }
        }

        protected virtual void MoveEntity(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 position = new Vector2(this.position.X - (speed * delta), this.position.Y);
            this.position = position;
        }

        protected virtual void ResetEntity()
        {
            isActive = true;
        }
    }
}
