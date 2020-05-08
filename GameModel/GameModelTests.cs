using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CoronavirusCashFlow
{
    public class Tests
    {
        [Test]
        public void CreatePlayer()
        {
            var player = new Player("Михаил", null, null, 100, null, null);
            Assert.AreEqual("Михаил", player.Name);
        }
        
        [Test]
        public void GetAssets()
        {
            var work = Work.GetWork("Программист");
            Assert.AreEqual("Работа: Программист", work.Title);
            
            var stock = Stock.GetStock("Netflix");
            Assert.AreEqual("Акции Netflix", stock.Title);
        }
        
        [Test]
        public void GetWrongAsset()
        {
            Assert.Throws<KeyNotFoundException>(() => Work.GetWork("Несуществующий вид работы"));
        }
        
        [Test]
        public void GetLiability()
        {
            var socialNeed = SocialNeed.GetSocialNeed("Своя квартира");
            Assert.AreEqual("Своя квартира", socialNeed.Title);
            
            var car = Car.GetCar("Volkswagen Polo");
            Assert.AreEqual("Автомобиль: Volkswagen Polo", car.Title);
        }
        
        [Test]
        public void GetWrongLiability()
        {
            Assert.Throws<KeyNotFoundException>(() => Car.GetCar("ВАЗ 2109"));
        }

        [Test]
        public void CreatePlayerWithAssetsLiabilitiesAndDream()
        {
            var player = new Player(
                "Михаил", 
                "Описание", 
                Car.GetCar("Porsche Cayman"), 
                100000, 
                new List<Asset>(), 
                new List<Liability>());
            player.AddAsset(Stock.GetStock("Netflix"));
            player.AddLiability(Car.GetCar("Volkswagen Polo"));
            
            Assert.AreEqual("Автомобиль: Porsche Cayman", player.Dream.Title);
            Assert.AreEqual("Акции Netflix", player.AssetsList[0].Title);
            Assert.AreEqual("Автомобиль: Volkswagen Polo", player.LiabilitiesList[0].Title);
        }
        
        [Test]
        public void RemoveAssetsAndLiabilities()
        {
            var player = new Player(
                "Михаил", 
                "Описание", 
                Car.GetCar("Porsche Cayman"), 
                100000, 
                new List<Asset>(), 
                new List<Liability>());
            
            player.AddAsset(Stock.GetStock("Netflix"));
            player.AddLiability(Car.GetCar("Volkswagen Polo"));
            
            player.RemoveAsset(Stock.GetStock("Netflix"));
            player.RemoveLiability(Car.GetCar("Volkswagen Polo"));

            Assert.AreEqual(0, player.AssetsList.Count);
            Assert.AreEqual(0, player.LiabilitiesList.Count);
        }
        
        [Test]
        public void RemoveNonexistentItem()
        {
            var player = new Player(
                "Михаил", 
                "Описание", 
                Car.GetCar("Porsche Cayman"), 
                100000, 
                new List<Asset>(), 
                new List<Liability>());
            player.RemoveAsset(Stock.GetStock("Netflix"));

            Assert.AreEqual(0, player.AssetsList.Count);
        }
        
        [Test]
        public void GetGameModelDefaultPlayer()
        {
            var player = GameModel.Player;
            Assert.AreEqual("Михаил", player.Name);
        }
        
        [Test]
        public void ChangeStockCostAfterMove()
        {
            var player = new Player(
                "Михаил", 
                "Описание", 
                Car.GetCar("Porsche Cayman"), 
                100000, 
                new List<Asset> {Stock.GetStock("Netflix")}, 
                new List<Liability>());
            var costBeforeMove = player.AssetsList[0].Cost;
            GameModel.GetMove();
            var costAfterMove = player.AssetsList[0].Cost;

            Assert.AreEqual(false, Math.Abs(costBeforeMove - costAfterMove) < double.Epsilon);
        }
    }
}