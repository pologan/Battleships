namespace Battleships.Models.Ships
{
    public abstract class Ship
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public int Health { get; set; }

        public ShipType Type { get; set; }

        public bool IsSunk
        {
            get
            {
                return Health == 0;
            }
        }
    }
}
