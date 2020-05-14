using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.StockExchange
{
    public static class StockExchangeLabels
    {
        public static readonly Label CompanyName = new Label {
            Text = "Компания",
            Location = new Point(550, 190), 
            Size = new Size(110, 40), 
            AutoSize = false, 
            Padding = new Padding(20, 5 ,0 ,0), 
            Font = new Font("Arial", 12, FontStyle.Bold), 
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Snow,
        };

        public static readonly Label StockCostName = new Label {
            Text = "Цена", 
            Location = new Point(CompanyName.Right, 190), 
            Size = new Size(70, 40), 
            AutoSize = false, 
            Padding = new Padding(10, 5 ,0 ,0), 
            Font = new Font("Arial", 12, FontStyle.Bold), 
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Snow,
        };

        public static readonly Label StocksCount = new Label {
            Text = "Количество",
            Location = new Point(StockCostName.Right, 190),
            Size = new Size(120, 40),
            AutoSize = false,
            Padding = new Padding(10, 5 ,0 ,0),
            Font = new Font("Arial", 12, FontStyle.Bold),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Snow,
        };

        public static readonly Label BuyLabel = new Label {
            Text = "Купить",
            Location = new Point(StocksCount.Right, 190),
            Size = new Size(100, 40),
            AutoSize = false,
            Padding = new Padding(15, 5 ,0 ,0),
            Font = new Font("Arial", 12, FontStyle.Bold),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Snow,
        };

        public static readonly Label SellLabel = new Label {
            Text = "Продать",
            Location = new Point(BuyLabel.Right, 190),
            Size = new Size(100, 40),
            AutoSize = false,
            Padding = new Padding(10, 5 ,0 ,0),
            Font = new Font("Arial", 12, FontStyle.Bold),
            BackColor = Colors.LightGreen, 
            ForeColor = Color.Snow,
        };
    }
}