using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using CoronavirusCashFlow.Controller;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.View
{
    internal class GameForm : Form
    {
        private Size _formSize = new Size(1200, 700);
        
        // Отрисовка элементов игры
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(0,61,0)), 0, 0, 100, _formSize.Height);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(51,105,30)), 100, 0, 300, _formSize.Height);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(250,250,250)), 400, 0, 800, _formSize.Height);
        }

        private GameForm()
        {
            // Основные цвета игры
            var darkGreen = Color.FromArgb(0, 61, 0);
            var mediumGreen = Color.FromArgb(25, 80, 15);
            var green = Color.FromArgb(51, 105, 30);

            // Главное меню
            Button GetMenuButton(string buttonText, Control previousButton)
            {
                return new Button
                {
                    Location = new Point(0, previousButton.Bottom),
                    Size = new Size(100, 100),
                    Text = buttonText,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    BackColor = Color.Transparent,
                    ForeColor = Color.Snow,
                    Cursor = Cursors.Hand,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderColor = darkGreen, MouseOverBackColor = mediumGreen, BorderSize = 0, MouseDownBackColor = darkGreen}
                };
            }
            var mainInfoButton = new Button {
                Location = new Point(0, 0),
                Size = new Size(100, 100),
                Text = "Главное",
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = green,
                ForeColor = Color.Snow,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderColor = green, MouseOverBackColor = mediumGreen, BorderSize = 0, MouseDownBackColor = darkGreen}
            };
            var incomeButton = GetMenuButton("Доходы", mainInfoButton);
            var expensesButton = GetMenuButton("Расходы", incomeButton);
            var assetsButton = GetMenuButton("Активы", expensesButton);
            var liabilitiesButton = GetMenuButton("Пассивы", assetsButton);
            var timeButton = GetMenuButton("Время", liabilitiesButton);
            
            // Информационные тексты
            // Главная
            var mainInfoTextLabel = new Label {
                Text = GameModel.Player.Name,
                Location = new Point(118, 23),
                Size = new Size(250, 50),
                AutoSize = false,
                Font = new Font("Arial", 26, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var mainInfoText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.MainInfo),
                Location = new Point(120, mainInfoTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Доходы
            var incomeTextLabel = new Label {
                Text = "Доходы",
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var incomeText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.AssetsInfo),
                Location = new Point(120, incomeTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Расходы
            var expensesTextLabel = new Label {
                Text = "Расходы",
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var expensesText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.AssetsInfo),
                Location = new Point(120, expensesTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Активы
            var assetsTextLabel = new Label {
                Text = "Активы",
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var assetsText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.AssetsInfo),
                Location = new Point(120, assetsTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Пассивы
            var liabilitiesTextLabel = new Label {
                Text = "Пассивы",
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var liabilitiesText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.LiabilitiesInfo),
                Location = new Point(120, liabilitiesTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Время
            var timeTextLabel = new Label {
                Text = "Время",
                Location = new Point(120, 25),
                Size = new Size(250, 45),
                AutoSize = false,
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            var timeText = new Label {
                Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.LiabilitiesInfo),
                Location = new Point(120, timeTextLabel.Bottom),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 12, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 

            // Тексты игрового поля
            var mainText = new Label {
                Text = "Для начала игры нажмите кнопку",
                Font = new Font("Arial", 14, FontStyle.Regular),
                Location = new Point(550, 100),
                Size = new Size(500, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Black,
                ForeColor = Color.Snow,
            };
            var cellText = new Label {
                Font = new Font("Arial", 16, FontStyle.Regular),
                Location = new Point(550, 150),
                Size = new Size(500, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = green,
                ForeColor = Color.Snow,
            };
            var descriptionCellText = new Label {
                Font = new Font("Arial", 12, FontStyle.Regular),
                Location = new Point(550, cellText.Bottom),
                Size = new Size(500, 150),
                AutoSize = false,
                MaximumSize = new Size(500, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = green,
                ForeColor = Color.Snow,
                Padding = new Padding(20, 20, 40, 20),
            };
            var startButton = new Button {
                Location = new Point(700, 400),
                Size = new Size(200, 40),
                Text = "Начать игру!",
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = Color.Black,
                ForeColor = Color.Snow,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { MouseOverBackColor = Color.Black, BorderSize = 0, MouseDownBackColor = darkGreen}
            };
            var stockExchangeButton = new Button {
                Location = new Point(755, 490),
                Size = new Size(100, 40),
                Text = "Биржа",
                Font = new Font("Arial", 14, FontStyle.Bold),
                BackColor = darkGreen,
                ForeColor = Color.Snow,
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { MouseOverBackColor = Color.Black, BorderSize = 0, MouseDownBackColor = darkGreen}
            };
            
            Controls.Add(mainInfoButton);
            Controls.Add(incomeButton);
            Controls.Add(expensesButton);
            Controls.Add(assetsButton);
            Controls.Add(liabilitiesButton);
            Controls.Add(timeButton);
            
            Controls.Add(mainInfoTextLabel);
            Controls.Add(mainInfoText);
            
            Controls.Add(mainText);
            Controls.Add(startButton);
            Controls.Add(stockExchangeButton);

            void UpdateMenuInfo(Button checkedButton = null)
            {
                mainInfoText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.MainInfo);
                incomeText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.IncomeInfo);
                expensesText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.ExpensesInfo);
                assetsText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.AssetsInfo);
                liabilitiesText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.LiabilitiesInfo);
                timeText.Text = GameModel.GetPlayerInfo(GameModel.Player, PlayerInfoType.TimeInfo);
                
                var menuButtons = new Dictionary<Button, (Label, Label)>
                {
                    {mainInfoButton, (mainInfoTextLabel, mainInfoText)},
                    {incomeButton, (incomeTextLabel, incomeText)},
                    {expensesButton, (expensesTextLabel, expensesText)},
                    {assetsButton, (assetsTextLabel, assetsText)},
                    {liabilitiesButton, (liabilitiesTextLabel, liabilitiesText)},
                    {timeButton, (timeTextLabel, timeText)}
                };

                if (checkedButton == null) return;
                foreach (var button in menuButtons.Keys)
                {
                    if (button == checkedButton)
                    {
                        button.BackColor = green;
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

            mainInfoButton.Click += (sender, args) => UpdateMenuInfo(mainInfoButton);
            incomeButton.Click += (sender, args) => UpdateMenuInfo(incomeButton);
            expensesButton.Click += (sender, args) => UpdateMenuInfo(expensesButton);
            assetsButton.Click += (sender, args) => UpdateMenuInfo(assetsButton);
            liabilitiesButton.Click += (sender, args) => UpdateMenuInfo(liabilitiesButton);
            timeButton.Click += (sender, args) => UpdateMenuInfo(timeButton);

            startButton.Click += (sender, args) =>
            {
                Controls.Remove(startButton);
                Controls.Add(cellText);
                Controls.Add(descriptionCellText);
                
                GameModel.GetMove();
                mainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.CurrentPosition}: ";
                cellText.Text = $"{GameModel.CurrentTile.Title}";
                descriptionCellText.Text = $"{GameModel.CurrentTile.Description}";
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Add(button);
                UpdateMenuInfo();
            };
            
            void RemoveButtons()
            {
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Remove(button);
            }
 
            void ChangeView()
            {
                mainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.CurrentPosition}: ";
                cellText.Text = $"{GameModel.CurrentTile.Title}";
                descriptionCellText.Text = $"{GameModel.CurrentTile.Description}";
                foreach (var button in GameModel.CurrentTile.Buttons) Controls.Add(button);
                UpdateMenuInfo();
            }
            
            Buttons.OkButton.Click += (sender, args) =>
            {
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.OkButtonWithConsequences.Click += (sender, args) =>
            {
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.OkButtonWithStockConsequences.Click += (sender, args) =>
            {
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            
            Buttons.OkButtonNewsGoodReport.Click += (sender, args) =>
            {
                var stock = GameModel.CurrentTile.StockList.Keys.ToArray()[0];
                RemoveButtons();
                descriptionCellText.Text = 
                    $"Отчёт хорош! {stock.Title} прибавляют в цене!";
                Controls.Add(Buttons.OkButton);
                UpdateMenuInfo();
            };
            Buttons.OkButtonNewsBadReport.Click += (sender, args) =>
            {
                var stock = GameModel.CurrentTile.StockList.Keys.ToArray()[0];
                RemoveButtons();
                descriptionCellText.Text = 
                    $"Отчёт внезапный отстой! {stock.Title} Падают!!";
                Controls.Add(Buttons.OkButton);
                UpdateMenuInfo();
            };
            
            Buttons.NextMoveButton.Click += (sender, args) =>
            {
                Controls.Remove(Buttons.NextMoveButton);
                Controls.Remove(Buttons.AcceptDebtButton);
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.BuyDreamButton.Click += (sender, args) =>
            {
                GameModel.Player.AddLiability(GameModel.Player.Dream, GameModel.Player.Dream.Cost);
                RemoveButtons();
                GameModel.GetMove();
                ChangeView();
            };
            Buttons.GetDebtButton.Click += (sender, args) =>
            {
                RemoveButtons();
                cellText.Text = "Кредит у банка";
                if (GameModel.Player.CashFlow() < 10000) descriptionCellText.Text = "Невозможно взять кредит.";
                else
                {
                    var debt = Debt.GetDebt("Кредит");
                    descriptionCellText.Text = $"Банк предлагает кредит на {debt.Cost} с ежемесячным платежём " +
                                               $"{debt.Expense} на { (int)(debt.Cost / debt.Expense) } месяцев.";
                    Controls.Add(Buttons.AcceptDebtButton);
                }
                Controls.Add(Buttons.NextMoveButton);
            };
            Buttons.AcceptDebtButton.Click += (sender, args) =>
            {
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
            stockExchangeButton.Click += (sender, args) =>
            {
                
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