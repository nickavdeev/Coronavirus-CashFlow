using System.Collections.Generic;
using System.Windows.Forms;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class Dream : Tile
    {
        public Dream(string description, List<Button> buttons) : base(description, buttons)
        {
            Title = "Исполните мечту!";
        }
    }
}