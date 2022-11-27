namespace ToyRobot.Application.Validators
{
    public class PlacementValidator : IPlacementValidator
    {
        /// <summary>
        /// Checks if a pair of coordinates are valid on the 5 by 5 board
        /// </summary>
        /// <param name="x">Integer representation of the x position</param>
        /// <param name="y">Integer representation of the y position</param>
        /// <returns>True if the position is valid, false otherwise</returns>
        public bool IsValidPlace(int x, int y)
        {
            return IsValidOnAxis(x) && IsValidOnAxis(y);
        }

        /// <summary>
        /// Checks if an axis position is valid on the 5 by 5 board
        /// </summary>
        /// <param name="pos">Integer representation of the axis position</param>
        /// <returns>True if the position is valid, false otherwise</returns>
        public bool IsValidOnAxis(int pos) => pos is >= 0 and <= 5;
    }
}
