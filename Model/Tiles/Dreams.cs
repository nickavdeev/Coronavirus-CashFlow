using System.Collections.Generic;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class Dream : Tile
    {
        public Dream(string description, List<Button> buttons) : base(description, buttons)
        {
            Title = TileLabel.DreamLabel;
            Description = description 
                          + $"\n \nМечта: {GameModel.Player.Dream.Title}.\n \nЦена: {GameModel.Player.Dream.Cost}";
        }
    }
}