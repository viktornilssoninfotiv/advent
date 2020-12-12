namespace AdventOfCode
{
    public class Navigator : InputDataHandler
    {
        public static (int latitude, int longitude, int angle) Navigate(string instruction, int initialLat, int initialLong, int initialAngle)
        {
            // Set starting position and angle
            int latitude = initialLat;
            int longitude = initialLong;
            int angle = initialAngle;

            // Extract command and argument
            char cmd = instruction[0];
            int arg = int.Parse(instruction.Remove(0, 1));

            // Act based on instruction

            return (latitude, longitude, angle);
        }
    }
}