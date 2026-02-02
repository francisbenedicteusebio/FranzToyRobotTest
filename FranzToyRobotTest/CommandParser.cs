namespace FranzToyRobotTest
{
    /// <summary>
    /// Parses command strings into executable actions
    /// </summary>
    public class CommandParser
    {
        public static (string command, int? x, int? y, Direction? direction) Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return (string.Empty, null, null, null);

            var trimmedInput = input.Trim().ToUpper();

            if (trimmedInput.StartsWith("PLACE"))
            {
                var parts = trimmedInput.Split(' ');
                if (parts.Length == 2)
                {
                    var args = parts[1].Split(',');
                    if (args.Length == 3 &&
                        int.TryParse(args[0], out int x) &&
                        int.TryParse(args[1], out int y) &&
                        Enum.TryParse<Direction>(args[2], out Direction direction))
                    {
                        return ("PLACE", x, y, direction);
                    }
                }
                return (string.Empty, null, null, null);
            }

            if (trimmedInput == "MOVE" || trimmedInput == "LEFT" || 
                trimmedInput == "RIGHT" || trimmedInput == "REPORT" || trimmedInput == "STATUS")
            {
                return (trimmedInput, null, null, null);
            }

            return (string.Empty, null, null, null);
        }
    }
}
