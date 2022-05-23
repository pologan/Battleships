using Battleships.Models.Ships.Abstract;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.Ships.Concrete
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Length = Health = (int)ShipType.Battleship;
            Type = ShipType.Battleship;
        }
    }
}