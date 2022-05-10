namespace Battleships.Models.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Length = (int)ShipType.Destroyer;
            Type = ShipType.Destroyer;
        }
    }
}
