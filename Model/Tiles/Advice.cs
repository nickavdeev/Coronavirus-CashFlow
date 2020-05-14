using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class Advice : Tile
    {
        public Advice(string description, List<Button> buttons) : base(description, buttons)
        {
            Title = TileLabel.AdviceLabel;
        }
    }
}