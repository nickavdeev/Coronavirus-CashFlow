using System;
using System.Collections.Generic;
using System.Linq;

namespace CoronavirusCashFlow
{
    public class Game
    {
        public static Player SetStudentMike()
        { 
            var studentMike = new Player(
                "Михаил", 
                "Студент со своей однокомнатной квартирой и стабильной работой. Но Михаилу кажется, что он способен на большее!",
                SocialNeed.Needs[1],
                100000, 
                new List<Asset>(), 
                new List<Liability>());
            studentMike.AddAsset(AssetType.Work, "Программист C#");
            studentMike.AddLiability(LiabilityType.SocialNeed, "Своя квартира");
            return studentMike;
        }

        public static void PrintPlayerInfo(Player player)
        {
            Console.WriteLine("Имя: " + player.Name);
            Console.WriteLine("Описание: " + player.Description);
            Console.WriteLine("Мечта: " + player.Dream);
            Console.WriteLine("Сбережения: " + player.Savings);
            Console.WriteLine("Денежный поток: " + player.CashFlow());
            Console.WriteLine("Доходы: " + player.Income() + " [" + string.Join(", ", player.AssetsList.Select(x => $"{x.Title} ({x.Income})")) + "]");
            Console.WriteLine("Расходы: " + player.Expenses() + " [" + string.Join(", ", player.LiabilitiesList.Select(x => $"{x.Title} ({x.Expense})")) + "]");
            Console.WriteLine("Активы: " + player.Assets() + " [" + string.Join(", ", player.AssetsList.Select(x => $"{x.Title} ({x.Cost})")) + "]");
            Console.WriteLine("Пассивы: " + player.Liabilities() + " [" + string.Join(", ", player.LiabilitiesList.Select(x => x.Title)) + "]");
            Console.WriteLine("Время: " + player.Hours());
        }
    }
}