using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

namespace Timber
{
    class Bee : Entity
    {
        private Random rand = new Random();
        private bool isActive = false;
        private int speed = 0;

        public override void Update(GameTime gameTime)
        {
            if(isActive)
            {
                MoveBee(gameTime);
            }
            else
            {
                // Wait for 3 seconds before resetting the bee.
                Task.Delay(3000).ContinueWith(t => ResetBee());
            }
        }

        private void ResetBee()
        {
            // Generate random speed
            speed = rand.Next(75, 200);

            // Generate random height
            float height = rand.Next(501);
            position = new Vector2(2000, height);

            isActive = true;
        }

        private void MoveBee(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 position = new Vector2(this.position.X - (speed * delta), this.position.Y);
            this.position = position;

            if(this.position.X < -100)
            {
                isActive = false;
            }
        }
    }
}
