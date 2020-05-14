using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;
using CoronavirusCashFlow.Model.Players;
using CoronavirusCashFlow.Model.Tiles;

namespace CoronavirusCashFlow.Model
{
    public static class GameModel
    {
        public static readonly Player Player = new Player(PlayerName.Mike);
        private static readonly Map CurrentMap = new Map();
        public static Tile CurrentTile = CurrentMap.PlayingMap[Player.CurrentPosition];
        public static int Cube;
        
        private static void GetTileAction()
        {
            if (Player.DebtMonths == 1) Player.RemoveLiability(Debt.GetDebt("Кредит"));
            Player.Savings -= CurrentTile.Expense; 
            Player.Savings += CurrentTile.Income;
            if (CurrentTile.StockList == null) return;
            foreach (var stock in CurrentTile.StockList.Keys) stock.Cost += CurrentTile.StockList[stock];
        }
        
        private static void IsWin()
        {
            var goals = new List<bool>
            {
                Player.LiabilitiesList.Contains(Player.Dream), 
                Player.CashFlow() > Player.Expenses()
            };
            if (!goals.Contains(false))
                Console.WriteLine($"Поздравляем! Вы достигли мечты: {Player.Name} купил {Player.Dream.Title}! 🎉");
        }

        private static void ChangeStocksCost()
        {
            foreach (var stock in Stock.Stocks.Values)
            {
                var stockUpCostChanges = (int)(stock.Cost * StockChanges.UpCost);
                var stockDownCostChanges = (int)(stock.Cost * StockChanges.DownCost);
                stock.Cost += new Random().Next(stockDownCostChanges, stockUpCostChanges);
            }
        }

        private static void DiceRoll()
        {
            Cube = new Random().Next(1, 7);
            Player.CurrentPosition += Cube;
            
            if (Player.CurrentPosition - Calendar.Month * Player.Months > Calendar.Month)
            {
                if (Player.CurrentPosition > Calendar.Year)
                {
                    Player.Years += 1;
                    Player.Months = 0;
                    Player.CurrentPosition -= Calendar.Year;
                }
                else Player.Months++;
                
                Player.Savings += Player.CashFlow();
                if (Player.DebtMonths >= 1) Player.DebtMonths -= 1;
            }
            CurrentTile = CurrentMap.PlayingMap[Player.CurrentPosition - 1];
        }

        public static void GetMove()
        {
            GetTileAction(); // Действия клетки игрового поля
            IsWin(); // Проверка на условия победы в игре
            ChangeStocksCost(); // Изменение цен акций на бирже
            DiceRoll(); // Бросок костей
        }
    }
}