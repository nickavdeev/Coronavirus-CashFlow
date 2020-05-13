using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class StockSituation : Tile
    {
        public StockSituation(string description, List<Button> buttons) : base(description, buttons)
        {
            Title = "Ситуация на рынке";
        }
    }
}