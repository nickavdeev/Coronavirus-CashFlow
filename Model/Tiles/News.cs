using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Model.Assets;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class News : Tile
    {
        public News(string description, List<Button> buttons, Dictionary<Stock, double> stockList) 
            : base(description, buttons, stockList)
        {
            Title = "Новости";
        }

    }
}