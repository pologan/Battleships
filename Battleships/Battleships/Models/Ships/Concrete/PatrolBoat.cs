namespace Battleships.Models.Ships
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat()
        {
            Name = "Patrol boat";
            Length = (int)ShipType.PatrolBoat;
            Type = ShipType.PatrolBoat;
        }
    }
}
