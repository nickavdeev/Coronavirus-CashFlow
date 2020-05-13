using System.Collections.Generic;
using CoronavirusCashFlow.Controller;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Players;

namespace CoronavirusCashFlow.Model.Tiles
{
    public class Map
    {
        public static readonly List<Tile> PlayingMap = new List<Tile>();

        private readonly List<Advice> _advises = new List<Advice>
        {
            new Advice(
                "Если хотите стать богатым — инвестируйте в себя! Первым вложением любого инвестора должна быть его личность, его навыки, его знания!",
                Buttons.PassButtonList),
            new Advice(
                "В мире финансовых инструментов деньги - это все, из чего состоят срочные депозиты, государственные облигации и другие инструменты денежного рынка.\n \nЕсли вы хотите быстро разбогатеть, то не храните наличные деньги - капитал не сможет вырасти, если ничего с ним не делать.",
                Buttons.PassButtonList),
            new Advice(
                $"Достигните своей мечты: деньги лишь средство, а не цель!\n \nМечта: {GameModel.Player.Dream.Title}",
                Buttons.PassButtonList),
        };
        
        private readonly List<LifeSituation> _lifeSituations = new List<LifeSituation>
        {
            new LifeSituation(
                "Вы увидели в интернет-магазине отличную вещь и вспомнили, что скоро у вашего хорошего " +
                $"друга день рождения. Как нельзя кстати и всего 299 рублей!",
                Buttons.LifeSituationButtonList, 299),
            new LifeSituation(
                "Вы увидели в интернет-магазине отличную вещь и вспомнили, что скоро у вашего хорошего " +
                $"друга день рождения. Как нельзя кстати и всего 399 рублей!",
                Buttons.LifeSituationButtonList, 399),
        };
        
        private readonly List<StockSituation> _stockSituations = new List<StockSituation>
        {
            new StockSituation(
                $"Глава компании Pisney резко высказался по поводу безопасности стримингового сервиса " +
                $"Metflix. Акции падают.",
                Buttons.StockSituationButtonList),
        };

        private readonly List<News> _news = new List<News>
        { 
            new News(
                "У Metflix скоро отчёт...", Buttons.NewsButtonGoodReportList, new Dictionary<Stock, double>
                {
                    {(Stock) Stock.GetStock("Metflix"), 10000},
                }),
            new News(
                "У Metflix скоро отчёт.......", Buttons.NewsButtonBadReportList, new Dictionary<Stock, double>
                {
                    {(Stock) Stock.GetStock("Metflix"), -300},
                }),
        };
        
        private readonly List<Dream> _dreams = new List<Dream>
        { 
            new Dream($"Купите мечту: {GameModel.Player.Dream.Title}.\n \n" +
                      $"Цена: {GameModel.Player.Dream.Cost}", Buttons.GetDreamButtons()),
        };

        public Map()
        {
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
            
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
            
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_advises[0]);
            PlayingMap.Add(_dreams[0]);
        }
    }
}