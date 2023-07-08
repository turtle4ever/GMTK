namespace Rooms.Extensions
{
    public static class DirectionExtensions
    {
        public static Direction Clockwise(this Direction dir)
        {
            return (Direction)(((int)dir + 1) % 4 );
        }

        public static Direction CounterClockwise(this Direction dir)
        {
            return (Direction)((3 + (int)dir) % 4);
        }
    }
}