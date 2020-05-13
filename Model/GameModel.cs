using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;
using CoronavirusCashFlow.Model.Players;
using CoronavirusCashFlow.Model.Tiles;

namespace CoronavirusCashFlow.Model
{
    public static class GameModel
    {
        public static readonly Player Player = new Mike();
        private static readonly Map Map = new Map();
        public static Tile CurrentTile = Map.PlayingMap[Player.CurrentPosition];
        public static int Cube;

        public static string GetPlayerInfo(Player player, PlayerInfoType type)
        {
            string GetAssetInfo()
            {
                var assetInfo = "";
                var i = 0;
                while (i < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[i];
                    var assetCount = player.GetAssetCount(asset);

                    if (assetCount > 1)
                    {
                        assetInfo += $"{asset.Title} — {assetCount} шт. ({asset.Cost * assetCount})\n \n";
                        i += assetCount;
                        continue;
                    }
                    if (Math.Abs(asset.Cost) < double.Epsilon) assetInfo += "";
                    else assetInfo += $"{asset.Title} ({asset.Cost})\n \n";
                    i++;
                }
                return assetInfo;
            }
            string GetLiabilityInfo()
            {
                var liabilityInfo = "";
                var a = 0;
                while (a < player.LiabilitiesList.Count)
                {
                    var liability = player.LiabilitiesList[a];

                    if (Math.Abs(liability.Cost) < double.Epsilon) liabilityInfo += "";
                    else liabilityInfo += $"{liability.Title} ({liability.Cost})\n \n";
                    a++;
                }
                return liabilityInfo;
            }
            string GetAssetTimeInfo()
            {
                var assetTimeInfo = "";
                var a = 0;
                while (a < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[a];
                    var assetCount = player.GetAssetCount(asset);
                    
                    if (Math.Abs(asset.Hours) < double.Epsilon) assetTimeInfo += "";
                    
                    else if (assetCount > 1)
                    {
                        assetTimeInfo += $"{asset.Title} — {assetCount} шт. ({asset.Hours * assetCount})\n \n";
                        a += assetCount;
                        continue;
                    }
                    else assetTimeInfo += $"{asset.Title} ({asset.Hours})\n \n";
                    a++;
                }
                return assetTimeInfo;
            }
            string GetLiabilityTimeInfo()
            {
                var liabilityTimeInfo = "";
                var a = 0;
                while (a < player.LiabilitiesList.Count)
                {
                    var liability = player.LiabilitiesList[a];
                    
                    if (Math.Abs(liability.Hours) < double.Epsilon) liabilityTimeInfo += "";
                    
                    else liabilityTimeInfo += $"{liability.Title} ({liability.Hours})\n \n";
                    a++;
                }
                return liabilityTimeInfo;
            }
            string GetIncomeInfo()
            {
                var incomeInfo = "";
                var i = 0;
                while (i < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[i];
                    var assetCount = player.GetAssetCount(asset);
                    if (assetCount > 1)
                    {
                        incomeInfo += $"{asset.Title} — {assetCount} шт. ({asset.Income * assetCount})\n \n";
                        i += assetCount;
                        continue;
                    }
                    incomeInfo += $"{asset.Title} ({asset.Income})\n \n";
                    i++;
                }
                return incomeInfo;
            }
            string GetExpenseInfo()
            {
                var expenseInfo = "";
                var i = 0;
                while (i < player.LiabilitiesList.Count)
                {
                    var liability = player.LiabilitiesList[i];
                    
                    expenseInfo += $"{liability.Title} ({liability.Expense})\n \n";
                    i++;
                }
                return expenseInfo;
            }
            
            switch (type)
            {
                case PlayerInfoType.MainInfo:
                    return $"Мечта: {player.Dream.Title}\n \n" + $"Сбережения: {player.Savings}\n \n" +
                           $"Денежный поток: {player.CashFlow()}\n \n" + $"Доходы: {player.Income()}\n \n" +
                           $"Расходы: {player.Expenses()}\n \n" + $"Активы: {player.Assets()}\n \n" +
                           $"Пассивы: {player.Liabilities()}\n \n" + $"Время: {player.Hours()}";
                case PlayerInfoType.IncomeInfo: return GetIncomeInfo();
                case PlayerInfoType.ExpensesInfo: return GetExpenseInfo();
                case PlayerInfoType.AssetsInfo: return GetAssetInfo();
                case PlayerInfoType.LiabilitiesInfo: return GetLiabilityInfo();
                case PlayerInfoType.TimeInfo: return $"Активы времени:\n \n{GetLiabilityTimeInfo()}\n \n \n \nПассивы времени:\n \n{GetAssetTimeInfo()}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private static void ChangeStocksCost()
        {
            foreach (var stock in Stock.Stocks.Values)
            {
                var stockPriceChanges = (int)(stock.Cost * Constants.StockPriceChanges);
                stock.Cost += new Random().Next(-stockPriceChanges / 2, stockPriceChanges);
            }
        }

        public static void GetMove()
        {
            if (Player.DebtMonths == 1) Player.RemoveLiability(Debt.GetDebt("Кредит"));

            Player.Savings -= CurrentTile.Cost; 
            Player.Savings += CurrentTile.Income; 
            if (CurrentTile.StockList != null) foreach (var stock in CurrentTile.StockList.Keys) stock.Cost += CurrentTile.StockList[stock];

            // Проверка на условия победы в игре
            var goals = new List<bool> { Player.LiabilitiesList.Contains(Player.Dream) };
            if (!goals.Contains(false)) 
                Console.WriteLine($"Поздравляем! Вы достигли мечты: {Player.Name} купил {Player.Dream.Title}! 🎉");

            // Изменение цен акций на бирже
            ChangeStocksCost();
            
            // Бросок кости
            Cube = new Random().Next(1, 7);
            Player.CurrentPosition += Cube;
            
            if (Player.CurrentPosition > Constants.Month)
            {
                Player.Savings += Player.CashFlow();
                if (Player.DebtMonths >= 1) Player.DebtMonths -= 1;
                Player.CurrentPosition -= Constants.Month;
                Player.Months += 1;
            }
            if (Player.Months > Constants.MonthsInYear)
            {
                Player.Years += 1;
                Player.Months = 0;
            }

            CurrentTile = Map.PlayingMap[Player.CurrentPosition - 1];
        }
    }
}