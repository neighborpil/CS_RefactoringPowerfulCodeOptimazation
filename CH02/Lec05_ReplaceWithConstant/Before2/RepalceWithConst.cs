using System;

namespace RepalceWithConstant
{
    public static class AstronomyUtils
    {
        private const double GRAVITY = 9.81;

        /// <summary>
        /// Represents the Newton's law of gravity
        /// </summary>
        /// <param name="mass1">mass of object 1</param>
        /// <param name="mass2">mass of object 2</param>
        /// <param name="distance">distance between the objects</param>
        /// <returns>gravitational force exerted between two objects</returns>
        public static double GetGravityForce(double mass1, double mass2, double distance)
        {
            return (GRAVITY * mass1 * mass2)/ Math.Pow(distance, 2);
        }
        /// <summary>
        /// Represents the Kepler's third law
        /// </summary>
        /// <param name="planetMass">planet mass</param>
        /// <param name="radius">satellite mean orbital radius</param>
        /// <returns>satellite orbit period</returns>
        public static double GetSatellitePeriod(double planetMass, double radius)
        {
            return Math.Sqrt((4 * Math.Pow(3.14, 2) * Math.Pow(radius, 3)) / (GRAVITY * planetMass));
        }
        /// <summary>
        /// Calculate the gravitational acceleration
        /// </summary>
        /// <param name="planetMass">planet mass</param>
        /// <param name="radius">radius from the planet center</param>
        /// <returns>gravitational acceleration</returns>
        public static double GravityAcceleration(double planetMass, double radius)
        {
            return GRAVITY * planetMass / Math.Pow(radius, 2);
        }
    }
}
