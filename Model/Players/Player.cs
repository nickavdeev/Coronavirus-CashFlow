using System;
using System.Collections.Generic;
using System.Linq;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Enums;
using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.Model.Players
{
    public class Player
    {
        public readonly string Name;
        public readonly Liability Dream;
        public double Savings;
        private const int WeekFreeTime = 140;
        public int CurrentPosition = 0;
        public int Months = 0;
        public int Years = 0;
        public int DebtMonths = 0;
        
        public double CashFlow() => Income() - Expenses();
        private double Income() => AssetsList.Sum(x => x.Income);
        public double Expenses() => LiabilitiesList.Sum(x => x.Expense);

        private double Assets() => AssetsList.Sum(x => x.Cost);
        public List<Asset> AssetsList { get; }

        private double Liabilities() => LiabilitiesList.Sum(x => x.Cost);
        public List<Liability> LiabilitiesList { get; }

        private double Hours() => WeekFreeTime 
                                  - AssetsList.Sum(x => x.Hours) 
                                  + LiabilitiesList.Sum(x => x.Hours);

        public void AddAsset(Asset asset, int count = 1)
        {
            for (var i = 0; i < count; i++)
            {
                AssetsList.Add(asset);
                Savings -= asset.Cost;
            }
        }

        public void RemoveAsset(Asset asset, int count = 1)
        {
            if (GetAssetCount(asset) <= 0) return;
            for (var i = 0; i < count; i++)
            { 
                AssetsList.Remove(asset); 
                Savings += asset.Cost;
            }
        }

        public void AddLiability(Liability liability)
        {
            LiabilitiesList.Add(liability);
            if (liability is Car) LiabilitiesList.Add(Car.TransportTax);
            Savings -= liability.Cost;
        }

        public void RemoveLiability(Liability liability, int count = 1)
        {
            if (GameModel.Player.GetLiabilityCount(liability) <= 0) return;
            for (var i = 0; i < count; i++)
            {
                LiabilitiesList.Remove(liability);
                if (liability is Car) LiabilitiesList.Remove(Car.TransportTax);
                Savings += liability.Cost;
            }
        }

        private int GetAssetCount(Asset requestedAsset)
        {
            return AssetsList.Count(asset => asset.Title == requestedAsset.Title);
        }
        
        private int GetLiabilityCount(Liability requestedLiability)
        {
            return LiabilitiesList.Count(liability => liability.Title == requestedLiability.Title);
        }
        
        public string GetPlayerInfo(Player player, PlayerInfoType type)
        {
            string GetAssetInfo()
            {
                var uniqueAssets = new List<Asset>();
                var assetInfo = "";
                var i = 0;
                while (i < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[i];
                    
                    if (uniqueAssets.Contains(asset))
                    {
                        continue;
                    } 
                    uniqueAssets.Add(asset);
                    
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
                var uniqueLiabilities = new List<Liability>();
                var liabilityInfo = "";
                var i = 0;
                while (i < player.LiabilitiesList.Count)
                {
                    var liability = player.LiabilitiesList[i];
                    
                    if (uniqueLiabilities.Contains(liability)) continue;
                    uniqueLiabilities.Add(liability);
                    
                    var liabilityCount = player.GetLiabilityCount(liability);

                    if (liabilityCount > 1)
                    {
                        liabilityInfo += $"{liability.Title} — {liabilityCount} шт. ({liability.Cost * liabilityCount})\n \n";
                        i += liabilityCount;
                        continue;
                    }
                    if (Math.Abs(liability.Cost) < double.Epsilon) liabilityInfo += "";
                    else liabilityInfo += $"{liability.Title} ({liability.Cost})\n \n";
                    i++;
                }
                return liabilityInfo;
            }
            string GetAssetTimeInfo()
            {
                var uniqueAssets = new List<Asset>();
                var assetInfo = "";
                var i = 0;
                while (i < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[i];
                    
                    if (uniqueAssets.Contains(asset))
                    {
                        continue;
                    } 
                    uniqueAssets.Add(asset);
                    
                    var assetCount = player.GetAssetCount(asset);

                    if (assetCount > 1)
                    {
                        assetInfo += $"{asset.Title} — {assetCount} шт. ({asset.Hours * assetCount})\n \n";
                        i += assetCount;
                        continue;
                    }
                    
                    if (Math.Abs(asset.Hours) < double.Epsilon) assetInfo += "";
                    else assetInfo += $"{asset.Title} ({asset.Hours})\n \n";
                    i++;
                }
                return assetInfo;
            }
            string GetLiabilityTimeInfo()
            {
                var uniqueAssets = new List<Liability>();
                var assetInfo = "";
                var i = 0;
                while (i < player.LiabilitiesList.Count)
                {
                    var asset = player.LiabilitiesList[i];
                    
                    if (uniqueAssets.Contains(asset))
                    {
                        i++;
                        continue;
                    } 
                    uniqueAssets.Add(asset);
                    
                    var assetCount = player.GetLiabilityCount(asset);

                    if (assetCount > 1)
                    {
                        assetInfo += $"{asset.Title} — {assetCount} шт. ({asset.Hours * assetCount})\n \n";
                        i += assetCount;
                        continue;
                    }
                    
                    if (Math.Abs(asset.Hours) < double.Epsilon) assetInfo += "";
                    else assetInfo += $"{asset.Title} ({asset.Hours})\n \n";
                    i++;
                }
                return assetInfo;
            }
            string GetIncomeInfo()
            {
                var uniqueAssets = new List<Asset>();
                var incomeInfo = "";
                var i = 0;
                while (i < player.AssetsList.Count)
                {
                    var asset = player.AssetsList[i];
                    
                    if (uniqueAssets.Contains(asset))
                    {
                        continue;
                    } 
                    uniqueAssets.Add(asset);
                    
                    var assetCount = player.GetAssetCount(asset);

                    if (assetCount > 1)
                    {
                        incomeInfo += $"{asset.Title} — {assetCount} шт. ({asset.Income * assetCount})\n \n";
                        i += assetCount;
                        continue;
                    }
                    
                    if (Math.Abs(asset.Income) < double.Epsilon) incomeInfo += "";
                    else incomeInfo += $"{asset.Title} ({asset.Income})\n \n";
                    i++;
                }
                return incomeInfo;
            }
            string GetExpenseInfo()
            {
                var uniqueLiabilities = new List<Liability>();
                var expenseInfo = "";
                var i = 0;
                while (i < player.LiabilitiesList.Count)
                {
                    var liability = player.LiabilitiesList[i];
                    
                    if (uniqueLiabilities.Contains(liability)) continue;
                    uniqueLiabilities.Add(liability);
                    
                    var liabilityCount = player.GetLiabilityCount(liability);

                    if (liabilityCount > 1)
                    {
                        expenseInfo += $"{liability.Title} — {liabilityCount} шт. ({liability.Expense * liabilityCount})\n \n";
                        i += liabilityCount;
                        continue;
                    }
                    if (Math.Abs(liability.Cost) < double.Epsilon) expenseInfo += "";
                    else expenseInfo += $"{liability.Title} ({liability.Expense})\n \n";
                    i++;
                }
                return expenseInfo;
            }
            
            switch (type)
            {
                case PlayerInfoType.MainInfo:
                    string GetYears(int year)
                    {
                        if (year == 0) return "";
                        return year % 10 < 5 ? year + " г. " : year + " л. ";
                    }
                    return $"В игре: {GetYears(player.Years)}{player.Months} мес.\n \n" +
                           $"Мечта: {player.Dream.Title}\n \n" + $"Сбережения: {player.Savings}\n \n" +
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

        internal Player()
        {
            AssetsList = new List<Asset>();
            LiabilitiesList = new List<Liability>();
        }

        internal Player(PlayerName playerName)
        {
            switch (playerName)
            {
                case PlayerName.Mike:
                    Name = "Михаил";
                    Dream = Car.GetCar("Porsche Cayman");
                    Savings = 200000;
                    AssetsList = new List<Asset>
                    {
                        Work.GetWork("Программист"),
                    };
                    LiabilitiesList = new List<Liability>
                    {
                        SocialNeed.GetSocialNeed("Своя квартира"),
                        SocialNeed.GetSocialNeed("Связь и интернет"),
                        Car.GetCar("Volkswagen Polo"), Car.TransportTax,
                        SocialNeed.GetSocialNeed("Продукты"),
                        SocialNeed.GetSocialNeed("Транспорт"),
                    };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(playerName), playerName, null);
            }
        }
    }
}