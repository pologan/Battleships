using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleships.Models.BoardModels;
using Battleships.Models.Ships;

namespace Battleships.Models.GameModels
{
    public class Player
    {
        public string Name { get; set; }

        public Board Board { get; set; }

        public List<Ship> Ships { get; set; }

        public bool HasLost
        {
            get
            {
                return Ships.All(s => s.IsSunk);
            }
        }

        public Player(string name)
        {
            Name = name;
            Ships = new List<Ship>()
            {
                new Battleship(),
                new Carrier(),
                new Destroyer(),
                new Destroyer(),
                new PatrolBoat()
            };
            Board = new Board();

            PlaceShips();
        }

        private void PlaceShips()
        {
            Random r = new Random(Guid.NewGuid().GetHashCode());

            foreach (var ship in Ships)
            {
                var isOpen = true;
                while(isOpen)
                {
                    var startColumn = r.Next(Board.HEIGHT);
                    var startRow = r.Next(Board.WIDTH);
                    var endRow = startRow;
                    var endColumn = startColumn;
                    var orientation = (ShipOrientation)(r.Next(10) % 2); 

                    var tileNumbers = new List<int>();
                    if(orientation == ShipOrientation.Horizontal)
                    {
                        endRow += ship.Length;
                    }
                    else
                    {
                        endColumn += ship.Length;
                    }

                    if(endRow > Board.WIDTH || endColumn > Board.HEIGHT)
                    {
                        isOpen = true;
                        continue;
                    }

                    var occupiedTiles = Board.Tiles.Where(t => t.Coordinates.Row >= startRow
                                                           && t.Coordinates.Column >= startColumn
                                                           && t.Coordinates.Row <= endRow
                                                           && t.Coordinates.Column <= endColumn).ToList();

                    if(occupiedTiles.Any(ot => ot.Type == TileType.ShipPart))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach(var tile in occupiedTiles)
                    {
                        tile.Type = TileType.ShipPart;
                    }

                    isOpen = false;
                }
            }
        }
    }
}
