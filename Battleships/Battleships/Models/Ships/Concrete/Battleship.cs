namespace Battleships.Models.Ships
{ 
    public class Battleship : Ship
    {
        public Battleship() : base()
        {
            Name = "Battleship";
            Length = Health = (int)ShipType.Battleship;
            Type = ShipType.Battleship;
        }
    }
}
