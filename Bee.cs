using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

namespace Timber
{
    class Bee : Entity
    {
        private Random rand = new Random();
        private bool isActive = false;
        private float speed = 0;

        public override void Update(GameTime dt)
        {
            if(isActive)
            {
                MoveBee(dt);
            }
            else
            {
                Task.Delay(3000).ContinueWith(t => ResetBee());
            }
        }

        private void ResetBee()
        {
            // Generate random speed
            speed = (float)((rand.NextDouble() % 0.15) + 0.15);

            // Generate random height
            float height = rand.Next(501);
            position = new Vector2(2000, height);

            isActive = true;
        }

        private void MoveBee(GameTime dt)
        {
            Vector2 position = new Vector2(this.position.X - (speed * (float)dt.TotalGameTime.TotalSeconds), this.position.Y);
            this.position = position;

            if(this.position.X < -100)
            {
                isActive = false;
            }
        }
    }
}
