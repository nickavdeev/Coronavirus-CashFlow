using System.Collections.Generic;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class PlayerTests
    {
        [Test]
        public void CreatePlayer()
        {
            var player = new Player("Михаил", null, null, 100, null, null);
            Assert.AreEqual("Михаил", player.Name);
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
    }
}