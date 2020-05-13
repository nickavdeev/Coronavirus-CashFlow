using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class Advice : Tile
    {
        public Advice(string description, List<Button> buttons) : base(description, buttons)
        {
            Title = "Совет";
        }
    }
}