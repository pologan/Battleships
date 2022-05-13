﻿using System.Collections.Generic;
using System.Linq;

namespace Battleships.Models.BoardModels
{
    public class HitBoard : Board
    {
        public List<TileCoordinates> GetNearHitTiles()
        {
            List<Tile> tiles = new List<Tile>();

            var hits = Tiles.Where(t => t.Type == TileType.Hit);
            foreach (var hit in hits)
            {
                tiles.AddRange(GetNearTiles(hit.Coordinates));
            }

            return tiles.Distinct()
                .Where(t => t.Type == TileType.Empty)
                .Select(t => t.Coordinates)
                .ToList();
        }

        public List<Tile> GetNearTiles(TileCoordinates coords)
        {
            List<Tile> tiles = new List<Tile>();

            if(coords.Column > 0)
            {
                tiles.Add(Tiles.First(t => t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column - 1));
            }
            if(coords.Row > 0)
            {
                tiles.Add(Tiles.First(t => t.Coordinates.Row == coords.Row - 1 && t.Coordinates.Column == coords.Column));
            }
            if(coords.Column < Board.WIDTH - 1)
            {
                tiles.Add(Tiles.First(t => t.Coordinates.Row == coords.Row && t.Coordinates.Column == coords.Column + 1));
            }
            if(coords.Row < Board.HEIGHT - 1)
            {
                tiles.Add(Tiles.First(t => t.Coordinates.Row == coords.Row + 1 && t.Coordinates.Column == coords.Column));
            }

            return tiles;
        }

        public List<TileCoordinates> GetOpenTiles()
        {
            return Tiles.Where(t => t.Type == TileType.Empty)
                .Select(t => t.Coordinates)
                .ToList();
        }
    }
}