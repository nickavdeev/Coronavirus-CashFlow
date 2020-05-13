using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Model.Assets;

namespace CoronavirusCashFlow.Model.Tiles
{
    public abstract class Tile
    {
        public string Title;
        public readonly string Description;
        public readonly List<Button> Buttons;
        public double Cost;
        public readonly double Income;
        public readonly Dictionary<Stock, double> StockList;

        protected Tile(string description, List<Button> buttons)
        {
            Description = description;
            Buttons = buttons;
        }
        
        protected Tile(string description, List<Button> buttons, double cost = 0, double income = 0)
        {
            Description = description;
            Buttons = buttons;
            Cost = cost;
            Income = income;
        }
        protected Tile(string description, List<Button> buttons, Dictionary<Stock, double> stockList)
        {
            Description = description;
            Buttons = buttons;
            StockList = stockList;
        }
    }
}