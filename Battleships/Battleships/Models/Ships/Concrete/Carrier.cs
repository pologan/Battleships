using Battleships.Models.Ships.Abstract;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.Ships.Concrete
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Length = Health = (int)ShipType.Carrier;
            Type = ShipType.Carrier;
        }
    }
}