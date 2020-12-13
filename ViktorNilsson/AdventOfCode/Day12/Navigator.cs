namespace AdventOfCode
{
    using System;
    using System.Numerics;

    public class Navigator : InputDataHandler
    {
        public static Quaternion Navigate(string instruction, Quaternion initialPos)
        {

            // Extract command and argument
            char cmd = instruction[0];
            int arg = int.Parse(instruction.Remove(0, 1));

            // Act based on instruction

            // First create Quaternicon that handles compass movements
            float xCompass = (Convert.ToInt32(cmd == 'E') * arg) - (Convert.ToInt32(cmd == 'W') * arg);
            float yCompass = (Convert.ToInt32(cmd == 'N') * arg) - (Convert.ToInt32(cmd == 'S') * arg);
            var compassMovement = new Quaternion(xCompass, yCompass, 0, 0);

            // Handle forward movement
            // TODO: Obtain a unity vector with the same angle as initial position. Then scale the unit vector with argument and add to initial position
            Quaternion normalizedInitial = Quaternion.Normalize(initialPos);
            var forward = normalizedInitial * (Convert.ToInt32(cmd == 'F') * arg);

            var updatedPos = initialPos + compassMovement + forward;

            return updatedPos;
        }

        public static float Deg2Rad(float degrees)
        {
            float radians = (float)(Math.PI / 180) * degrees;
            return radians;
        }
    }
}