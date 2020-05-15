using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class FixedCosts : Tile
    {
        public FixedCosts(string description, List<Button> buttons, Liability liability) : base(description, buttons, liability)
        {
            Title = TileLabel.FixedCost;
        }
    }
}