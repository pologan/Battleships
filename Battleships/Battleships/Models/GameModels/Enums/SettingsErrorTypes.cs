using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Battleships.Models.GameModels
{
    public enum SettingsErrorTypes
    {
        [Description("Width must be smaller than 12")]
        WidthTooBig,

        [Description("Width must be bigger than 8")]
        WidthTooSmall,

        [Description("Heigth must be smaller than 12")]
        HeigthTooBig,

        [Description("Width must be bigger than 8")]
        HeigthTooSmall,

        [Description("Too many ships for this board!")]
        TooManyShips
    }
}
