namespace Game_library
{
    /// <summary>
    /// The actual 2d coordinates for a position, used for WorldObjects and Creatures
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The X coordinate for a given object, will be used for positioning in the world
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// The Y coordinate for a given object, will be used for positioning in the world
        /// </summary>
        public int Y { get; set; }
        /// <summary>
        /// Constructor for a position, decides where in the world the starting coordinates are
        /// </summary>
        /// <param name="xCoordinate">Starting coordinate for the x axis</param>
        /// <param name="yCoordinate">Starting coordinate for the y axis</param>
        public Position(int xCoordinate, int yCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }
    }
}
