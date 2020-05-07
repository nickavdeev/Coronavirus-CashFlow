using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    public class Player
    {
        /// <summary>
        /// Объект игрока.
        /// Name (имя), Savings (сбережения), Income (доходы), Expenses (расходы), CashFlow (денежный поток),
        /// Assets (активы), Liabilities (пассивы), WeekFreeTime (свободное время в часах)
        /// </summary>
        public readonly string Name;
        public readonly string Description;
        public readonly Liability Dream;
        public readonly double Savings;
        private const int WeekFreeTime = 140;
        public int Cell = 0;
        
        public double CashFlow() => Income() - Expenses();
        public double Income() => AssetsList.Sum(x => x.Income);
        public double Expenses() => LiabilitiesList.Sum(x => x.Expense);

        public double Assets() => AssetsList.Sum(x => x.Cost);
        public List<Asset> AssetsList { get; }
        
        public double Liabilities() => LiabilitiesList.Sum(x => x.Cost);
        public readonly List<Liability> LiabilitiesList;

        public double Hours() => WeekFreeTime 
            - AssetsList.Sum(x => x.Hours) 
            + LiabilitiesList.Sum(x => x.Hours);

        internal Player(string name, string description, Liability dream, double savings, List<Asset> assetsList, List<Liability> liabilitiesList)
        {
            Name = name;
            Description = description;
            Dream = dream;
            Savings = savings;
            AssetsList = assetsList;
            LiabilitiesList = liabilitiesList;
        }

        public void AddAsset(Asset asset) => AssetsList.Add(asset);
        public void RemoveAsset(Asset asset) => AssetsList.Remove(asset);

        public void AddLiability(Liability liability) => LiabilitiesList.Add(liability);
        public void RemoveLiability(Liability liability) => LiabilitiesList.Remove(liability);
    }
}