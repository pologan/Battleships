using System;
using System.Collections.Generic;
using System.Text;

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

    }
}
