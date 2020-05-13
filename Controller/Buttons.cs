using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.View;
using CoronavirusCashFlow.Model.Enums;

namespace CoronavirusCashFlow.Controller
{
    public static class Buttons
    {
        private static Button GetGameButton(string text, int numberInList = 0)
        {
            var button = new Button
            {
                Text = text,
                Location = new Point(700, 350),
                Size = new Size(200, 40),
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.Black,
                ForeColor = Color.Snow,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    MouseOverBackColor = Color.Black, 
                    BorderSize = 0, 
                    MouseDownBackColor = Colors.GetColor(ColorType.DarkGreen)
                }
            };
            switch (numberInList)
            {
                case 1:
                    button.Location = new Point(700, 400);
                    break;
                case 2:
                    button.Location = new Point(700, 450);
                    break;
            }

            return button;
        }

        public static List<Button> GetDreamButtons()
        {
            var dreamCost = GameModel.Player.Dream.Cost;
            var playerSavings = GameModel.Player.Savings;

            var dreamButtonsList = new List<Button> {NextMoveButton};
            if (playerSavings >= dreamCost) dreamButtonsList.Add(BuyDreamButton);
            else dreamButtonsList.Add(GetDebtButton);

            return dreamButtonsList;
        }
        
        public static readonly Button OkButton = GetGameButton("OK");
        public static readonly Button OkButtonWithConsequences = GetGameButton("OK");
        public static readonly Button OkButtonWithStockConsequences = GetGameButton("OK");
        public static readonly Button OkButtonNewsGoodReport = GetGameButton("OK");
        public static readonly Button OkButtonNewsBadReport = GetGameButton("OK");
        
        public static readonly Button NextMoveButton = GetGameButton("Следующий шаг");
        public static readonly Button BuyDreamButton = GetGameButton("Купить!", 1);
        public static readonly Button GetDebtButton = GetGameButton("Взять кредит", 1);
        
        public static readonly Button AcceptDebtButton = GetGameButton("Подтвердить", 1);

        public static readonly List<Button> PassButtonList = new List<Button> {OkButton};
        public static readonly List<Button> LifeSituationButtonList = new List<Button> {OkButtonWithConsequences};
        public static readonly List<Button> StockSituationButtonList = new List<Button> {OkButtonWithStockConsequences};
        public static readonly List<Button> NewsButtonGoodReportList = new List<Button> {OkButtonNewsGoodReport};
        public static readonly List<Button> NewsButtonBadReportList = new List<Button> {OkButtonNewsBadReport};
    }
}