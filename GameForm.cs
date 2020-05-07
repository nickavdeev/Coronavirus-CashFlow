using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CoronavirusCashFlow
{
    internal class GameForm : Form
    {
        // Отрисовка элементов игры
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(0,61,0)), 0, 0, 100, 700);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(51,105,30)), 100, 0, 300, 700);
            graphics.FillRectangle(new SolidBrush(Color.FromArgb(250,250,250)), 400, 0, 800, 700);
        }
        
        // Кнопки-реакции
        public static readonly Button PassButton = new Button
        {
            Location = new Point(700, 400),
            Size = new Size(200, 40),
            Text = "ОК",
            Font = new Font("Arial", 14, FontStyle.Bold),
            BackColor = Color.Black,
            ForeColor = Color.Snow,
            Cursor = Cursors.Hand,
            FlatStyle = FlatStyle.Flat,
            FlatAppearance = { MouseOverBackColor = Color.Black, BorderSize = 0, MouseDownBackColor = Color.FromArgb(0,61,0)}
        };

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
            var mainInfoButton = new Button
            {
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
            var assetsButton = GetMenuButton("Активы", mainInfoButton);
            var liabilitiesButton = GetMenuButton("Пассивы", assetsButton);
            
            // Информационные тексты
            // Главная
            var mainInfoText = new Label
            {
                Text = GameModel.PlayerInfo(GameModel.Player),
                Location = new Point(120, 25),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Активы
            var assetsText = new Label
            {
                Text = "Текст про активы",
                Location = new Point(120, 25),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 
            // Пассивы
            var liabilitiesText = new Label
            {
                Text = "Текст про пассивы",
                Location = new Point(120, 25),
                Size = new Size(250, 450),
                AutoSize = false,
                Font = new Font("Arial", 14, FontStyle.Regular),
                BackColor = Color.Transparent,
                ForeColor = Color.Snow,
            }; 

            // Тексты игрового поля
            var mainText = new Label
            {
                Text = "Для начала игры нажмите кнопку",
                Font = new Font("Arial", 14, FontStyle.Regular),
                Location = new Point(550, 100),
                Size = new Size(500, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Black,
                ForeColor = Color.Snow,
            };
            var cellText = new Label
            {
                Font = new Font("Arial", 16, FontStyle.Regular),
                Location = new Point(550, 150),
                Size = new Size(500, 40),
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = green,
                ForeColor = Color.Snow,
            };
            var descriptionCellText = new Label
            {
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
            
            var startButton = new Button
            {
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
            
            Controls.Add(mainInfoButton);
            Controls.Add(assetsButton);
            Controls.Add(liabilitiesButton);
            
            Controls.Add(mainInfoText);
            
            Controls.Add(mainText);
            Controls.Add(startButton);

            mainInfoButton.Click += (sender, args) =>
            {
                mainInfoButton.BackColor = green;
                assetsButton.BackColor = Color.Transparent;
                liabilitiesButton.BackColor = Color.Transparent;
                
                Controls.Remove(assetsText);
                Controls.Remove(liabilitiesText);
                Controls.Add(mainInfoText);
            };
            assetsButton.Click += (sender, args) =>
            {
                mainInfoButton.BackColor = Color.Transparent;
                assetsButton.BackColor = green;
                liabilitiesButton.BackColor = Color.Transparent;
                
                Controls.Remove(mainInfoText);
                Controls.Remove(liabilitiesText);
                Controls.Add(assetsText);
            };
            liabilitiesButton.Click += (sender, args) =>
            {
                mainInfoButton.BackColor = Color.Transparent;
                assetsButton.BackColor = Color.Transparent;
                liabilitiesButton.BackColor = green;
                
                Controls.Remove(mainInfoText);
                Controls.Remove(assetsText);
                Controls.Add(liabilitiesText);
            };

            startButton.Click += (sender, args) =>
            {
                Controls.Remove(startButton);
                Controls.Add(cellText);
                Controls.Add(descriptionCellText);
                
                GameModel.GetMove();
                mainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.Cell}: ";
                cellText.Text = $"{GameModel.CurrentField.Title}";
                descriptionCellText.Text = $"{GameModel.CurrentField.Description}";
                foreach (var button in GameModel.CurrentField.Buttons) Controls.Add(button);
            };
            PassButton.Click += (sender, args) =>
            {
                foreach (var button in GameModel.CurrentField.Buttons) Controls.Remove(button);
                GameModel.GetMove();
                mainText.Text = $"Выпало {GameModel.Cube}, вы на клетке {GameModel.Player.Cell}: ";
                cellText.Text = $"{GameModel.CurrentField.Title}";
                descriptionCellText.Text = $"{GameModel.CurrentField.Description}";
                foreach (var button in GameModel.CurrentField.Buttons) Controls.Add(button);
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