using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.StockExchange
{
    public static class StockExchangeButtons
    {
        public static readonly Button OpenStockExchange = new Button {
            Location = new Point(755, 520),
            Size = new Size(100, 40),
            Text = "Биржа",
            Font = new Font("Arial", 14, FontStyle.Bold),
            BackColor = Colors.DarkGreen,
            ForeColor = Color.Snow,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { MouseOverBackColor = Color.Black, BorderSize = 0, MouseDownBackColor = Colors.DarkGreen}
        };
        public static readonly Button CloseStockExchange = new Button {
            Location = new Point(700, 490),
            Size = new Size(200, 40),
            Text = "Закрыть Биржу",
            Font = new Font("Arial", 14, FontStyle.Bold),
            BackColor = Colors.DarkGreen,
            ForeColor = Color.Snow,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { MouseOverBackColor = Color.Black, BorderSize = 0, MouseDownBackColor = Colors.DarkGreen}
        };
    }
}