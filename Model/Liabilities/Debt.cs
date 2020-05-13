using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Model.Players;

namespace CoronavirusCashFlow.Model.Liabilities
{
    public class Debt : Liability
    {
        public Debt(string title, double cost, double expense, int hours) : base(title, cost, expense, hours) {}

        public static Liability GetDebt(string title) => Debts[title];
        private static readonly Dictionary<string, Liability> Debts = new Dictionary<string, Liability>
        {
            // Кредиты
            {"Кредит", new Debt("Кредит", 2000000, GameModel.Player.CashFlow() / 2, -2)},
        };
    }
}