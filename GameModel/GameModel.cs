using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    public enum PlayerInfoTypes
    {
        MainInfo,
        IncomeInfo,
        ExpensesInfo,
        AssetsInfo,
        LiabilitiesInfo,
        TimeInfo
    }
    internal static class GameModel
    {
        public static readonly Player Player = SetStudentMike();
        private static readonly PlayingField PlayingFieldMap = new PlayingField();
        
        public static int Cube;
        public static PlayingCell CurrentField = PlayingFieldMap.FieldList[Player.Cell];

        private static Player SetStudentMike()
        { 
            var studentMike = new Player(
                "Михаил", 
                "Студент со своей однокомнатной квартирой и стабильной работой. Но Михаил уверен, что способен на большее!",
                Car.GetCar("Porsche Cayman"),
                100000, 
                new List<Asset>(), 
                new List<Liability>());
            studentMike.AddAsset(Work.GetWork("Программист"));
            studentMike.AddAsset(Stock.GetStock("Netflix"));
            studentMike.AddLiability(SocialNeed.GetSocialNeed("Своя квартира"));
            return studentMike;
        }

        public static string PlayerInfo(Player player, PlayerInfoTypes type)
        {
            switch (type)
            {
                case PlayerInfoTypes.MainInfo:
                    return $"Мечта: {player.Dream.Title}\n \n" + $"Сбережения: {player.Savings}\n \n" +
                           $"Денежный поток: {player.CashFlow()}\n \n" + $"Доходы: {player.Income()}\n \n" +
                           $"Расходы: {player.Expenses()}\n \n" + $"Активы: {player.Assets()}\n \n" +
                           $"Пассивы: {player.Liabilities()}\n \n" + $"Время: {player.Hours()}";
                case PlayerInfoTypes.IncomeInfo:
                    return string.Join("\n \n", player.AssetsList.Select(x => $"{x.Title} ({x.Income})"));
                case PlayerInfoTypes.ExpensesInfo:
                    return string.Join("\n \n", player.LiabilitiesList.Select(x => $"{x.Title} ({x.Expense})"));
                case PlayerInfoTypes.AssetsInfo:
                    return string.Join("\n \n", player.AssetsList.Select(x => $"{x.Title} ({x.Cost})"));
                case PlayerInfoTypes.LiabilitiesInfo:
                    return string.Join("\n \n", player.LiabilitiesList.Select(x => $"{x.Title} ({x.Cost})"));
                case PlayerInfoTypes.TimeInfo:
                {
                    var assetTime = string.Join("\n \n", player.AssetsList.Select(x => $"{x.Title} ({x.Hours})"));
                    var liabilityTime = string.Join("\n \n", player.LiabilitiesList.Select(x => $"{x.Title} ({x.Hours})"));
                    return $"Активы времени:\n \n{liabilityTime}\n \n \n \nПассивы времени:\n \n{assetTime}";
                }
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static void GetMove()
        {
            var goals = new List<bool> { Player.LiabilitiesList.Contains(Player.Dream) };
            if (!goals.Contains(false)) 
                Console.WriteLine($"Поздравляем! Вы достигли своей мечты: {Player.Name} купил {Player.Dream.Title}! 🎉");

            Stock.GetStock("Netflix").Cost += 100;
            
            Cube = new Random().Next(1, 7);

            Player.Cell += Cube;
            if (Player.Cell > PlayingField.Cells) Player.Cell -= PlayingField.Cells;

            CurrentField = PlayingFieldMap.FieldList[Player.Cell];
        }
    }
}