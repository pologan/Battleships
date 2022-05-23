using System.Collections.Generic;

namespace Battleships.Models.BoardModels.Concrete
{
    public class Board
    {
        public Board(int width, int height)
        {
            Tiles = new List<Tile>();
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
                Tiles.Add(new Tile(i, j));
        }

        public List<Tile> Tiles { get; }
    }
}