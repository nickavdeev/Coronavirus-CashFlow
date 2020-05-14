using CoronavirusCashFlow.Model.Liabilities;

namespace CoronavirusCashFlow.Constants
{
    public static class DebtResult
    {
        public const string CreditDenial = "Невозможно взять кредит. Увеличивайте свой денежный поток.";
        public static string BankOffer(Liability debt) => $"Банк предлагает кредит на {debt.Cost} с ежемесячным платежём {debt.Expense} на {(int) (debt.Cost / debt.Expense)} месяцев.";
    }
}