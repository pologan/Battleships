using Battleships.Models.GameModels;
using System.Collections.Generic;

namespace Battleships.Models.BoardModels
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

        public Board(int width, int height)
        {
            Tiles = new List<Tile>();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}
