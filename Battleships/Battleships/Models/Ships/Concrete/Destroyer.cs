using Battleships.Models.Ships.Abstract;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.Ships.Concrete
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Length = Health = (int)ShipType.Destroyer;
            Type = ShipType.Destroyer;
        }
    }
}