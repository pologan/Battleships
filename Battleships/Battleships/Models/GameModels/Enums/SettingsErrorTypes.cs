using System.ComponentModel;

namespace Battleships.Models.GameModels.Enums
{
    public enum SettingsErrorTypes
    {
        [Description("Width must be smaller than 12")]
        WidthTooBig,

        [Description("Width must be bigger than 8")]
        WidthTooSmall,

        [Description("Heigth must be smaller than 12")]
        HeightTooBig,

        [Description("Width must be bigger than 8")]
        HeightTooSmall,

        [Description("Too many ships for this board!")]
        TooManyShips
    }
}