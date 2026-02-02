namespace FranzToyRobotTest
{
    /// <summary>
    /// table with boundary validation
    /// </summary>
    public class Table
    {
        public int Width { get; }
        public int Height { get; }

        public Table(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X >= 0 && position.X < Width &&
                   position.Y >= 0 && position.Y < Height;
        }
    }
}
