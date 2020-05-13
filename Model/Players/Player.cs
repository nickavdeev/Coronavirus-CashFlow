using System.Collections.Generic;
using System.Linq;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.Model.Players
{
    public abstract class Player
    {
        /// <summary>
        /// Объект игрока.
        /// Name (имя), Savings (сбережения), Income (доходы), Expenses (расходы), CashFlow (денежный поток),
        /// Assets (активы), Liabilities (пассивы), WeekFreeTime (свободное время в часах)
        /// </summary>
        public string Name;
        public string Description;
        public Liability Dream;
        public double Savings;
        private const int WeekFreeTime = 140;
        public int CurrentPosition = 0;
        public int Months = 0;
        public int Years = 0;
        public int DebtMonths = 0;
        
        public double CashFlow() => Income() - Expenses();
        public double Income() => AssetsList.Sum(x => x.Income);
        public double Expenses() => LiabilitiesList.Sum(x => x.Expense);

        public double Assets() => AssetsList.Sum(x => x.Cost);
        public List<Asset> AssetsList { get; set; }

        public double Liabilities() => LiabilitiesList.Sum(x => x.Cost);
        public List<Liability> LiabilitiesList { get; set; }

        public double Hours() => WeekFreeTime 
                                 - AssetsList.Sum(x => x.Hours) 
                                 + LiabilitiesList.Sum(x => x.Hours);

        internal Player(string name, string description, Liability dream, double savings)
        {
            Name = name;
            Description = description;
            Dream = dream;
            Savings = savings;
            AssetsList = new List<Asset>();
            LiabilitiesList = new List<Liability>();
        }

        internal Player()
        {
            AssetsList = new List<Asset>();
            LiabilitiesList = new List<Liability>();
        }

        public void AddAsset(Asset asset, int count = 1)
        {
            for (var i = 0; i < count; i++) AssetsList.Add(asset);
        }

        public void RemoveAsset(Asset asset, int count = 1)
        {
            for (var i = 0; i < count; i++) AssetsList.Remove(asset);
        }

        public void AddLiability(Liability liability, double price = 0)
        {
            LiabilitiesList.Add(liability);
            if (liability is Car) LiabilitiesList.Add(Car.TransportTax);
            Savings -= price;
        }

        public void RemoveLiability(Liability liability) => LiabilitiesList.Remove(liability);

        public int GetAssetCount(Asset requestedAsset)
        {
            return AssetsList.Count(asset => asset.Title == requestedAsset.Title);
        }
    }
}