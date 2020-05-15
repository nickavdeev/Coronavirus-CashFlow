using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.StockExchange
{
    public static class Gazneft
    {
        private const int Y = 350;
        private const int Height = 30;
        private const FontStyle FontStyle = System.Drawing.FontStyle.Regular;
        private static readonly Stock Stock = (Stock)Stock.GetStock("Газнефть");

        public static readonly Label CompanyName = new Label {
            Text = Stock.Title,
            Location = new Point(550, Y), 
            Size = new Size(110, Height), 
            AutoSize = false, 
            Padding = new Padding(20, 5 ,0 ,0), 
            Font = new Font("Arial", 12, FontStyle), 
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Gainsboro,
        };

        public static readonly Label StockCost = new Label {
            Text = Stock.Cost.ToString(CultureInfo.InvariantCulture), 
            Location = new Point(CompanyName.Right, Y), 
            Size = new Size(110, Height), 
            AutoSize = false, 
            Padding = new Padding(12, 5 ,0 ,0), 
            Font = new Font("Arial", 12, FontStyle), 
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Gainsboro,
        };

        public static readonly Label StocksCount = new Label {
            Text = "1",
            Location = new Point(StockCost.Right, Y),
            Size = new Size(75, Height),
            AutoSize = false,
            Padding = new Padding(10, 5 ,0 ,0),
            Font = new Font("Arial", 12, FontStyle),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Gainsboro,
        };

        public static readonly Button BuyButton = new Button {
            Text = "Купить",
            Name = Stock.Title,
            Location = new Point(StocksCount.Right, Y),
            Size = new Size(90, Height),
            AutoSize = false,
            Font = new Font("Arial", 12, FontStyle),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Gainsboro,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance =
            {
                BorderSize = 0, 
                MouseDownBackColor = Colors.DarkGreen
            }
        };

        public static readonly Button SellButton = new Button {
            Name = Stock.Title,
            Text = "Продать",
            Location = new Point(BuyButton.Right, Y),
            Size = new Size(115, Height),
            AutoSize = false,
            Font = new Font("Arial", 12, FontStyle),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Gainsboro,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance =
            {
                BorderSize = 0, 
                MouseDownBackColor = Colors.DarkGreen
            }
        };
        public static readonly Label Error = new Label {
            Text = "Недостаточно средств",
            Location = new Point(700, 450), 
            Size = new Size(200, Height), 
            AutoSize = false,
            Padding = new Padding(30, 5 ,0 ,0), 
            Font = new Font("Arial", 10, FontStyle), 
            BackColor = Color.Brown, 
            ForeColor = Color.Gainsboro,
        };
    }
}