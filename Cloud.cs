using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

// Essentially the same as the Bee class, I should consider refactor.

namespace Timber
{
    class Cloud : Entity
    {
        private Random rand = new Random();
        private bool isActive = false;
        private int speed = 0;

        public override void Update(GameTime gameTime)
        {
            if(isActive)
            {
                MoveCloud(gameTime);
            }
            else
            {
                Task.Delay(rand.Next(1000, 3000)).ContinueWith(t => ResetCloud());
                isActive = true;
            }
        }

        private void ResetCloud()
        {
            speed = rand.Next(50, 125);

            float height = rand.Next(0, 300);
            position = new Vector2(rand.Next(-1000, -500), height);
        }

        private void MoveCloud(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Vector2 position = new Vector2(this.position.X + (speed * delta), this.position.Y);
            this.position = position;

            if(this.position.X > 1920)
            {
                isActive = false;
            }
        }
    }
}
