namespace FranzToyRobotTest
{
    /// <summary>
    ///  Position class with movement logic
    /// </summary>
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Move(Direction direction)
        {
            return direction switch
            {
                Direction.NORTH => new Position(X, Y + 1),
                Direction.EAST => new Position(X + 1, Y),
                Direction.SOUTH => new Position(X, Y - 1),
                Direction.WEST => new Position(X - 1, Y),
                _ => this
            };
        }
    }
}
