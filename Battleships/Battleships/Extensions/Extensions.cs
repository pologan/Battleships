using Battleships.Models.BoardModels;
using Battleships.Models.Ships;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Battleships.Extensions
{
    public static class Extensions
    {
        public static string GetSymbol(this TileType tileType)
        {
            switch (tileType)
            {
                
                case TileType.ShipPart:
                    return "S";
                case TileType.Hit:
                    return "X";
                case TileType.Miss:
                    return "0";
                case TileType.Empty:
                default:
                    return "";
            }
        }

        public static void Clear(this Grid grid)
        {
            grid.ColumnDefinitions.Clear();
            grid.RowDefinitions.Clear();
            grid.Children.Clear();
        }
    }
}
