namespace CoronavirusCashFlow.Model.Liabilities
{
    public abstract class Liability
    {
        public readonly string Title;
        public readonly double Cost;
        public readonly double Expense;
        public readonly int Hours;

        internal Liability(string title, double cost, double expense, int hours)
        {
            Title = title;
            Cost = cost;
            Expense = expense;
            Hours = hours;
        }
    }
}