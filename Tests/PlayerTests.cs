using System.Collections.Generic;
using CoronavirusCashFlow.Model;
using CoronavirusCashFlow.Model.Assets;
using CoronavirusCashFlow.Model.Liabilities;
using CoronavirusCashFlow.Model.Players;
using NUnit.Framework;

namespace CoronavirusCashFlow.Tests
{
    public class PlayerTests
    {
        [Test]
        public void CreatePlayer()
        {
            var player = new Mike();
            Assert.AreEqual("Михаил", player.Name);
        }

        [Test]
        public void CreatePlayerWithAssetsLiabilitiesAndDream()
        {
            var player = new Mike();
            player.AddAsset(Stock.GetStock("Netflix"));
            player.AddLiability(Car.GetCar("Volkswagen Polo"));
            
            Assert.AreEqual("Автомобиль: Porsche Cayman", player.Dream.Title);
            Assert.AreEqual("Акции Netflix", player.AssetsList[0].Title);
            Assert.AreEqual("Автомобиль: Volkswagen Polo", player.LiabilitiesList[0].Title);
        }
        
        [Test]
        public void RemoveAssetsAndLiabilities()
        {
            var player = new Mike();
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
            var player = new Mike();
            player.RemoveAsset(Stock.GetStock("Netflix"));

            Assert.AreEqual(0, player.AssetsList.Count);
        }
        
        [Test]
        public void AddTaxWithCar()
        {
            var player = new Mike();
            player.AddLiability(Car.GetCar("Volkswagen Polo"));

            Assert.AreEqual(true, player.LiabilitiesList.Contains(Tax.GetTax("Транспортный налог")));
        }
    }
}