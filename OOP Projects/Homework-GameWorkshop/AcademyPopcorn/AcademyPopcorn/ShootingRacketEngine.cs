using System;

namespace AcademyPopcorn
{
    // Task 4: Creating a class for the engine of the shooting racket and defining method ShootPlayerRacket()
    public class ShootingRacketEngine : Engine
    {
        public ShootingRacketEngine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : base(renderer, userInterface, sleepTime)
        {
        }

        // Task 13: Implementing the method for shooting racket
        public void ShootPlayerRacker()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
