using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    public class Player
    {
        /// <summary>
        /// Объект игрока.
        /// Name (имя), Savings (сбережения), Income (доходы), Expenses (расходы), CashFlow (денежный поток),
        /// Assets (активы), Liabilities (пассивы), Hours (свободное время)
        /// </summary>
        public readonly string Name;
        public readonly string Description;
        public readonly string Dream;
        public readonly double Savings;
        private const int WeekFreeTime = 140;
        
        public double CashFlow() => Income() - Expenses();
        public double Income() => AssetsList.Sum(x => x.Income);
        public double Expenses() => LiabilitiesList.Sum(x => x.Expense);

        public double Assets() => AssetsList.Sum(x => x.Cost);
        public readonly List<Asset> AssetsList;
        
        public double Liabilities() => LiabilitiesList.Sum(x => x.Cost);
        public readonly List<Liability> LiabilitiesList;

        public double Hours() => WeekFreeTime 
            - AssetsList.Sum(x => x.Hours) 
            + LiabilitiesList.Sum(x => x.Hours);

        internal Player(string name, string description, string dream, double savings, List<Asset> assetsList, List<Liability> liabilitiesList)
        {
            Name = name;
            Description = description;
            Dream = dream;
            Savings = savings;
            AssetsList = assetsList;
            LiabilitiesList = liabilitiesList;
        }

        public void AddAsset(AssetType assetType, string title)
        {
            switch (assetType)
            {
                case AssetType.Work:
                {
                    if (Work.Professions.Contains(title)) AssetsList.Add(Work.GetWork(title));
                    else throw new ArgumentException(
                        "Необходимо указать профессию из списка добавленных профессий! Список: " 
                        + string.Join(", ", Work.Professions));
                    break;
                }
                case AssetType.Stock:
                {
                    if (Stock.Companies.Contains(title)) AssetsList.Add(Stock.GetStock(title));
                    else throw new ArgumentException(
                        "Необходимо указать компанию из списка добавленных компаний! Список: " 
                        + string.Join(", ", Stock.Companies));
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(assetType), assetType, null);
            }
        }

        public void RemoveAsset(AssetType assetType, string title)
        {
            switch (assetType)
            {
                case AssetType.Work: AssetsList.RemoveAll(asset => asset.Title == $"Работа: {title}"); break;
                case AssetType.Stock: AssetsList.RemoveAll(asset => asset.Title == $"Акции {title}"); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(assetType), assetType, null);
            }
        }
        
        public void AddLiability(LiabilityType liabilityType, string title)
        {
            switch (liabilityType)
            {
                case LiabilityType.SocialNeed:
                {
                    if (SocialNeed.Needs.Contains(title)) LiabilitiesList.Add(SocialNeed.GetSocialNeed(title));
                    else throw new ArgumentException(
                        "Необходимо указать социальную потребность из списка! Список: " 
                        + string.Join(", ", SocialNeed.Needs));
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(liabilityType), liabilityType, null);
            }
        }
        
        public void RemoveLiability(LiabilityType liabilityType, string title)
        {
            switch (liabilityType)
            {
                case LiabilityType.SocialNeed: LiabilitiesList.RemoveAll(liability => liability.Title == title); break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(liabilityType), liabilityType, null);
            }
        }
    }
}