namespace FranzToyRobotTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var simulator = new RobotSimulator();

            Console.WriteLine("Toy Robot Simulator");
            Console.WriteLine("==================");
            Console.WriteLine();

            if (args.Length > 0 && File.Exists(args[0]))
            {
                Console.WriteLine($"Reading commands from file: {args[0]}");
                Console.WriteLine();
                ExecuteFromFile(simulator, args[0]);
            }
            else
            {
                Console.WriteLine("Enter commands (or type 'EXIT' to quit):");
                Console.WriteLine("Available commands: PLACE X,Y,F, MOVE, LEFT, RIGHT, REPORT");
                Console.WriteLine();
                ExecuteFromConsole(simulator);
            }
        }

        static void ExecuteFromFile(RobotSimulator simulator, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var result = simulator.ExecuteCommand(line);
                        if (result != null)
                        {
                            Console.WriteLine(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        static void ExecuteFromConsole(RobotSimulator simulator)
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Trim().ToUpper() == "EXIT")
                    break;

                var result = simulator.ExecuteCommand(input);
                if (result != null)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
