using Battleships.Models.BoardModels.Enums;

namespace Battleships.Models.BoardModels.Concrete
{
    public class Tile
    {
        public Tile(int row, int column)
        {
            Coordinates = new TileCoordinates(row, column);
            Type = TileType.Empty;
        }

        public TileType Type { get; set; }

        public TileCoordinates Coordinates { get;}
    }
}