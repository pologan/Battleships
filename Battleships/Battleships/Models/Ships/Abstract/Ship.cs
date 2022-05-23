using System.Collections.Generic;
using Battleships.Models.BoardModels.Concrete;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.Ships.Abstract
{
    public abstract class Ship
    {
        protected Ship()
        {
            Coordinates = new List<TileCoordinates>();
        }

        public string Name { get; set; }

        public int Length { get; set; }

        public List<TileCoordinates> Coordinates { get; }

        public int Health { get; set; }

        public ShipType Type { get; set; }

        public bool IsSunk => Health <= 0;
    }
}