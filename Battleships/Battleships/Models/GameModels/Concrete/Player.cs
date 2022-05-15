using Battleships.Models.BoardModels;
using Battleships.Models.Ships;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Models.GameModels
{
    public class Player
    {
        public string Name { get; set; }

        public Board Board { get; set; }

        public HitBoard HitBoard { get; set; }

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
            HitBoard = new HitBoard();

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
                    var startColumn = r.Next(Board.WIDTH);
                    var startRow = r.Next(Board.HEIGHT);
                    var endRow = startRow;
                    var endColumn = startColumn;
                    var orientation = (ShipOrientation)(r.Next(10) % 2); 

                    var tileNumbers = new List<int>();
                    if(orientation == ShipOrientation.Horizontal)
                    {
                        endColumn += ship.Length - 1;
                    }
                    else
                    {
                        endRow += ship.Length - 1;
                    }

                    if (endRow >= Board.HEIGHT || endColumn >= Board.WIDTH)
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
                        ship.Coordinates.Add(tile.Coordinates);
                    }

                    isOpen = false;
                }
            }
        }
        
        public TileCoordinates Fire()
        {
            var hitCoords = HitBoard.GetNearHitTiles();
            TileCoordinates coords;
            if(hitCoords.Any())
            {
                coords = SearchingFire();
            }
            else
            {
                coords = RandomFire();
            }

            return coords;
        }

        private TileCoordinates RandomFire()
        {
            var availableTiles = HitBoard.GetOpenTiles();
            Random r = new Random(Guid.NewGuid().GetHashCode());
            var tileId = r.Next(availableTiles.Count);
            return availableTiles[tileId];
        }

        private TileCoordinates SearchingFire()
        {
            var nearHits = HitBoard.GetNearHitTiles();
            Random r = new Random(Guid.NewGuid().GetHashCode());
            var tileId = r.Next(nearHits.Count);
            return nearHits[tileId];
        }

        public FireResult ProcessFire(TileCoordinates coords)
        {
            var tile = Board.Tiles.First(t => t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column);

            if(tile.Type != TileType.ShipPart)
            {
                tile.Type = TileType.Miss;

                return FireResult.Miss;
            }

            var ship = Ships.First(s => s.Coordinates.Any(c => c.Row == coords.Row && c.Column == coords.Column));
            --ship.Health;

            tile.Type = TileType.Hit;

            return FireResult.Hit;
        }

        public void ProcessFireResult(TileCoordinates coords, FireResult fireResult)
        {
            var tile = HitBoard.Tiles.First(t => t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column);

            if(fireResult == FireResult.Hit)
            {
                tile.Type = TileType.Hit;
            }
            else
            {
                tile.Type = TileType.Miss;
            }
        }
    }
}
