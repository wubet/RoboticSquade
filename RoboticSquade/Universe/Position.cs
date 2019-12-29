using RoboticSquade.Interface;


namespace RoboticSquade
{
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
    }
}
