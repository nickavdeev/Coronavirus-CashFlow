using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Controller.Menu;
using CoronavirusCashFlow.Controller.PlayingFiled;
using CoronavirusCashFlow.Controller.StockExchange;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;
using Calendar = CoronavirusCashFlow.Constants.Calendar;

namespace CoronavirusCashFlow.View
{
    internal class GameForm : Form
    {
        private static readonly Size FormSize = new Size(1200, 700);
        private const int DayWidth = 87;

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillRectangle(new SolidBrush(Colors.DarkGreen), 0, 0, 100, FormSize.Height);
            graphics.FillRectangle(new SolidBrush(Colors.LightGreen), 100, 0, 300, FormSize.Height);
            graphics.FillRectangle(new SolidBrush(Colors.White), 400, 0, 800, FormSize.Height);

            for (var i = 0; i < 8; i++)
            {
                graphics.FillRectangle(new SolidBrush(Colors.Winter), 
                    400 + i * (DayWidth + 1), 0, DayWidth, DayWidth - 4);  
                graphics.DrawString((i + 1).ToString(), new Font("Arial", 14, FontStyle.Bold), 
                    new SolidBrush(Color.FromArgb(176,190,197)), 
                    new PointF(437 + i * (DayWidth + 1), 34));
            }
            for (var i = 0; i < 7; i++)
            {
                graphics.FillRectangle(new SolidBrush(Colors.Spring),
                    1104, 0 + i * (DayWidth - 3), DayWidth, DayWidth - 4);
                graphics.DrawString((9 + i).ToString(), new Font("Arial", 14, FontStyle.Bold), 
                    new SolidBrush(Color.FromArgb(176,190,197)), 
                    new PointF(1135, 34 + i * (DayWidth - 3)));
            }
            for (var i = 8; i > 0; i--)
            {
                graphics.FillRectangle(new SolidBrush(Colors.Summer), 
                    400 + i * (DayWidth + 1), 589, DayWidth, DayWidth - 4);
                graphics.DrawString((24 - i).ToString(), new Font("Arial", 14, FontStyle.Bold), 
                    new SolidBrush(Color.FromArgb(176,190,197)), 
                    new PointF(434 + i * (DayWidth + 1), 624));
            }
            for (var i = 7; i > 0; i--)
            {
                graphics.FillRectangle(new SolidBrush(Colors.Autumn),
                    400, 0 + i * (DayWidth + 1 - 4), DayWidth, DayWidth - 4);
                graphics.DrawString((31 - i).ToString(), new Font("Arial", 14, FontStyle.Bold), 
                    new SolidBrush(Color.FromArgb(176,190,197)), 
                    new PointF(434, 34 + i * (DayWidth - 3)));
            }
        }
        
        public GameForm()
        {
            // Главное меню
            Controls.Add(MenuButtons.MainInfoButton);
            Controls.Add(MenuButtons.IncomeButton);
            Controls.Add(MenuButtons.ExpensesButton);
            Controls.Add(MenuButtons.AssetsButton);
            Controls.Add(MenuButtons.LiabilitiesButton);
            Controls.Add(MenuButtons.TimeButton);
            
            // Стартовое игровое поле
            Controls.Add(MainInfo.MainTitle);
            Controls.Add(MainInfo.MainInfoText);
            Controls.Add(PlayingFieldLabels.MainText);
            Controls.Add(Buttons.StartButton);

            void UpdateMenuInfo(Button checkedButton = null)
            {
                MainInfo.MainInfoText.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.MainInfo);
                PlayerInfo.IncomeInfo.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.IncomeInfo);
                PlayerInfo.ExpenseInfo.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.ExpensesInfo);
                PlayerInfo.AssetsInfo.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.AssetsInfo);
                PlayerInfo.LiabilitiesInfo.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.LiabilitiesInfo);
                PlayerInfo.TimeInfo.Text = GameModel.Player.GetPlayerInfo(GameModel.Player, PlayerInfoType.TimeInfo);
                
                var menuButtons = new Dictionary<Button, (Label, Label)>
                {
                    {MenuButtons.MainInfoButton, (MainInfo.MainTitle, MainInfo.MainInfoText)},
                    {MenuButtons.IncomeButton, (PlayerInfo.IncomeTitle, PlayerInfo.IncomeInfo)},
                    {MenuButtons.ExpensesButton, (PlayerInfo.ExpenseTitle, PlayerInfo.ExpenseInfo)},
                    {MenuButtons.AssetsButton, (PlayerInfo.AssetsTitle, PlayerInfo.AssetsInfo)},
                    {MenuButtons.LiabilitiesButton, (PlayerInfo.LiabilitiesTitle, PlayerInfo.LiabilitiesInfo)},
                    {MenuButtons.TimeButton, (PlayerInfo.TimeTitle, PlayerInfo.TimeInfo)}
                };

                if (checkedButton == null) return;
                foreach (var button in menuButtons.Keys)
                {
                    if (button == checkedButton)
                    {
                        button.BackColor = Colors.LightGreen;
                        Controls.Add(menuButtons[button].Item1);
                        Controls.Add(menuButtons[button].Item2);
                    }
                    else
                    {
                        button.BackColor = Color.Transparent;
                        Controls.Remove(menuButtons[button].Item1);
                        Controls.Remove(menuButtons[button].Item2);
                    }
                }
            }
            
            void RemoveButtons()
            {
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Remove(button);
            }
 
            void ChangeView()
            {
                PlayingFieldLabels.MainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.CurrentPosition}: ";
                PlayingFieldLabels.CellText.Text = $"{GameModel.CurrentTile.Title}";
                PlayingFieldLabels.DescriptionCellText.Text = $"{GameModel.CurrentTile.Description}";
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Add(button);
                
                Metflix.StockCost.Text = Stock.GetStock("Metflix").Cost.ToString(CultureInfo.InvariantCulture);
                Zuum.StockCost.Text = Stock.GetStock("Zuum").Cost.ToString(CultureInfo.InvariantCulture);
                Gilead.StockCost.Text = Stock.GetStock("Gilead").Cost.ToString(CultureInfo.InvariantCulture);
                Randex.StockCost.Text = Stock.GetStock("Рандекс").Cost.ToString(CultureInfo.InvariantCulture);
                Gazneft.StockCost.Text = Stock.GetStock("Газнефть").Cost.ToString(CultureInfo.InvariantCulture);
                
                UpdateMenuInfo();
                Images.SetProfile((GameModel.Player.CurrentPosition - 1) % Calendar.Month);
            }

            Buttons.StartButton.Click += (sender, args) => {
                Controls.Remove(Buttons.StartButton);
                Controls.Add(PlayingFieldLabels.CellText);
                Controls.Add(PlayingFieldLabels.DescriptionCellText);
                Controls.Add(StockExchangeButtons.OpenStockExchange);

                GameModel.GetMove();
                Controls.Add(Images.Profile);
                Images.SetProfile((GameModel.Player.CurrentPosition - 1) % Calendar.Month);
                
                PlayingFieldLabels.MainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.CurrentPosition}: ";
                PlayingFieldLabels.CellText.Text = $"{GameModel.CurrentTile.Title}";
                PlayingFieldLabels.DescriptionCellText.Text = $"{GameModel.CurrentTile.Description}";
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Add(button);
                UpdateMenuInfo();
            };

            // Главное меню
            MenuButtons.MainInfoButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.MainInfoButton);
            MenuButtons.IncomeButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.IncomeButton);
            MenuButtons.ExpensesButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.ExpensesButton);
            MenuButtons.AssetsButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.AssetsButton);
            MenuButtons.LiabilitiesButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.LiabilitiesButton);
            MenuButtons.TimeButton.Click += (sender, args) => UpdateMenuInfo(MenuButtons.TimeButton);

            Buttons.ChangeViewButton.Click += (sender, args) => {
                Controls.Remove(Buttons.ChangeViewButton);
                ChangeView();
            };
            Buttons.OkButton.Click += (sender, args) => {
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.OkButtonNewsGoodReport.Click += (sender, args) => {
                var stock = GameModel.CurrentTile.StockList.Keys.ToArray()[0];
                PlayingFieldLabels.DescriptionCellText.Text = StockResult.GetGoodReport(stock);
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };
            Buttons.OkButtonNewsBadReport.Click += (sender, args) => {
                var stock = GameModel.CurrentTile.StockList.Keys.ToArray()[0];
                PlayingFieldLabels.DescriptionCellText.Text = StockResult.GetGoodReport(stock);
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };
            
            Buttons.OkButtonNewsBadGazneft.Click += (sender, args) => {
                PlayingFieldLabels.DescriptionCellText.Text = "«Газнефть» останавливает все свои проекты на время карантина. Акции падают";
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };
            Buttons.OkButtonNewsGoodRandex.Click += (sender, args) => {
                PlayingFieldLabels.DescriptionCellText.Text = "«Рандекс» отчитывается о рекордной прибыли. Акции растут";
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };
            Buttons.OkButtonNewsGoodZuum.Click += (sender, args) => {
                PlayingFieldLabels.DescriptionCellText.Text = "Zuum опередил иные сервисы видеоконференций и показал первую прибыль! Акции растут";
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };
            Buttons.OkButtonNewsBadGilead.Click += (sender, args) => {
                PlayingFieldLabels.DescriptionCellText.Text = "Федеральная администрация по здравоохранению США не одобрила вакцину Gilead! Акции падают";
                RemoveButtons();
                GameModel.GetMove();
                Controls.Add(Buttons.ChangeViewButton);
                UpdateMenuInfo();
            };

            Buttons.NextMoveButton.Click += (sender, args) => {
                Controls.Remove(Buttons.NextMoveButton);
                Controls.Remove(Buttons.AcceptDebtButton);
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.BuyDreamButton.Click += (sender, args) =>
            {
                if (GameModel.Player.Savings > GameModel.Player.Dream.Cost)
                    GameModel.Player.AddLiability(GameModel.Player.Dream);
                else PlayingFieldLabels.DescriptionCellText.Text = "Недостаточно средств :(";
                RemoveButtons();
                Controls.Add(Buttons.OkButton);
            };
            Buttons.GetDebtButton.Click += (sender, args) => {
                RemoveButtons();
                PlayingFieldLabels.CellText.Text = "Кредит у банка";
                if (GameModel.Player.CashFlow() < 20000) 
                    PlayingFieldLabels.DescriptionCellText.Text = DebtResult.CreditDenial;
                else
                {
                    PlayingFieldLabels.DescriptionCellText.Text = DebtResult.BankOffer(Debt.GetDebt("Кредит"));
                    Controls.Add(Buttons.AcceptDebtButton);
                }
                Controls.Add(Buttons.NextMoveButton);
            };
            Buttons.AcceptDebtButton.Click += (sender, args) => {
                RemoveButtons();
                var debt = Debt.GetDebt("Кредит");
                Controls.Remove(Buttons.NextMoveButton);
                Controls.Remove(Buttons.AcceptDebtButton);
                GameModel.Player.AddLiability(debt);
                GameModel.Player.Savings += debt.Cost;
                GameModel.Player.DebtMonths = (int)(debt.Cost / debt.Expense);
                GameModel.GetMove();
                ChangeView();
            };

            StockExchangeButtons.OpenStockExchange.Click += (sender, args) => {
                RemoveButtons();
                PlayingFieldLabels.CellText.Text = "Столичная биржа";
                
                Controls.Remove(StockExchangeButtons.OpenStockExchange);
                Controls.Add(StockExchangeButtons.CloseStockExchange);
                Controls.Remove(PlayingFieldLabels.DescriptionCellText);
                Controls.Remove(Buttons.OkButton);
                Controls.Remove(Buttons.ChangeViewButton);
                Controls.Remove(Buttons.OkButtonNewsGoodReport);
                Controls.Remove(Buttons.OkButtonNewsBadReport);
                Controls.Remove(Buttons.NextMoveButton);
                
                Controls.Add(StockExchangeLabels.CompanyName);
                Controls.Add(StockExchangeLabels.StockCostName);
                Controls.Add(StockExchangeLabels.StocksCount);
                Controls.Add(StockExchangeLabels.BuyLabel);
                Controls.Add(StockExchangeLabels.SellLabel);
                
                Controls.Add(Metflix.CompanyName);
                Controls.Add(Metflix.StockCost);
                Controls.Add(Metflix.StocksCount);
                Controls.Add(Metflix.BuyButton);
                Controls.Add(Metflix.SellButton);
                
                Controls.Add(Zuum.CompanyName);
                Controls.Add(Zuum.StockCost);
                Controls.Add(Zuum.StocksCount);
                Controls.Add(Zuum.BuyButton);
                Controls.Add(Zuum.SellButton);
                
                Controls.Add(Gilead.CompanyName);
                Controls.Add(Gilead.StockCost);
                Controls.Add(Gilead.StocksCount);
                Controls.Add(Gilead.BuyButton);
                Controls.Add(Gilead.SellButton);
                
                Controls.Add(Randex.CompanyName);
                Controls.Add(Randex.StockCost);
                Controls.Add(Randex.StocksCount);
                Controls.Add(Randex.BuyButton);
                Controls.Add(Randex.SellButton);
                
                Controls.Add(Gazneft.CompanyName);
                Controls.Add(Gazneft.StockCost);
                Controls.Add(Gazneft.StocksCount);
                Controls.Add(Gazneft.BuyButton);
                Controls.Add(Gazneft.SellButton);
            };
            StockExchangeButtons.CloseStockExchange.Click += (sender, args) => {
                Controls.Remove(StockExchangeButtons.CloseStockExchange);
                
                Controls.Remove(StockExchangeLabels.CompanyName);
                Controls.Remove(StockExchangeLabels.StockCostName);
                Controls.Remove(StockExchangeLabels.StocksCount);
                Controls.Remove(StockExchangeLabels.BuyLabel);
                Controls.Remove(StockExchangeLabels.SellLabel);
                
                Controls.Remove(Metflix.CompanyName);
                Controls.Remove(Metflix.StockCost);
                Controls.Remove(Metflix.StocksCount);
                Controls.Remove(Metflix.BuyButton);
                Controls.Remove(Metflix.SellButton);
                
                Controls.Remove(Zuum.CompanyName);
                Controls.Remove(Zuum.StockCost);
                Controls.Remove(Zuum.StocksCount);
                Controls.Remove(Zuum.BuyButton);
                Controls.Remove(Zuum.SellButton);
                
                Controls.Remove(Gilead.CompanyName);
                Controls.Remove(Gilead.StockCost);
                Controls.Remove(Gilead.StocksCount);
                Controls.Remove(Gilead.BuyButton);
                Controls.Remove(Gilead.SellButton);
                
                Controls.Remove(Randex.CompanyName);
                Controls.Remove(Randex.StockCost);
                Controls.Remove(Randex.StocksCount);
                Controls.Remove(Randex.BuyButton);
                Controls.Remove(Randex.SellButton);
                
                Controls.Remove(Gazneft.CompanyName);
                Controls.Remove(Gazneft.StockCost);
                Controls.Remove(Gazneft.StocksCount);
                Controls.Remove(Gazneft.BuyButton);
                Controls.Remove(Gazneft.SellButton);
                
                Controls.Add(PlayingFieldLabels.DescriptionCellText);
                Controls.Add(StockExchangeButtons.OpenStockExchange);
                PlayingFieldLabels.DescriptionCellText.Size = new Size(500, 150);
                ChangeView();
            };

            void Buy(string company)
            {
                var asset = Stock.GetStock(company);
                if (asset.Cost < GameModel.Player.Savings) GameModel.Player.AddAsset(asset);
                else Controls.Add(Metflix.Error);
                UpdateMenuInfo();
            }
            
            void Sell(string company)
            {
                var asset = Stock.GetStock(company);
                GameModel.Player.RemoveAsset(asset);
                UpdateMenuInfo();
            }
            
            Metflix.BuyButton.Click += (sender, args) => Buy(Metflix.BuyButton.Name);
            Zuum.BuyButton.Click += (sender, args) => Buy(Zuum.BuyButton.Name);
            Gilead.BuyButton.Click += (sender, args) => Buy(Gilead.BuyButton.Name);
            Randex.BuyButton.Click += (sender, args) => Buy(Randex.BuyButton.Name);
            Gazneft.BuyButton.Click += (sender, args) => Buy(Gazneft.BuyButton.Name);

            Metflix.SellButton.Click += (sender, args) => Sell(Metflix.SellButton.Name);
            Zuum.SellButton.Click += (sender, args) => Sell(Zuum.SellButton.Name);
            Gilead.SellButton.Click += (sender, args) => Sell(Gilead.SellButton.Name);
            Randex.SellButton.Click += (sender, args) => Sell(Randex.SellButton.Name);
            Gazneft.SellButton.Click += (sender, args) => Sell(Gazneft.SellButton.Name);
        }
        
        public static void WinView()
        {
            PlayingFieldLabels.CellText.Text = "Победа!";
            PlayingFieldLabels.DescriptionCellText.Text = $"Поздравляем! Вы достигли мечты: {GameModel.Player.Name} купил {GameModel.Player.Dream.Title}! 🎉";
        }

        public static void Main()
        {
            var form = new GameForm
            {
                Size = new Size(1200, 700),
                Text = "Coronavirus CashFlow",
                FormBorderStyle = FormBorderStyle.FixedDialog
            };
            Application.Run(form);
        }
    }
}