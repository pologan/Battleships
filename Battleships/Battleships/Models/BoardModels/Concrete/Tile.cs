namespace Battleships.Models.BoardModels
{
    public class Tile
    {
        public TileType Type { get; set; }

        public TileCoordinates Coordinates { get; set; }

        public Tile(int row, int column)
        {
            Coordinates = new TileCoordinates(row, column);
            Type = TileType.Empty;
        }

        public bool IsRandomAvailable {
            get 
            {
                return (Coordinates.Row % 2 == 0 && Coordinates.Column % 2 == 0) 
                    || (Coordinates.Row % 2 == 1 && Coordinates.Column % 2 == 1);
            }
        }
    }
}
