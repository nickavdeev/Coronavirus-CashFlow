using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.View;

namespace CoronavirusCashFlow.Controller.PlayingFiled
{
    public static class Buttons
    {
        public static readonly Button StartButton = GetGameButton("Начать игру!");
        
        public static readonly Button OkButton = GetGameButton("Следующий шаг");
        public static readonly Button ChangeViewButton = GetGameButton("Следующий шаг");
        public static readonly Button OkButtonNewsGoodReport = GetGameButton("Следующий шаг");
        public static readonly Button OkButtonNewsBadReport = GetGameButton("Следующий шаг");
        
        public static readonly Button OkButtonNewsGoodRandex = GetGameButton("Следующий шаг");
        public static readonly Button OkButtonNewsBadGazneft = GetGameButton("Следующий шаг");
        public static readonly Button OkButtonNewsGoodZuum = GetGameButton("Следующий шаг");
        public static readonly Button OkButtonNewsBadGilead = GetGameButton("Следующий шаг");
        
        public static readonly Button NextMoveButton = GetGameButton("Следующий шаг");
        
        public static readonly Button BuyDreamButton = GetGameButton("Купить!", 2);
        public static readonly Button GetDebtButton = GetGameButton("Взять кредит", 1);
        public static readonly Button AcceptDebtButton = GetGameButton("Подтвердить", 1);

        public static readonly List<Button> PassButtonList = new List<Button> {OkButton};
        public static readonly List<Button> PassButtonCreditList = new List<Button> {OkButton, GetDebtButton};
        public static readonly List<Button> NewsButtonGoodReportList = new List<Button> {OkButtonNewsGoodReport};
        
        public static readonly List<Button> NewsButtonBadReportList = new List<Button> {OkButtonNewsBadReport};
        
        public static readonly List<Button> OkButtonNewsGoodRandexList = new List<Button> {OkButtonNewsGoodRandex};
        public static readonly List<Button> OkButtonNewsBadGazneftList = new List<Button> {OkButtonNewsBadGazneft};
        public static readonly List<Button> OkButtonNewsGoodZuumList = new List<Button> {OkButtonNewsGoodZuum};
        public static readonly List<Button> OkButtonNewsBadGileadList = new List<Button> {OkButtonNewsBadGilead};

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
                    MouseDownBackColor = Colors.DarkGreen
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

            var dreamButtonsList = new List<Button>
            {
                NextMoveButton, BuyDreamButton, GetDebtButton
            };
            return dreamButtonsList;
        }
    }
}