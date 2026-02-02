namespace FranzToyRobotTest
{
    /// <summary>
    /// Robot state management with Place, Move, TurnLeft, TurnRight, and Report methods
    /// </summary>
    public class Robot
    {
        public Position? Position { get; private set; }
        public Direction? Facing { get; private set; }
        public bool IsPlaced => Position != null && Facing != null;

        public void Place(Position position, Direction direction)
        {
            Position = position;
            Facing = direction;
        }

        public Position? GetNextPosition()
        {
            if (!IsPlaced || Facing == null)
                return null;

            return Position!.Move(Facing.Value);
        }

        public void Move()
        {
            if (!IsPlaced || Facing == null)
                return;

            Position = Position!.Move(Facing.Value);
        }

        public void TurnLeft()
        {
            if (!IsPlaced || Facing == null)
                return;

            Facing = Facing.Value switch
            {
                Direction.NORTH => Direction.WEST,
                Direction.WEST => Direction.SOUTH,
                Direction.SOUTH => Direction.EAST,
                Direction.EAST => Direction.NORTH,
                _ => Facing.Value
            };
        }

        public void TurnRight()
        {
            if (!IsPlaced || Facing == null)
                return;

            Facing = Facing.Value switch
            {
                Direction.NORTH => Direction.EAST,
                Direction.EAST => Direction.SOUTH,
                Direction.SOUTH => Direction.WEST,
                Direction.WEST => Direction.NORTH,
                _ => Facing.Value
            };
        }

        public string Report()
        {
            if (!IsPlaced || Position == null || Facing == null)
                return string.Empty;

            return $"{Position.X},{Position.Y},{Facing.Value}";
        }

        public string GetStatus()
        {
            if (!IsPlaced)
                return "Robot is not placed on the table";

            return $"Robot is placed and ready (Position: {Position!.X},{Position.Y}, Facing: {Facing!.Value})";
        }
    }
}
