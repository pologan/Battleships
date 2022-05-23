using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Models.BoardModels.Concrete;
using Battleships.Models.BoardModels.Enums;
using Battleships.Models.GameModels.Enums;
using Battleships.Models.Ships.Abstract;
using Battleships.Models.Ships.Concrete;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.GameModels.Concrete
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
            Ships = InitShips();
            Board = new Board(Settings.Width, Settings.Height);
            HitBoard = new HitBoard(Settings.Width, Settings.Height);

            PlaceShips();
        }

        public string Name { get; }

        public Board Board { get; }

        public HitBoard HitBoard { get; }

        public List<Ship> Ships { get; }

        public bool HasLost => Ships.All(s => s.IsSunk);

        private static List<Ship> InitShips()
        {
            var ships = new List<Ship>();

            for (var i = 0; i < Settings.Battleships; i++) ships.Add(new Battleship());
            for (var i = 0; i < Settings.Carriers; i++) ships.Add(new Carrier());
            for (var i = 0; i < Settings.Destroyers; i++) ships.Add(new Destroyer());
            for (var i = 0; i < Settings.PatrolBoats; i++) ships.Add(new PatrolBoat());

            return ships;
        }

        private void PlaceShips()
        {
            var r = new Random(Guid.NewGuid().GetHashCode());

            foreach (var ship in Ships)
            {
                var isOpen = true;
                while (isOpen)
                {
                    var startColumn = r.Next(Settings.Width);
                    var startRow = r.Next(Settings.Height);
                    var endRow = startRow;
                    var endColumn = startColumn;
                    var orientation = (ShipOrientation)(r.Next(10) % 2);

                    if (orientation == ShipOrientation.Horizontal)
                        endColumn += ship.Length - 1;
                    else
                        endRow += ship.Length - 1;

                    if (endRow >= Settings.Height || endColumn >= Settings.Width) continue;

                    var occupiedTiles = Board.Tiles.Where(t => t.Coordinates.Row >= startRow
                                                               && t.Coordinates.Column >= startColumn
                                                               && t.Coordinates.Row <= endRow
                                                               && t.Coordinates.Column <= endColumn).ToList();

                    if (occupiedTiles.Any(ot => ot.Type == TileType.ShipPart)) continue;

                    foreach (var tile in occupiedTiles)
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

            var coords = hitCoords.Any() ? SearchingFire() : RandomFire();

            return coords;
        }

        private TileCoordinates RandomFire()
        {
            var availableTiles = HitBoard.GetOpenTiles();
            var r = new Random(Guid.NewGuid().GetHashCode());
            var tileId = r.Next(availableTiles.Count);

            return availableTiles[tileId];
        }

        private TileCoordinates SearchingFire()
        {
            var nearHits = HitBoard.GetNearHitTiles();
            var r = new Random(Guid.NewGuid().GetHashCode());
            var tileId = r.Next(nearHits.Count);

            return nearHits[tileId];
        }

        public FireResult ProcessFire(TileCoordinates coords)
        {
            var tile = Board.Tiles.First(t => t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column);

            if (tile.Type != TileType.ShipPart)
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
            var tile = HitBoard.Tiles.First(t =>
                t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column);

            tile.Type = fireResult == FireResult.Hit ? TileType.Hit : TileType.Miss;
        }
    }
}