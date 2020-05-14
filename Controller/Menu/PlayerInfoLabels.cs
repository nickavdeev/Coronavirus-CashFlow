using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Enums;

namespace CoronavirusCashFlow.Controller.Menu
{
    public static class PlayerInfo
    {
        public static readonly Label IncomeTitle = CreateTitle("Доходы");
        public static readonly Label IncomeInfo = CreateInfoLabel(PlayerInfoType.AssetsInfo);
        
        public static readonly Label ExpenseTitle = CreateTitle("Расходы");
        public static readonly Label ExpenseInfo = CreateInfoLabel(PlayerInfoType.ExpensesInfo);
        
        public static readonly Label AssetsTitle = CreateTitle("Активы");
        public static readonly Label AssetsInfo = CreateInfoLabel(PlayerInfoType.AssetsInfo);
        
        public static readonly Label LiabilitiesTitle = CreateTitle("Пассивы");
        public static readonly Label LiabilitiesInfo = CreateInfoLabel(PlayerInfoType.ExpensesInfo);
        
        public static readonly Label TimeTitle = CreateTitle("Свободное время");
        public static readonly Label TimeInfo = CreateInfoLabel(PlayerInfoType.AssetsInfo);

        private static Label CreateTitle(string mainLabel)
        {
            return new Label {
                Text = mainLabel,
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            };
        }

        private static Label CreateInfoLabel(PlayerInfoType infoType)
        {
            return new Label {
                Text = GameModel.Player.GetPlayerInfo(GameModel.Player, infoType),
                Location = new Point(120, 70),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            };
        }
    }
    public static class MainInfo
    {
        public static readonly Label MainTitle = new Label {
            Text = GameModel.Player.Name,
            Location = new Point(120, 23),
            Size = new Size(250, 50),
            AutoSize = false,
            Font = new Font("Arial", 26, FontStyle.Bold),
            BackColor = Color.Transparent,
            ForeColor = Color.Snow,
        };

        public static readonly Label MainInfoText = new Label {
            Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.MainInfo),
            Location = new Point(120, MainTitle.Bottom),
            Size = new Size(250, 450),
            AutoSize = false,
            Font = new Font("Arial", 14, FontStyle.Regular),
            BackColor = Color.Transparent,
            ForeColor = Color.Snow,
        }; 
    }
}