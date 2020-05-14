using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.PlayingFiled
{
    public static class PlayingFieldLabels
    {
        public static readonly Label MainText = new Label {
            Text = "Для начала игры нажмите кнопку",
            Font = new Font("Arial", 14, FontStyle.Regular),
            Location = new Point(550, 100),
            Size = new Size(500, 40),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Color.Black,
            ForeColor = Color.Snow,
        };
        public static readonly Label CellText = new Label {
            Font = new Font("Arial", 16, FontStyle.Regular),
            Location = new Point(550, 150),
            Size = new Size(500, 40),
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Colors.LightGreen,
            ForeColor = Color.Snow,
        };
        public static readonly Label DescriptionCellText = new Label {
            Font = new Font("Arial", 12, FontStyle.Regular),
            Location = new Point(550, CellText.Bottom),
            Size = new Size(500, 150),
            AutoSize = false,
            MaximumSize = new Size(500, 0),
            TextAlign = ContentAlignment.MiddleCenter,
            BackColor = Colors.LightGreen,
            ForeColor = Color.Snow,
            Padding = new Padding(20, 20, 40, 20),
        };
    }
}