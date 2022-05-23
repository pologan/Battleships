namespace Battleships.Models.BoardModels.Concrete
{
    public class TileCoordinates
    {
        public TileCoordinates(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; }

        public int Column { get; }
    }
}