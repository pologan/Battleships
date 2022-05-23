using Battleships.Models.Ships.Abstract;
using Battleships.Models.Ships.Enums;

namespace Battleships.Models.Ships.Concrete
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat()
        {
            Name = "Patrol boat";
            Length = Health = (int)ShipType.PatrolBoat;
            Type = ShipType.PatrolBoat;
        }
    }
}