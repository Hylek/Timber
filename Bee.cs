using Microsoft.Xna.Framework;
using System;
using System.Threading.Tasks;

namespace Timber
{
    /// <summary>
    /// Handles the logic for the little bee that moves across the scene.
    /// Rather than wastefully generate and destroy bee objects, just reset
    /// this one when it reaches the other side of the window!
    /// </summary>
    class Bee : Entity
    {
        private Random rand = new Random();
        private bool isActive = false;
        private int speed = 0;

        /// <summary>
        /// Moves the bee, check if it has gotten to the other side, if it has
        /// then wait 3 seconds before setting new speed and height values.
        /// </summary>
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

        /// <summary>
        /// Generates new speed and height values
        /// </summary>
        private void ResetBee()
        {
            // Generate random speed
            speed = rand.Next(75, 200);

            // Generate random height
            float height = rand.Next(501);
            position = new Vector2(2000, height);

            isActive = true;
        }

        /// <summary>
        /// Move the bee across the screen while checking if it has reached the other side.
        /// </summary>
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
