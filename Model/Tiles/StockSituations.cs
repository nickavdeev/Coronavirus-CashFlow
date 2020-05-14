using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Model.Assets;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class StockSituation : Tile
    {
        public StockSituation(string description, List<Button> buttons, Dictionary<Stock, double> stockList) 
            : base(description, buttons, stockList)
        {
            Title = TileLabel.StockSituationLabel;
        }
    }
}