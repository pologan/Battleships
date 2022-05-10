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
        }
    }
}
