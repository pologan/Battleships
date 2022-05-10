using System.Collections.Generic;

namespace Battleships.Models.BoardModels
{
    public class Board
    {
        public List<Tile> Tiles { get; set; }

        public Board()
        {
            Tiles = new List<Tile>();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Tiles.Add(new Tile(i, j));
                }
            }
        }
    }
}
