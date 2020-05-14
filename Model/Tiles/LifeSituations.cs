using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class LifeSituation : Tile
    {
        public LifeSituation(string description, List<Button> buttons, double expense = 0, double income = 0) : base(description, buttons, expense, income)
        {
            Title = TileLabel.LifeSituationLabel;
        }
    }
}