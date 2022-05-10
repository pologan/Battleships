namespace Battleships.Models.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Length = (int)ShipType.Carrier;
            Type = ShipType.Carrier;
        }
    }
}
