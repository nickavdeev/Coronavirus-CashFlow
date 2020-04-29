using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    internal class Player
    {
        /// <summary>
        /// Объект игрока.
        /// Name (имя), Savings (сбережения), Income (доходы), Expenses (расходы), CashFlow (денежный поток),
        /// Assets (активы), Liabilities (пассивы), Time (свободное время)
        /// </summary>
        public readonly string Name;
        public readonly double Savings;
        private const int WeekFreeTime = 144;
        
        public double CashFlow() => Income() - Expenses();
        public double Income() => _incomeList.Sum(x => x.Value);
        private readonly Dictionary<string, double> _incomeList;
        
        public double Expenses() => _expensesList.Sum(x => x.Value);
        private readonly Dictionary<string, double> _expensesList;

        public double Assets() => _assetsList.Sum(x => x.Value);
        private readonly Dictionary<string, double> _assetsList;
        
        public double Liabilities() => _liabilitiesList.Sum(x => x.Value);
        private readonly Dictionary<string, double> _liabilitiesList;
        
        public double Time() => WeekFreeTime + _timeList.Sum(x => x.Value);
        private readonly Dictionary<string, int> _timeList;

        internal Player()
        {
            Name = "Игрок"; 
            _expensesList = new Dictionary<string, double>();
            _assetsList = new Dictionary<string, double>();
            _liabilitiesList = new Dictionary<string, double>();
            _timeList = new Dictionary<string, int>();
        }
        
        internal Player(string name, double savings, Dictionary<string, double> incomeList, 
            Dictionary<string, double> expensesList, Dictionary<string, double> assetsList, 
            Dictionary<string, double> liabilitiesList, Dictionary<string, int> timeList)
        {
            Name = name;
            Savings = savings;
            _incomeList = incomeList;
            _expensesList = expensesList;
            _assetsList = assetsList;
            _liabilitiesList = liabilitiesList;
            _expensesList = expensesList;
            _timeList = timeList;
        }
    }
}