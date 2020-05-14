using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.Menu
{
    public abstract class MenuButtons
    {
        public static readonly Button MainInfoButton = GetMenuButton("Главное");
        public static readonly Button IncomeButton = GetMenuButton("Доходы", MainInfoButton);
        public static readonly Button ExpensesButton = GetMenuButton("Расходы", IncomeButton);
        public static readonly Button AssetsButton = GetMenuButton("Активы", ExpensesButton);
        public static readonly Button LiabilitiesButton = GetMenuButton("Пассивы", AssetsButton);
        public static readonly Button TimeButton = GetMenuButton("Время", LiabilitiesButton);

        private static Button GetMenuButton(string buttonText, Control previousButton = null)
        {
            var y = 0;
            var backColor = Colors.LightGreen;
            if (previousButton == null)
                return new Button
                {
                    Text = buttonText,
                    Location = new Point(0, y),
                    Size = new Size(100, 100),
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    BackColor = backColor,
                    ForeColor = Color.Snow,
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance =
                    {
                        BorderColor = Colors.DarkGreen,
                        MouseOverBackColor = Colors.MediumGreen,
                        BorderSize = 0,
                        MouseDownBackColor = Colors.DarkGreen
                    }
                };
            y = previousButton.Bottom;
            backColor = Color.Transparent;

            return new Button
            {
                Text = buttonText,
                Location = new Point(0, y),
                Size = new Size(100, 100),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = backColor,
                ForeColor = Color.Snow,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    BorderColor = Colors.DarkGreen,
                    MouseOverBackColor = Colors.MediumGreen,
                    BorderSize = 0,
                    MouseDownBackColor = Colors.DarkGreen
                }
            };
        }
    }
}