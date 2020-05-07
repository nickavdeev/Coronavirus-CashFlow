using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    internal static class GameModel
    {
        public static readonly Player Player = SetStudentMike();

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
            studentMike.AddLiability(SocialNeed.GetSocialNeed("Своя квартира"));
            return studentMike;
        }

        public static string PlayerInfo(Player player)
        {
            return $"Мечта: {player.Dream.Title}\n \n" +
                   $"Сбережения: {player.Savings}\n \n" +
                   $"Денежный поток: {player.CashFlow()}\n \n" +
                   $"Доходы: {player.Income()}\n \n" +
                   $"Расходы: {player.Expenses()}\n \n" +
                   $"Активы: {player.Assets()}\n \n" +
                   $"Пассивы: {player.Liabilities()}\n \n" +
                   $"Время: {player.Hours()}";
        }
        
        private static readonly PlayingField PlayingField = new PlayingField();
        
        public static int Cube;
        public static PlayingCell CurrentField = PlayingField.FieldList[Player.Cell];

        public static void GetMove()
        {
            var goals = new List<bool> { Player.LiabilitiesList.Contains(Player.Dream) };
            if (!goals.Contains(false)) 
                Console.WriteLine($"Поздравляем! Вы достигли своей мечты: {Player.Name} купил {Player.Dream.Title}! 🎉");
            
            Cube = new Random().Next(1, 7);

            Player.Cell += Cube;
            if (Player.Cell > PlayingField.Cells) Player.Cell -= PlayingField.Cells;

            CurrentField = PlayingField.FieldList[Player.Cell];
        }
    }
}