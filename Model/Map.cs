using System;
using System.Collections.Generic;
using CoronavirusCashFlow.Constants;
using CoronavirusCashFlow.Controller.PlayingFiled;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;
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
            new LifeSituation(LifeSituationText.GiftForFriend299, Buttons.PassButtonCreditList, 299),
            new LifeSituation(LifeSituationText.GiftForFriend399, Buttons.PassButtonCreditList, 399),
            new LifeSituation(LifeSituationText.Education29990, Buttons.PassButtonCreditList, 29990),
            new LifeSituation(LifeSituationText.ApartmentRepair50000, Buttons.PassButtonCreditList, 50000),
            new LifeSituation(LifeSituationText.Flooded5000, Buttons.PassButtonCreditList, 5000),
            new LifeSituation(LifeSituationText.Medicines1890, Buttons.PassButtonCreditList, 1890),
            new LifeSituation(LifeSituationText.RefrigeratorBurnedOut30499, Buttons.PassButtonCreditList, 30499),
            new LifeSituation(LifeSituationText.TrafficAccident5000, Buttons.PassButtonCreditList, 5000),
            new LifeSituation(LifeSituationText.TrafficAnimalAccident9000, Buttons.PassButtonCreditList, 9000),
            new LifeSituation(LifeSituationText.TripToParents5000, Buttons.PassButtonCreditList, 5000),
            new LifeSituation(LifeSituationText.PhoneBroke49900, Buttons.PassButtonCreditList, 49900),
            new LifeSituation(LifeSituationText.NewSuit15900, Buttons.PassButtonCreditList, 15900),
            new LifeSituation(LifeSituationText.Skiing27000, Buttons.PassButtonCreditList, 27000),
            new LifeSituation(LifeSituationText.Vacation40000, Buttons.PassButtonCreditList, 40000),
            new LifeSituation(LifeSituationText.Vacation33000, Buttons.PassButtonCreditList, 33000),
            new LifeSituation(LifeSituationText.Donut230, Buttons.PassButtonCreditList, 230),
            new LifeSituation(LifeSituationText.Pizza900, Buttons.PassButtonCreditList, 900),
            new LifeSituation(LifeSituationText.SharpWings1100, Buttons.PassButtonCreditList, 1100),
            new LifeSituation(LifeSituationText.Antivirus2900, Buttons.PassButtonCreditList, 2900),
        };

        private readonly List<FixedCosts> _fixedCosts = new List<FixedCosts>
        {
            new FixedCosts("Вам скучно на карантине поэтому вы оформили постоянную подписку на Рандекс.Музыку", Buttons.PassButtonList,
                SocialNeed.GetSocialNeed("Подписка Рандекс.Музыка")),
            new FixedCosts("Все дела дома переделаны, все сериалы пересмотрены. Осталось только приобрести подписку на стриминговый сервис Metflix... Что вы и сделали!", Buttons.PassButtonList,
                SocialNeed.GetSocialNeed("Подписка Metflix"))
        };
        
        private readonly List<StockSituation> _stockSituations = new List<StockSituation>
        {
            new StockSituation(StockSituationText.PisneyVsMetfix, Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                {{(Stock)Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * -0.05}}),
            new StockSituation("Sova Capital подняла рекомендации по акциям «Рандекс» с Держать до Покупать. Акции уже прибавляют в цене", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Рандекс"), Stock.GetStock("Рандекс").Cost * 0.07}}),
            new StockSituation("Во время пандемии «Рандекс» отлично зарабатывает на своих ИТ-серивисах. Котировки растут, а инвесторы верят в компанию", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Рандекс"), Stock.GetStock("Рандекс").Cost * 0.04}}),
            new StockSituation("Компания Gilead заявила о создании вакцины против коронавируса. В моменте акции растут на 5%", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Gilead"), Stock.GetStock("Gilead").Cost * 0.05}}),
            new StockSituation("Президент страны заявил о финансовой поддержке компании «Газнефть». Котировки растут на 8%", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Газнефть"), Stock.GetStock("Газнефть").Cost * 0.08}}),
            new StockSituation("Президент США резко высказался по поводу утечки данных стримингового сервиса Metflix. Акции резко теряют в цене 13%", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * -0.13}}),
            new StockSituation("Президент США заявил о возможных санкциях в отношении компании «Газнефть». Акции компании рухнули на 20%", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Газнефть"), Stock.GetStock("Газнефть").Cost * -0.20}}),
            new StockSituation("Популярность сервиса видеоконференци Zuum набирает обороты. Компания заявила о 120 миллионах активных пользователей в месяц. Котировки прибавляют 10%", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Zuum"), Stock.GetStock("Zuum").Cost * 0.1}}),
            new StockSituation("«Сервис Zuum стал самым популярным сервисом видеоконференций», - газета CoronaTimes", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Zuum"), Stock.GetStock("Zuum").Cost * 0.10}}),
            new StockSituation("CoronaTimes: «Gilead готовит к выпуску новый препарат от коронавируса»", Buttons.PassButtonList, 
                new Dictionary<Stock, double>
                    {{(Stock)Stock.GetStock("Gilead"), Stock.GetStock("Gilead").Cost * 0.15}}),
        };

        private readonly List<News> _news = new List<News>
        { 
            new News(NewsText.MetflixFutureReport, Buttons.NewsButtonGoodReportList, 
                new Dictionary<Stock, double>
                {{(Stock) Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * 0.1},}),
            new News(NewsText.MetflixFutureReport, Buttons.NewsButtonBadReportList, 
                new Dictionary<Stock, double>
                {{(Stock) Stock.GetStock("Metflix"), Stock.GetStock("Metflix").Cost * -0.1},}),
            
            new News("CoronaTimes: «Компания «Газнефть» вскоре заявит о приостановке строительства нового газопровода»", 
                Buttons.OkButtonNewsBadGazneftList, 
                new Dictionary<Stock, double>
                    {{(Stock) Stock.GetStock("Газнефть"), Stock.GetStock("Газнефть").Cost * -0.2},}),
            
            new News("CoronaTimes: «Компания «Рандекс» покажет отличный финансовый отчёт в ближайшее время»", Buttons.OkButtonNewsGoodRandexList, 
                new Dictionary<Stock, double>
                    {{(Stock) Stock.GetStock("Рандекс"), Stock.GetStock("Рандекс").Cost * 0.2},}),
            
            new News("CoronaTimes: «Zuum ожидает неплохая прибыль в текущем квартале»", Buttons.OkButtonNewsGoodZuumList, 
                new Dictionary<Stock, double>
                    {{(Stock) Stock.GetStock("Zuum"), Stock.GetStock("Zuum").Cost * 0.2},}),
            
            new News("CoronaTimes: «Gilead создал вакцину от вируса, но она должна пройти испытания Федеральной администрации по здравоохранению»", Buttons.OkButtonNewsBadGileadList, 
                new Dictionary<Stock, double>
                    {{(Stock) Stock.GetStock("Gilead"), Stock.GetStock("Gilead").Cost * -0.25},}),
        };
        
        private readonly List<Dream> _dreams = new List<Dream>
        {
            new Dream($"{DreamText.MakeYourDreamComeTrue}", Buttons.GetDreamButtons()),
        };

        public Map()
        {
            for (var i = 0; i < Calendar.Year / 30; i++)
            {
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_fixedCosts.Count)]);
                PlayingMap.Add(_news[new Random().Next(_dreams.Count)]);
                
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_stockSituations[new Random().Next(_stockSituations.Count)]);
                PlayingMap.Add(_news[new Random().Next(_news.Count)]);
                PlayingMap.Add(_dreams[new Random().Next(_dreams.Count)]);
                
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_fixedCosts[new Random().Next(_fixedCosts.Count)]);
                PlayingMap.Add(_news[new Random().Next(_dreams.Count)]);
                
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_stockSituations[new Random().Next(_stockSituations.Count)]);
                PlayingMap.Add(_news[new Random().Next(_news.Count)]);
                PlayingMap.Add(_dreams[new Random().Next(_dreams.Count)]);
                
                PlayingMap.Add(_advises[new Random().Next(_advises.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_lifeSituations[new Random().Next(_lifeSituations.Count)]);
                PlayingMap.Add(_fixedCosts[new Random().Next(_fixedCosts.Count)]);
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