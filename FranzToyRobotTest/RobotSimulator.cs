namespace FranzToyRobotTest
{
    /// <summary>
    /// Orchestrates all components and enforces rules
    /// </summary>
    public class RobotSimulator
    {
        private readonly Robot _robot;
        private readonly Table _table;

        public RobotSimulator(int tableWidth = 5, int tableHeight = 5)
        {
            _robot = new Robot();
            _table = new Table(tableWidth, tableHeight);
        }

        public string? ExecuteCommand(string input)
        {
            var (command, x, y, direction) = CommandParser.Parse(input);

            if (string.IsNullOrEmpty(command))
                return null;

            switch (command)
            {
                case "PLACE":
                    if (x.HasValue && y.HasValue && direction.HasValue)
                    {
                        var position = new Position(x.Value, y.Value);
                        if (_table.IsValidPosition(position))
                        {
                            _robot.Place(position, direction.Value);
                        }
                    }
                    return null;

                case "MOVE":
                    var nextPosition = _robot.GetNextPosition();
                    if (nextPosition != null && _table.IsValidPosition(nextPosition))
                    {
                        _robot.Move();
                    }
                    return null;

                case "LEFT":
                    _robot.TurnLeft();
                    return null;

                case "RIGHT":
                    _robot.TurnRight();
                    return null;

                case "REPORT":
                    return _robot.Report();

                case "STATUS":
                    return _robot.GetStatus();

                default:
                    return null;
            }
        }
    }
}
