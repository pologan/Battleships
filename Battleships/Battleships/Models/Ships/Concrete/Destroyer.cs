namespace Battleships.Models.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer() : base()
        {
            Name = "Destroyer";
            Length = Health = (int)ShipType.Destroyer;
            Type = ShipType.Destroyer;
        }
    }
}
