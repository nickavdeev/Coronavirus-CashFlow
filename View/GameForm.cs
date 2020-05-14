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

namespace CoronavirusCashFlow.View
{
    internal class GameForm : Form
    {
        private static readonly Size FormSize = new Size(1200, 700);
        
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillRectangle(new SolidBrush(Colors.DarkGreen), 0, 0, 100, FormSize.Height);
            graphics.FillRectangle(new SolidBrush(Colors.LightGreen), 100, 0, 300, FormSize.Height);
            graphics.FillRectangle(new SolidBrush(Colors.White), 400, 0, 800, FormSize.Height);
        }
        
        private GameForm()
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
                
                Metflix.StockCost.Text = (Stock.GetStock("Metflix").Cost).ToString(CultureInfo.InvariantCulture);
                Zoom.StockCost.Text = (Stock.GetStock("Zoom").Cost).ToString(CultureInfo.InvariantCulture);
                
                UpdateMenuInfo();
            }
            
            Buttons.StartButton.Click += (sender, args) => {
                Controls.Remove(Buttons.StartButton);
                Controls.Add(PlayingFieldLabels.CellText);
                Controls.Add(PlayingFieldLabels.DescriptionCellText);
                Controls.Add(StockExchangeButtons.OpenStockExchange);
                
                GameModel.GetMove();
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

            Buttons.ChangeViewButton.Click += (sender, args) => ChangeView();
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
            Buttons.BuyDreamButton.Click += (sender, args) => {
                GameModel.Player.AddLiability(GameModel.Player.Dream);
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
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
                
                Controls.Add(StockExchangeLabels.CompanyName);
                Controls.Add(StockExchangeLabels.StockCostName);
                Controls.Add(StockExchangeLabels.StocksCount);
                Controls.Add(StockExchangeLabels.BuyLabel);
                Controls.Add(StockExchangeLabels.SellLabel);
                
                Controls.Add(Metflix.Label);
                Controls.Add(Metflix.StockCost);
                Controls.Add(Metflix.StocksCount);
                Controls.Add(Metflix.BuyButton);
                Controls.Add(Metflix.SellButton);
                
                Controls.Add(Zoom.Label);
                Controls.Add(Zoom.StockCost);
                Controls.Add(Zoom.StocksCount);
                Controls.Add(Zoom.BuyButton);
                Controls.Add(Zoom.SellButton);
            };
            StockExchangeButtons.CloseStockExchange.Click += (sender, args) => {
                Controls.Remove(StockExchangeButtons.CloseStockExchange);
                
                Controls.Remove(StockExchangeLabels.CompanyName);
                Controls.Remove(StockExchangeLabels.StockCostName);
                Controls.Remove(StockExchangeLabels.StocksCount);
                Controls.Remove(StockExchangeLabels.BuyLabel);
                Controls.Remove(StockExchangeLabels.SellLabel);
                
                Controls.Remove(Metflix.Label);
                Controls.Remove(Metflix.StockCost);
                Controls.Remove(Metflix.StocksCount);
                Controls.Remove(Metflix.BuyButton);
                Controls.Remove(Metflix.SellButton);
                Controls.Remove(Metflix.Error);
                
                Controls.Remove(Zoom.Label);
                Controls.Remove(Zoom.StockCost);
                Controls.Remove(Zoom.StocksCount);
                Controls.Remove(Zoom.BuyButton);
                Controls.Remove(Zoom.SellButton);
                
                Controls.Add(PlayingFieldLabels.DescriptionCellText);
                Controls.Add(StockExchangeButtons.OpenStockExchange);
                PlayingFieldLabels.DescriptionCellText.Size = new Size(500, 150);
                ChangeView();
            };
            Metflix.BuyButton.Click += (sender, args) => {
                var asset = Stock.GetStock("Metflix");
                if (asset.Cost < GameModel.Player.Savings) GameModel.Player.AddAsset(asset);
                else Controls.Add(Metflix.Error);

                UpdateMenuInfo();
            };
            Metflix.SellButton.Click += (sender, args) => {
                var asset = Stock.GetStock("Metflix");
                GameModel.Player.RemoveAsset(asset);
                UpdateMenuInfo();
            };
            Zoom.BuyButton.Click += (sender, args) => {
                var asset = Stock.GetStock("Zoom");
                if (asset.Cost < GameModel.Player.Savings) GameModel.Player.AddAsset(asset);
                else Controls.Add(Metflix.Error);

                UpdateMenuInfo();
            };
            Zoom.SellButton.Click += (sender, args) => {
                var asset = Stock.GetStock("Zoom");
                GameModel.Player.RemoveAsset(asset);
                UpdateMenuInfo();
            };
        }

        public static void Main()
        {
            var form = new GameForm
            {
                Size = new Size(1200, 700),
                Text = "Coronavirus CashFlow"
            };
            Application.Run(form);
        }
    }
}