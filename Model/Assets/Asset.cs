namespace CoronavirusCashFlow.Model.Assets
{
    public abstract class Asset
    {
        public string Title;
        public double Cost;
        public readonly double Income;
        public readonly int Hours;
        
        protected Asset(string title, double cost, double income, int hours)
        {
            Title = title;
            Cost = cost;
            Income = income;
            Hours = hours;
        }
        
        protected Asset(string title, double income, int hours)
        {
            Title = title;
            Cost = 0;
            Income = income;
            Hours = hours;
        }
    }
}