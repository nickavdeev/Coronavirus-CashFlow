using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Controller.PlayingFiled;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Tiles;

namespace CoronavirusCashFlow.Model
{
    public class Map
    {
        public readonly List<Tile> PlayingMap = new List<Tile>();

        private readonly List<Advice> _advises = new List<Advice>
        {
            new Advice(AdviceText.InvestInYourself, Buttons.PassButtonList),
            new Advice(AdviceText.InvestYourCapital, Buttons.PassButtonList),
            new Advice(AdviceText.AchieveDream, Buttons.PassButtonList),
        };
        
        private readonly List<LifeSituation> _lifeSituations = new List<LifeSituation>
        {
            new LifeSituation(LifeSituationText.GiftForFriend299, Buttons.PassButtonList, 299),
            new LifeSituation(LifeSituationText.GiftForFriend399, Buttons.PassButtonList, 399),
        };
        
        private readonly List<StockSituation> _stockSituations = new List<StockSituation>
        {
            new StockSituation(StockSituationText.PisneyVsMetfix, Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                {{(Stock)Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * -0.05}}),
        };

        private readonly List<News> _news = new List<News>
        { 
            new News(NewsText.MetflixFutureReport, Buttons.NewsButtonGoodReportList, 
                new Dictionary<Stock, double>
                {{(Stock) Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * 0.1},}),
            new News(NewsText.MetflixFutureReport, Buttons.NewsButtonBadReportList, 
                new Dictionary<Stock, double>
                {{(Stock) Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * -0.1},}),
        };
        
        private readonly List<Dream> _dreams = new List<Dream>
        { 
            new Dream($"{DreamText.MakeYourDreamComeTrue}", Buttons.GetDreamButtons()),
        };

        public Map()
        {
            for (var i = 0; i < Calendar.Year / 10; i++)
            {
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_news[new Random().Next(_dreams.Count)]);
                
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_stockSituations[new Random().Next(_stockSituations.Count)]);
                PlayingMap.Add(_news[new Random().Next(_news.Count)]);
                PlayingMap.Add(_dreams[new Random().Next(_dreams.Count)]);
            }
        }
    }
}