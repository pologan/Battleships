namespace Battleships.Models.Ships
{ 
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Length = (int)ShipType.Battleship;
            Type = ShipType.Battleship;
        }
    }
}
