namespace Battleships.Models.Ships
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat() : base()
        {
            Name = "Patrol boat";
            Length = Health = (int)ShipType.PatrolBoat;
            Type = ShipType.PatrolBoat;
        }
    }
}
