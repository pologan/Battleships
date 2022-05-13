namespace Battleships.Models.Ships
{
    public class Carrier : Ship
    {
        public Carrier() : base()
        {
            Name = "Carrier";
            Length = Health = (int)ShipType.Carrier;
            Type = ShipType.Carrier;
        }
    }
}
