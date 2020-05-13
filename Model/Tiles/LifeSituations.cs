using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class LifeSituation : Tile
    {
        public LifeSituation(string description, List<Button> buttons, double cost) : base(description, buttons, cost)
        {
            Title = "Спонтанная трата";
            Cost = cost;
        }
    }
}