using System;
using System.Collections.Generic;
// using System.Windows.Forms;

namespace CoronavirusCashFlow
{
    internal static class Program
    {
        private static void Main()
        {
            var player = new Player(
                "Никита",
                70000,
                new Dictionary<string, double>
                {
                    {"Работа", 25000}
                }, 
                new Dictionary<string, double>
                {
                    {"Квартплата", 8700},
                    {"Мобильная связь", 8000}
                }, 
                new Dictionary<string, double>(), 
                new Dictionary<string, double>
                {
                    {"Мобильный телефон", 1200}
                },new Dictionary<string, int>
                {
                    {"Учёба", -100},
                    {"Ноутбук", 15}
                });
            
            
            Console.WriteLine("Имя: " + player.Name);
            Console.WriteLine("Сбережения: " + player.Savings);
            Console.WriteLine("Денежный поток: " + player.CashFlow());
            Console.WriteLine("Доходы: " + player.Income());
            Console.WriteLine("Расходы: " + player.Expenses());
            Console.WriteLine("Активы: " + player.Assets());
            Console.WriteLine("Пассивы: " + player.Liabilities());
            Console.WriteLine("Время: " + player.Time());
            
            
        }
    }
}